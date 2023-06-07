using Moonstone.Core.Memory;
using System.Reflection;

namespace Moonstone.Core.Architecture.Scanner;
public class Scannable : IDisposable
{
    protected readonly IScanService ScanService;
    protected readonly IProcess Process;
    private readonly Action[] _scannables;

    public Scannable(
        IProcess process,
        IScanService scanService)
    {
        Process = process;
        ScanService = scanService;

        _scannables = GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(it => it.GetCustomAttributes(typeof(ScannableMethodAttribute), true).Length > 0)
            .Select(it => (Action)Delegate.CreateDelegate(typeof(Action), this, it.Name))
            .ToArray();

        ScanService.AddAll(_scannables);
    }

    public void Dispose()
    {
        ScanService.RemoveAll(_scannables);
    }
}
