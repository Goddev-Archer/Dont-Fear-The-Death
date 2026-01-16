using Terminal.Gui;
using Terminal.Gui.Views;
using System.Runtime.InteropServices;
using System.Threading;

namespace Dont_Fear_The_Death;

class Program
{
    static void Main(string[] args)
    {
        PressF11();
        Console.ReadKey();
    }
    
    static void PressF11()
    {
        var inputs = new[]
        {
            new INPUT {
                type =1, // INPUT_KEYBOARD U = new InputUnion { ki = new KEYBDINPUT { wVk = VK_F11 } }
            },
            new INPUT {
                type =1,
                U = new InputUnion { ki = new KEYBDINPUT { wVk = VK_F11, dwFlags = KEYEVENTF_KEYUP } }
            }
        };

        if (SendInput((uint)inputs.Length, inputs, Marshal.SizeOf<INPUT>()) ==0)
            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
    }

    const ushort VK_F11 =0x7A;
    const uint KEYEVENTF_KEYUP =0x0002;

    [DllImport("user32.dll", SetLastError = true)]
    static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    [StructLayout(LayoutKind.Sequential)]
    struct INPUT {
        public uint type;
        public InputUnion U;
    }

    [StructLayout(LayoutKind.Explicit)]
    struct InputUnion {
        [FieldOffset(0)] public KEYBDINPUT ki;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct KEYBDINPUT {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public nuint dwExtraInfo;
    }
}