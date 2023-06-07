using Moonstone.Core.Architecture.Events;
using Moonstone.Core.Game.Contracts.Events;

namespace Moonstone.Core.Entity.Player;

public interface ISkill : IDispatchable
{
    public string Name { get; }
    public float TotalDamage { get; }
    public TimeSpan ActiveTime { get; }
    public int KillCount { get; }

    public event EventHandler<SkillStatsChangeEventArgs> NameChange;
    public event EventHandler<SkillStatsChangeEventArgs> TotalDamageChange;
    public event EventHandler<SkillStatsChangeEventArgs> ActiveTimeChange;
    public event EventHandler<SkillStatsChangeEventArgs> KillCountChange;
}