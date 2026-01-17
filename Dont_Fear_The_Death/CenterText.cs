namespace Dont_Fear_The_Death;

public class CenterText
{
    public static void WriteCentered(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine();
            return;
        }

        string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        int windowWidth = Console.WindowWidth;

        foreach (var line in lines)
        {
            int padding = Math.Max(0, (windowWidth - line.Length) / 2);
            Console.WriteLine(new string(' ', padding) + line);
        }
    }
}