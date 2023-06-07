using System;

namespace Moonstone.Core.Game.Contracts.Events;
public class SkillEventArgs : EventArgs
{

    public ISkill Skill { get; }

    public SkillEventArgs(ISkill skill)
    {
        Skill = skill;
    }
}
