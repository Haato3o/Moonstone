using Moonstone.Core.Entity.Context;
using Moonstone.Core.Memory;
using Moonstone.Core.Memory.Events;
using Moonstone.Integration.Soulstone.Game;
using Moonstone.Integration.Soulstone.Process;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace Moonstone;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application, IDisposable
{
    private readonly IProcessScanner _processScanner;
    private IProcess? _process;
    private IContext? _context;

    public App()
    {
        _processScanner = new SoulstoneProcessScanner();
    }

    private void OnLoadComplete(object sender, NavigationEventArgs e)
    {
        HookEvents();

        _processScanner.Scan();
    }

    private void OnGameShutdown(object? sender, EventArgs e)
    {
        _process = null;
        _context = null;
    }

    private void OnGameStart(object? sender, GameStartEventArgs e)
    {
        _process = e.Game;
        _context = new SoulstoneContext(e.Game);
    }

    private void HookEvents()
    {
        _processScanner.GameStart += OnGameStart;
        _processScanner.GameShutdown += OnGameShutdown;
    }

    public void Dispose()
    {
        _processScanner.GameStart -= OnGameStart;
        _processScanner.GameShutdown -= OnGameShutdown;
    }
}
