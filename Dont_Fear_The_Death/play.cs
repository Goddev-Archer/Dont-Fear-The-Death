using NetCoreAudio;
using System.Reflection;

namespace Dont_Fear_The_Death;

public class Play
{
    private static readonly Player _player = new();

    public static string? CurrentTrack { get; private set; }

    public static bool IsPlaying(string trackName)
    {
        return CurrentTrack == trackName;
    }

    public static void StopSound()
    {
        CurrentTrack = null;
        try { _player.Stop(); } catch { }
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
            _player.Play(tempPath);
        }
        catch (Exception ex)
        {
            // Fehler stillschweigend ignorieren oder loggen
            // Console.WriteLine("Fehler beim Abspielen: " + ex.Message);
        }
    }
}
