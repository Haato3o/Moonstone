using System.Runtime.InteropServices;

namespace Moonstone.Core.Memory.System.Common;
public static class MarshalHelper
{
    /// <summary>
    /// Converts an unmanaged buffer to a managed structure
    /// </summary>
    /// <typeparam name="T">Structure type</typeparam>
    /// <param name="handle">Pointer to the first structure</param>
    /// <param name="count">Length</param>
    /// <returns>Array of structures</returns>
    public static T[] BufferToStructures<T>(IntPtr handle, int count)
    {
        var results = new T[count];

        for (int i = 0; i < results.Length; i++)
        {
            results[i] = Marshal.PtrToStructure<T>(IntPtr.Add(handle, i * Marshal.SizeOf<T>()))!;
        }

        return results;
    }
}
