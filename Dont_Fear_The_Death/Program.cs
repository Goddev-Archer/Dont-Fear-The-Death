using Terminal.Gui;
using Terminal.Gui.Views;

using System.Threading;

namespace Dont_Fear_The_Death;

class Program
{
    static void Main(string[] args)
    {
        try 
        {
            Console.WriteLine("For Optimal Experience (Fullscreen), click the Window in the next 5 seconds...");
            Thread.Sleep(5000);
            Game_Data.PressF11();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("Make sure to run the application with appropriate permissions. It is POSSIBLE, that the application needs to be run as Administrator to simulate key presses.");
        }
    }
}
