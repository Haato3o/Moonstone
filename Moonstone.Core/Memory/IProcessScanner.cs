using Moonstone.Core.Memory.Events;
using System;

namespace Moonstone.Core.Memory;

public interface IProcessScanner : IDisposable
{
    public void Scan();

    public event EventHandler<GameStartEventArgs> GameStart;
    public event EventHandler<EventArgs> GameShutdown;
}