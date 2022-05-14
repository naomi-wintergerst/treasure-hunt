using System;
using SplashKitSDK;

public class GameOver
{
    public Font gameOverFont;
    public Window _gameWindow;
    public int highScore = 3000;
    public int playerScore=0;

    public GameOver(Window window)
    {
        _gameWindow = window;
        gameOverFont = SplashKit.LoadFont("NanumGothic", "resources/fonts/NanumGothic-Regular.otf");
    }

    public void Draw()
    {
        SplashKit.DrawTextOnWindow(_gameWindow, "Game Over!", Color.Red, gameOverFont, 60, 80, 175);
        if (playerScore > highScore)
        {
        SplashKit.DrawTextOnWindow(_gameWindow, "High Score!", Color.Black, gameOverFont, 60, 80, 225);
        }

    }
}
