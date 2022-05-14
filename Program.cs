using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window treasureHuntWindow = new Window("Treasure Hunt", 500, 500);
        TreasureHunt treasureHunt = new TreasureHunt(treasureHuntWindow);
        while (!treasureHuntWindow.CloseRequested)
        {
            SplashKit.ProcessEvents();
            treasureHunt.HandleInput();
            treasureHuntWindow.Clear(Color.White);
            treasureHunt.Draw();
            treasureHuntWindow.Refresh(60);
            if (treasureHunt.quit)
            {
                treasureHuntWindow.Close();
            }
        }
    }
}
