using System.Runtime.InteropServices;                                                                                   // Für DllImport und Struktur-Layout// Für IntPtr

namespace Dont_Fear_The_Death;                                                                                          // Namespace der Anwendung

public class FullscreenSet                                                                                                  // Klasse für Spieldaten und Eingabesteuerung
{
    public static void PressF11()                                                                                       // Methode zum Simulieren des Tastendrucks F11
    {
        INPUT[] inputs = new INPUT[2];                                                                                  // Array für Tastendruck und -loslassen
        inputs[0].type = INPUT_KEYBOARD;                                                                                // Tastendruck F11 (Down)
        inputs[0].U.ki.wVk = VK_F11;                                                                                    // Virtueller Tastencode für F11
        inputs[0].U.ki.wScan = 0;                                                                                       // Hardware-Scan-Code für die Taste
        inputs[0].U.ki.dwFlags = 0;                                                                                     // 0 für Tastendruck
        inputs[0].U.ki.time = 0;                                                                                        // Zeitstempel für das Ereignis
        inputs[0].U.ki.dwExtraInfo = IntPtr.Zero;                                                                       // Zusätzliche Informationen
        
        inputs[1].type = INPUT_KEYBOARD;                                                                                // Tastendruck F11 (Up)
        inputs[1].U.ki.wVk = VK_F11;                                                                                    // Virtueller Tastencode für F11
        inputs[1].U.ki.wScan = 0;                                                                                       // Hardware-Scan-Code für die Taste
        inputs[1].U.ki.dwFlags = KEYEVENTF_KEYUP;                                                                       // KEYEVENTF_KEYUP für Tastelosslassen
        inputs[1].U.ki.time = 0;                                                                                        // Zeitstempel für das Ereignis
        inputs[1].U.ki.dwExtraInfo = IntPtr.Zero;                                                                       // Zusätzliche Informationen

        int structSize = Marshal.SizeOf(typeof(INPUT));                                                               // Größe der INPUT-Struktur
        
        // Sollte SendInput fehlschlagen, wird eine Win32Exception mit dem letzten Fehlercode ausgelöst
        if (SendInput((uint)inputs.Length, inputs, structSize) == 0)                                                    // Senden der Eingaben
            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());                                // Fehlerbehandlung
    }

    const ushort VK_F11 = 0x7A;                                                                                         // Virtueller Tastencode für F11
    const uint KEYEVENTF_KEYUP = 0x0002;                                                                                // Flag für Tastelosslassen
    const int INPUT_KEYBOARD = 1;                                                                                       // Eingabetyp für Tastatur

    [DllImport("user32.dll", SetLastError = true)]                                                               // Import der SendInput-Funktion aus user32.dll
    static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);                                            // Senden von Eingaben an das System

    [StructLayout(LayoutKind.Sequential)]                                                                               // Struktur für die Eingabe
    struct INPUT                                                                                                        // Eingabe-Struktur
    {
        public int type;                                                                                                // Typ der Eingabe (Tastatur, Maus, etc.)
        public InputUnion U;                                                                                            // Union für verschiedene Eingabetypen
    }

    [StructLayout(LayoutKind.Explicit)]                                                                                 // Union für verschiedene Eingabetypen
    struct InputUnion                                                                                                   // Eingabe-Union
    {
        [FieldOffset(0)] public MOUSEINPUT mi;                                                                          // Maus-Eingabe
        [FieldOffset(0)] public KEYBDINPUT ki;                                                                          // Tastatur-Eingabe
        [FieldOffset(0)] public HARDWAREINPUT hi;                                                                       // Hardware-Eingabe
    }

    [StructLayout(LayoutKind.Sequential)]                                                                               // Struktur für Tastatureingabe
    struct KEYBDINPUT                                                                                                   // Tastatur-Eingabe-Struktur
    {
        public ushort wVk;                                                                                              // Virtueller Tastencode
        public ushort wScan;                                                                                            // Hardware-Scan-Code
        public uint dwFlags;                                                                                            // Eingabe-Flags
        public uint time;                                                                                               // Zeitstempel für das Ereignis
        public IntPtr dwExtraInfo;                                                                                      // Zusätzliche Informationen
    }

    [StructLayout(LayoutKind.Sequential)]                                                                               // Struktur für Maus-Eingabe
    struct MOUSEINPUT                                                                                                   // Maus-Eingabe-Struktur
    {
        public int dx;                                                                                                  // X-Koordinate der Mausbewegung
        public int dy;                                                                                                  // Y-Koordinate der Mausbewegung
        public uint mouseData;                                                                                          // Zusätzliche Mausdaten
        public uint dwFlags;                                                                                            // Eingabe-Flags
        public uint time;                                                                                               // Zeitstempel für das Ereignis
        public IntPtr dwExtraInfo;                                                                                      // Zusätzliche Informationen
    }

    [StructLayout(LayoutKind.Sequential)]                                                                               // Struktur für Hardware-Eingabe
    struct HARDWAREINPUT                                                                                                // Hardware-Eingabe-Struktur
    {
        public uint uMsg;                                                                                               // Nachrichtencode
        public ushort wParamL;                                                                                          // Parameter L
        public ushort wParamH;                                                                                          // Parameter H
    }
}