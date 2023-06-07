using System;

namespace Moonstone.Core.Memory.Events;

public class GameStartEventArgs : EventArgs
{

    public IProcess Game { get; }

    public GameStartEventArgs(IProcess game)
    {
        Game = game;
    }
}