using System.Text;

namespace Moonstone.Core.Memory;

public interface IMemoryReader
{
    public long Read(long address, int[] offsets);
    public string Read(long address, int length, Encoding? encoding = null);
    public T Read<T>(long address) where T : struct;
    public T[] Read<T>(long address, int count) where T : struct;
}