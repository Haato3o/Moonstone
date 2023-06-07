namespace Moonstone.Core.Memory;
public interface IProcess
{
    public IMemoryAddressProvider MemoryAddressProvider { get; }
    public IMemoryReader Memory { get; }
}
