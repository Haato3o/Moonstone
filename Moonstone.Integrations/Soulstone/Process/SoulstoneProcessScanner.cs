using Moonstone.Core.Architecture.Events;
using Moonstone.Core.Memory;
using Moonstone.Core.Memory.Events;
using Moonstone.Core.Memory.Windows;
using Moonstone.Core.Native.Windows;
using OSProcess = System.Diagnostics.Process;

namespace Moonstone.Integrations.Soulstone.Process;
internal class SoulstoneProcessScanner : IProcessScanner, IDispatchable
{
    private const string ProcessName = "Soulstone Survivors.exe";

    public event EventHandler<GameStartEventArgs>? GameStart;
    public event EventHandler<EventArgs>? GameShutdown;

    private OSProcess? _process;
    private IntPtr _pHandle;
    private readonly Thread _thread;
    private readonly object _lock = new();
    private bool _isDisposed;

    public SoulstoneProcessScanner()
    {
        _thread = new Thread(Scan)
        {
            Name = nameof(SoulstoneProcessScanner),
            IsBackground = true
        };
    }

    public void Scan()
    {
        _thread.Start();

        while (!_isDisposed)
        {
            PollProcessInfo();
        }
    }

    public void Dispose()
    {
        lock (_lock)
        {
            _isDisposed = true;
        }
    }

    private void PollProcessInfo()
    {
        if (_process?.HasExited == true)
        {
            HandleProcessExit();
            return;
        }

        OSProcess? gameProcess = OSProcess.GetProcessesByName(ProcessName)
            .FirstOrDefault(it => !string.IsNullOrEmpty(it.MainWindowTitle));

        if (gameProcess is null)
            return;

        if (_process is not null)
        {
            gameProcess.Dispose();
            return;
        }

        try
        {
            _process = gameProcess;
            _pHandle = Kernel32.OpenProcess(Kernel32.AllAccess, false, _process.Id);

            if (_pHandle == IntPtr.Zero)
                throw new UnauthorizedAccessException("Missing permissions to open process");

            var process = new SoulstoneProcess(gameProcess, CreateReader(_pHandle));

            this.Dispatch(GameStart, new GameStartEventArgs(process));
        }
        catch (Exception _)
        {
            // TODO: Add logging
            _process?.Dispose();
            return;
        }
    }

    private static IMemoryReader CreateReader(IntPtr handle)
    {
        return OperatingSystem.IsWindows()
            ? new WindowsMemoryReader(handle)
            : throw new SystemException("Unsupported operating system");
    }

    private void HandleProcessExit()
    {
        _process?.Dispose();
        _process = null;

        Kernel32.CloseHandle(_pHandle);

        _pHandle = IntPtr.Zero;

        this.Dispatch(GameShutdown, EventArgs.Empty);
    }
}
