namespace Dont_Fear_The_Death;

public class Mechanic
{
    public static void sWait()
    {
        Thread.Sleep(2000);
    }
    
    public static void mWait()
    {
        Thread.Sleep(4000);
    }
    
    public static void lWait()
    {
        Thread.Sleep(6000);
    }

    public static void del()
    {
        Console.Clear();
    }

    public static void testInput()
    {
        Console.WriteLine(Message.PressAnyKeyToContinue);
        Console.ReadKey();
        mWait();
    }

    public static void betaExit()
    {
        del();
        Console.WriteLine(Message.exit129);
        mWait();
        Environment.Exit(129);
    }

    public static void send(string text)
    {
        try
        {
            Console.WriteLine(text);
        }
        catch (
            Exception e
            )
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }
    }

    public static void sendEmptyness()
    {
        Console.WriteLine();
    }

    public static void sendError(string text)
    {
        Console.WriteLine($"ERROR: {text}");
    }
}