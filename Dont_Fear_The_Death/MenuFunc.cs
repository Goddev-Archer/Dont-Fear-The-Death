namespace Dont_Fear_The_Death;

public class MenuFunc
{
    public static void StartNewGame()
    {
        Mechanic.send("Not implemented yet.");
    }
    
    public static void MenuExplore()
    {
        bool run = true;

        while (run)
        {
            GameData.BootInit();
            string input = Console.ReadLine();
            if (input == "1")
            {
                StartNewGame();
                Mechanic.sWait();
            }
            else if (input == "2")
            {
                GameData.OptionsOpen();
                OptionsExplore();
            }
            else if (input == "3")
            {
                Mechanic.del();
                Mechanic.sWait();
                Mechanic.sendALotOfWhiteSpaces(36);
                CenterText.WriteCentered(Message.Credits);
                Mechanic.sWait();
                Mechanic.sendEmptyness();
                CenterText.WriteCentered(Message.PAKTC);
                Console.ReadKey();
            }
            else if (input == "4")
            {
                Mechanic.send("No Savings implemented yet.");
            }
            else if (input == "5")
            {
                Mechanic.del();
                Mechanic.send(Message.ClosingMessage);
                Mechanic.sendEmptyness();
                Mechanic.send(Message.exit129);
                Mechanic.mWait();
                Environment.Exit(129);
            }
            else
            {
                Mechanic.send(Message.invalidInput);
            }
        }
    }

    public static void OptionsExplore()
    {
        bool run = true;
        while (run)
        {
            GameData.OptionsOpen();
            string input = Console.ReadLine();
            if (input == "1")
            {
                Mechanic.sendEmptyness();
                CenterText.WriteCentered("No Audio Settings available yet.");
                Mechanic.lWait();
            }
            else if (input == "2")
            {
                Mechanic.sendEmptyness();
                CenterText.WriteCentered("No Video Settings available yet.");
                Mechanic.lWait();
            }
            else if (input == "3")
            {
                Mechanic.sendEmptyness();
                CenterText.WriteCentered("No control settings available yet.");
                Mechanic.lWait();
            }
            else if (input == "4")
            {
                run = false;
            }
            else
            {
                Mechanic.send(Message.invalidInput);
                Mechanic.mWait();
            }
        }
    }
}