using System.Runtime.InteropServices;

namespace Dont_Fear_The_Death;

public class Game_Data
{
    public static void PressF11()
    {
        INPUT[] inputs = new INPUT[2];

        // Tastendruck F11 (Down)
        inputs[0].type = INPUT_KEYBOARD;
        inputs[0].U.ki.wVk = VK_F11;
        inputs[0].U.ki.wScan = 0;
        inputs[0].U.ki.dwFlags = 0;
        inputs[0].U.ki.time = 0;
        inputs[0].U.ki.dwExtraInfo = IntPtr.Zero;

        // Tastendruck F11 (Up)
        inputs[1].type = INPUT_KEYBOARD;
        inputs[1].U.ki.wVk = VK_F11;
        inputs[1].U.ki.wScan = 0;
        inputs[1].U.ki.dwFlags = KEYEVENTF_KEYUP;
        inputs[1].U.ki.time = 0;
        inputs[1].U.ki.dwExtraInfo = IntPtr.Zero;

        int structSize = Marshal.SizeOf(typeof(INPUT));
        
        // Sollte 40 auf x64 und 28 auf x86 sein
        if (SendInput((uint)inputs.Length, inputs, structSize) == 0)
            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
    }

    const ushort VK_F11 = 0x7A;
    const uint KEYEVENTF_KEYUP = 0x0002;
    const int INPUT_KEYBOARD = 1;

    [DllImport("user32.dll", SetLastError = true)]
    static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    [StructLayout(LayoutKind.Sequential)]
    struct INPUT
    {
        public int type;
        public InputUnion U;
    }

    [StructLayout(LayoutKind.Explicit)]
    struct InputUnion
    {
        [FieldOffset(0)] public MOUSEINPUT mi;
        [FieldOffset(0)] public KEYBDINPUT ki;
        [FieldOffset(0)] public HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }
}