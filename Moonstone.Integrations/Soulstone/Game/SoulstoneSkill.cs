using Moonstone.Core.Architecture.Events;
using Moonstone.Core.Architecture.Scanner;
using Moonstone.Core.Entity.Player;
using Moonstone.Core.Game.Contracts.Events;
using Moonstone.Core.Memory;

namespace Moonstone.Integrations.Soulstone.Game;
internal class SoulstoneSkill : Scannable, ISkill
{
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        private set
        {
            if (value == _name)
                return;

            _name = value;
            this.Dispatch(NameChange, new SkillStatsChangeEventArgs(this));
        }
    }

    private float _totalDamage;
    public float TotalDamage
    {
        get => _totalDamage;
        private set
        {
            if (value == _totalDamage)
                return;

            _totalDamage = value;
            this.Dispatch(TotalDamageChange, new SkillStatsChangeEventArgs(this));
        }
    }

    private TimeSpan _activeTime = TimeSpan.Zero;
    public TimeSpan ActiveTime
    {
        get => _activeTime;
        private set
        {
            if (value == _activeTime)
                return;

            _activeTime = value;
            this.Dispatch(ActiveTimeChange, new SkillStatsChangeEventArgs(this));
        }
    }

    private int _killCount;
    public int KillCount
    {
        get => _killCount;
        private set
        {
            if (value == _killCount)
                return;

            _killCount = value;
            this.Dispatch(KillCountChange, new SkillStatsChangeEventArgs(this));
        }
    }
    public event EventHandler<SkillStatsChangeEventArgs>? NameChange;
    public event EventHandler<SkillStatsChangeEventArgs>? TotalDamageChange;
    public event EventHandler<SkillStatsChangeEventArgs>? ActiveTimeChange;
    public event EventHandler<SkillStatsChangeEventArgs>? KillCountChange;

    public SoulstoneSkill(IProcess process, IScanService scanService) : base(process, scanService) { }
}
