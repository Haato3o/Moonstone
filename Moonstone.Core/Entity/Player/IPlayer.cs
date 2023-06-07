using Moonstone.Core.Architecture.Events;
using Moonstone.Core.Game.Contracts.Events;

namespace Moonstone.Core.Entity.Player;

public interface IPlayer : IDispatchable
{
    public IReadOnlyCollection<ISkill> Skills { get; }

    public event EventHandler<SkillEventArgs> SkillAdded;
    public event EventHandler<SkillEventArgs> SkillRemoved;
}