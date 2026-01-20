namespace Dont_Fear_The_Death;

public class GameData
{
    public static void BootInit()
    {
        Mechanic.del();
        Mechanic.sendALotOfWhiteSpaces(10);
        CenterText.WriteCentered(Message.MainMenuTitle);
        Mechanic.sendALotOfWhiteSpaces(6);
        CenterText.WriteCentered(GUI.MainMenuMenu);
    }

    public static void OptionsOpen()
    {
        Mechanic.del();
        Mechanic.sendALotOfWhiteSpaces(32);
        CenterText.WriteCentered(GUI.OptionsMenu);
    }

    public static void VideoSettingsOpen()
    {
        Mechanic.del();
        Mechanic.sendALotOfWhiteSpaces(32);
        CenterText.WriteCentered(GUI.OptionsVideo);
    }
}