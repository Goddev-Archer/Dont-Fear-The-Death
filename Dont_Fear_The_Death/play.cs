using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Dont_Fear_The_Death;

public class Play
{
    private static SoundPlayer? _activePlayer;
    private static Process? _activeProcess;

    public static string? CurrentTrack { get; private set; }

    public static bool IsPlaying(string trackName)
    {
        return CurrentTrack == trackName;
    }

    public static void StopSound()
    {
        CurrentTrack = null;
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _activePlayer?.Stop();
                _activePlayer?.Dispose();
                _activePlayer = null;
            }
            else
            {
                if (_activeProcess != null)
                {
                    if (!_activeProcess.HasExited)
                    {
                        _activeProcess.Kill();
                    }
                    _activeProcess.Dispose();
                    _activeProcess = null;
                }
            }
        }
        catch { }
    }

    public static void PlaySound(string file)
    {
        try 
        {
            // Extrahieren der Ressource in eine temporäre Datei
            string resourceName = "Dont_Fear_The_Death.Sounds." + file;
            string tempPath = Path.Combine(Path.GetTempPath(), "dftd_" + file);
            
            // Nur extrahieren, wenn sie nicht existiert oder um sicherzugehen (optional file lock checks etc, aber hier keep simple)
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    // Fallback, falls Resource nicht gefunden (sollte nicht passieren)
                    CenterText.WriteCentered(Message.betaWarning);
                    Mechanic.sendEmptyness();
                    CenterText.WriteCentered(Message.PlayerError);
                    return;
                }
                
                using (var fileStream = File.Create(tempPath))
                {
                    stream.CopyTo(fileStream);
                }
            }
            
            StopSound();
            CurrentTrack = file;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                PlayWindows(tempPath);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                PlayMac(tempPath);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                PlayLinux(tempPath);
            }
        }
        catch (Exception ex)
        {
            // Fehler stillschweigend ignorieren oder loggen
            // Console.WriteLine("Fehler beim Abspielen: " + ex.Message);
        }
    }

    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    private static void PlayWindows(string path)
    {
        _activePlayer = new SoundPlayer(path);
        _activePlayer.Play();
    }

    private static void PlayMac(string path)
    {
        try { _activeProcess = Process.Start("afplay", path); } catch {}
    }

    private static void PlayLinux(string path)
    {
        try { _activeProcess = Process.Start("aplay", path); } catch {}
    }
}