namespace Dont_Fear_The_Death;

public class GameFunction
{
    public static void DrawFrame(string file)
    {
        // Pfad zur Datei: "Frames/Demo/*FILE*".
        // Wir verwenden AppDomain.CurrentDomain.BaseDirectory, um sicherzustellen, dass wir im korrekten Verzeichnis suchen.
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Frames", "Demo", file);

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            CenterText.WriteCentered(content);
        }
        else
        {
            // Fallback oder Fehlermeldung, falls die Datei nicht gefunden wird.
            Console.WriteLine($"Fehler: Die Datei '{filePath}' konnte nicht gefunden werden.");
        }
    }
}