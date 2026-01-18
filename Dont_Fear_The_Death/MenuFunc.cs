namespace Dont_Fear_The_Death;

public class MenuFunc
{
    public static void StartNewGame()
    {
        Mechanic.send("Not implemented yet.");
        Mechanic.mWait();
    }
    
    public static void MenuExplore()
    {
        bool run = true;

        while (run)
        {
            string input = Console.ReadLine();
            if (input == "1")
            {
                StartNewGame();
            }
            else if (input == "2")
            {
                GameData.OptionsOpen();
            }
            else
            {
                Mechanic.send(Message.invalidInput);
                Mechanic.mWait();
                Mechanic.betaExit();
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
                Mechanic.del();
                Mechanic.sendALotOfWhiteSpaces(25);
                CenterText.WriteCentered("No Audio Settings available yet.");
                Mechanic.lWait();
                run = false;
            }
            else if (input == "2")
            {
                Mechanic.sendALotOfWhiteSpaces(36);
                CenterText.WriteCentered(GUI.OptionsMenu);
                Mechanic.lWait();
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