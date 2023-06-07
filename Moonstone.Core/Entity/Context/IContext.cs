using Moonstone.Core.Entity.Game;

namespace Moonstone.Core.Entity.Context;
public interface IContext
{
    public IGame Game { get; }
}
