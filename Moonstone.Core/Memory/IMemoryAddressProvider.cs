using System;

namespace Moonstone.Core.Memory;

public interface IMemoryAddressProvider
{
    public IntPtr GetAbsolute(string name);
    public int[] GetOffsets(string name);
}