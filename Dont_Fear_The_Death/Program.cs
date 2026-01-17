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
            CenterText.WriteCentered(Message.FullscreenInformation);
            Mechanic.mWait();
            FullscreenSet.PressF11();
            Mechanic.mWait();
            Mechanic.del();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine(Message.FullscreenFailure);
        }
    }
}
