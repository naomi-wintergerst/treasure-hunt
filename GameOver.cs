using System;
using SplashKitSDK;

public class GameOver
{
    public Font gameOverFont;
    public Window _gameWindow;
    public int highScore = 2000;
    public int playerScore = 0;
    public bool winner = false;

    public GameOver(Window window)
    {
        _gameWindow = window;
        gameOverFont = SplashKit.LoadFont("NanumGothic", "resources/fonts/NanumGothic-Regular.otf");
    }

    public void Draw()
    {
        if (playerScore > highScore)
        {
            SplashKit.DrawTextOnWindow(_gameWindow, "High Score!", Color.Black, gameOverFont, 60, 80, 225);
        }
        if (winner)
        {
            SplashKit.DrawTextOnWindow(_gameWindow, "You win!", Color.DarkGreen, gameOverFont, 60, 80, 175);

        }
        else
        {
            SplashKit.DrawTextOnWindow(_gameWindow, "Game Over!", Color.Red, gameOverFont, 60, 80, 175);

        }
    }
}
