using System.Runtime.InteropServices;

namespace Moonstone.Core.Native.Windows;
public static class Kernel32
{
    public const int AllAccess = 0x001F0FFF;

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(
        int dwDesiredAccess,
        bool bInheritHandle,
        int dwProcessId
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool ReadProcessMemory(
        IntPtr hProcess,
        IntPtr lpBaseAddress,
        byte[] lpBuffer,
        int dwSize,
        out int lpNumberOfBytesRead
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool ReadProcessMemory(
        IntPtr hProcess,
        IntPtr lpBaseAddress,
        [Out, MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
        int dwSize,
        out int lpNumberOfBytesRead
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool ReadProcessMemory(
        IntPtr hProcess,
        IntPtr lpBaseAddress,
        IntPtr lpBuffer,
        int dwSize,
        out int lpNumberOfBytesRead
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool CloseHandle(IntPtr hObject);
}
