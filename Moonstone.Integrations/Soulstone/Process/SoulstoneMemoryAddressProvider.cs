using Moonstone.Core.Memory;
using System.Diagnostics;
using OSProcess = System.Diagnostics.Process;

namespace Moonstone.Integrations.Soulstone.Process;

public class SoulstoneMemoryAddressProvider : IMemoryAddressProvider
{
    private readonly IntPtr _baseAddress;
    private static readonly int[] Offsets = { 0xB8, 0x38, 0x1A8, 0x0 };

    public SoulstoneMemoryAddressProvider(OSProcess process)
    {
        _baseAddress = FindGameAssemblyModuleAddress(process) ?? IntPtr.Zero;
    }

    public IntPtr GetAbsolute(string name) => _baseAddress + 0x1633E08;

    public int[] GetOffsets(string name) => Offsets;

    private IntPtr? FindGameAssemblyModuleAddress(OSProcess process)
    {
        return process.Modules.Cast<ProcessModule>()
            .FirstOrDefault(module => module.ModuleName == "GameAssembly.dll")
            ?.BaseAddress;
    }
}