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
            Mechanic.del();
            Mechanic.mWait();
            CenterText.WriteCentered(Message.MainMenuTitle);
            Mechanic.sendEmptyness();
            Mechanic.testInput();
        }
        catch (Exception ex)
        {
            Mechanic.del();
            Mechanic.sendError(ex.Message);
            Mechanic.sendError(ex.StackTrace);
            Mechanic.send(Message.betaWarning);
            Console.WriteLine(Message.FullscreenFailure);
            Mechanic.mWait();
            Mechanic.betaExit();
        }
    }
}
