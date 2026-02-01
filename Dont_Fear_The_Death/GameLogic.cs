namespace Dont_Fear_The_Death;

public class GameLogic
{
    public static void RunDemo(int frameDelay)
    {
        int delay = frameDelay * 1000;
        
        GameFunction.DrawFrame("frame01.txt");
        Thread.Sleep(delay);
        Console.Clear();
        GameFunction.DrawFrame("frame02.txt");
        Thread.Sleep(delay);
        Console.Clear();
        GameFunction.DrawFrame("frame03.txt");
        Thread.Sleep(delay);
        Console.Clear();
        Console.ReadKey();
    }
}