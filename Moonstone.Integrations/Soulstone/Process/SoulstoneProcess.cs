using Moonstone.Core.Memory;
using OSProcess = System.Diagnostics.Process;

namespace Moonstone.Integrations.Soulstone.Process;
public class SoulstoneProcess : IProcess
{
    public IMemoryAddressProvider MemoryAddressProvider { get; }
    public IMemoryReader Memory { get; }

    public SoulstoneProcess(OSProcess process, IMemoryReader memoryReader)
    {
        MemoryAddressProvider = new SoulstoneMemoryAddressProvider(process);
        Memory = memoryReader;
    }
}
