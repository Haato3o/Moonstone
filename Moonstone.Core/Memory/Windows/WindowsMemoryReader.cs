using Moonstone.Core.Memory.System.Common;
using Moonstone.Core.Native.Windows;
using System.Runtime.InteropServices;
using System.Text;

namespace Moonstone.Core.Memory.Windows;

public class WindowsMemoryReader : IMemoryReader
{
    private readonly IntPtr _handle;

    public WindowsMemoryReader(IntPtr handle)
    {
        _handle = handle;
    }

    public long Read(long address, int[] offsets)
    {
        foreach (int offset in offsets)
        {
            long next = Read<long>(address);

            if (next == 0)
                return 0;

            address = next + offset;
        }

        return address;
    }

    public string Read(long address, int length, Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;
        byte[] buffer = new byte[length];

        Kernel32.ReadProcessMemory(_handle, (IntPtr)address, buffer, length, out _);

        string raw = encoding.GetString(buffer, 0, length);
        int nullCharIndex = raw.IndexOf('\x00');

        return nullCharIndex < 0
            ? raw
            : raw[..nullCharIndex];
    }

    public T Read<T>(long address) where T : struct =>
        Read<T>(address, 1)[0];

    public T[] Read<T>(long address, int count) where T : struct
    {
        Type type = typeof(T);

        return type.IsPrimitive
            ? ReadPrimitive<T>(address, count)
            : ReadComplex<T>(address, count);
    }

    private T[] ReadPrimitive<T>(long address, int count) where T : struct
    {
        int size = Marshal.SizeOf<T>() * count;
        var buffer = new T[count];

        Kernel32.ReadProcessMemory(_handle, (IntPtr)address, buffer, size, out _);

        return buffer;
    }

    private T[] ReadComplex<T>(long address, int count) where T : struct
    {
        int size = Marshal.SizeOf<T>() * count;
        IntPtr unmanagedBuffer = Marshal.AllocHGlobal(size);

        Kernel32.ReadProcessMemory(_handle, (IntPtr)address, unmanagedBuffer, size, out _);

        T[] structures = MarshalHelper.BufferToStructures<T>(unmanagedBuffer, count);

        Marshal.FreeHGlobal(unmanagedBuffer);

        return structures;
    }
}
