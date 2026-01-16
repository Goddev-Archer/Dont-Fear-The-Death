using Terminal.Gui;
using Terminal.Gui.Views;

using System.Threading;

namespace Dont_Fear_The_Death;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Thread.Sleep(2000); 

        try 
        {
            Game_Data.PressF11();
            Console.WriteLine("F11 Pressed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
        Console.WriteLine("Waiting 10 seconds before exiting...");
        Thread.Sleep(10000);
    }
}
