using System.Runtime.InteropServices;

namespace Moonstone.Integrations.Soulstone.Definitions;

[StructLayout(LayoutKind.Sequential)]
internal struct GameStatsSkillData
{
    public long NamePointer;
    public int NameHash;
    public float FloatValue;
    public int IntValue;
}
