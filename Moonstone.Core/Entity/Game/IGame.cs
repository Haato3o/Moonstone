using Moonstone.Core.Entity.Player;

namespace Moonstone.Core.Entity.Game;

public interface IGame
{
    public IPlayer Player { get; }
}