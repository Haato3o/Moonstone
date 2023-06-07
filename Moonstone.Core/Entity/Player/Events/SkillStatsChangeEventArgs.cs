using Moonstone.Core.Entity.Player;

namespace Moonstone.Core.Game.Contracts.Events;
public class SkillStatsChangeEventArgs : EventArgs
{
    public string Name { get; }
    public float TotalDamage { get; }
    public TimeSpan ActiveTime { get; }
    public int KillCount { get; }

    public SkillStatsChangeEventArgs(ISkill skill)
    {
        Name = skill.Name;
        TotalDamage = skill.TotalDamage;
        ActiveTime = skill.ActiveTime;
        KillCount = skill.KillCount;
    }
}
