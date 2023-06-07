using Moonstone.Core.Architecture.Scanner;
using Moonstone.Core.Entity.Player;
using Moonstone.Core.Game.Contracts.Events;
using Moonstone.Core.Memory;

namespace Moonstone.Integrations.Soulstone.Game;
internal class SoulstonePlayer : Scannable, IPlayer
{
    private readonly List<ISkill> _skills = new();

    public IReadOnlyCollection<ISkill> Skills => _skills;

    public event EventHandler<SkillEventArgs>? SkillAdded;
    public event EventHandler<SkillEventArgs>? SkillRemoved;

    public SoulstonePlayer(IProcess process, IScanService scanService) : base(process, scanService) { }

    [ScannableMethod]
    private void GetSkills()
    {

    }
}
