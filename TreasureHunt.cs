using System;
using SplashKitSDK;

public class TreasureHunt
{
    public bool quit = false;
    private Window _gameWindow;
    private Bitmap _LivesBitmap;
    private Font myScoreFont;
    public int _playerLives { get; private set; }
    public Treasure treasure;

    public GameOver gameOver;
    public Monster monster;
    public Door door1;
    public Door door2;
    public Door door3;
    public int _score { get; private set; }

    public int score = 0;
    public enum GameState
    {
        Room,
        Monster,
        Treasure,
        GameOver
    };
    public GameState gameState;

    public TreasureHunt(Window gamewindow)
    {
        gameOver = new GameOver(gamewindow);
        treasure = new Treasure(137, 137);
        monster = new Monster(75, 75);
        gameState = GameState.Room;
        myScoreFont = SplashKit.LoadFont("NanumGothic", "resources/fonts/NanumGothic-Regular.otf");

        _LivesBitmap = new Bitmap("My Lives", "resources/images/heart.png");//creates bitmap for hearts/lives
        _playerLives = 3;
        Door.Clicked clickedHandler = new Door.Clicked(DoorClicked);
        // doorBitmap = new Bitmap("door1", "resources/images/door.jpeg");
        door1 = new Door(350, 150, ref clickedHandler);
        door2 = new Door(0, 150, ref clickedHandler);
        door3 = new Door(175,175, ref clickedHandler);
        _gameWindow = gamewindow;
    }
    public void DoorClicked()
    {
        float dice = SplashKit.Rnd();
        if (dice > 0.5)
        {
            score = score + 5 + Convert.ToInt32(500.0 * SplashKit.Rnd());
            //code for score on screen
            gameState = GameState.Treasure;
        }
        else
        {
            _playerLives = _playerLives - 1;
            gameState = GameState.Monster;
            //code for monster and loosing life 
        }
        if (_playerLives == 0)
        {
            gameState = GameState.GameOver;
            gameOver.playerScore = score; 
        }
    }

    public void HandleInput()
    {
        switch (gameState)
        {
            case GameState.Room:
                door1.HandleInput();
                door2.HandleInput();
                door3.HandleInput();
                break;
            case GameState.Treasure:
            case GameState.Monster:
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    gameState = GameState.Room;
                }
                break;
            case GameState.GameOver:
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    quit = true; 
                }
            break;

        }

    }
    public void Draw()
    {

        SplashKit.DrawTextOnWindow(_gameWindow, score.ToString(), Color.Black, myScoreFont, 30, 10, 10);
        //draw lives on screen 
        for (int i = 0; i < _playerLives; i++)
        {
            _LivesBitmap.Draw(400 + i * 20, 10);
        }

        switch (gameState)
        {
            case GameState.Room:
                door1.Draw();
                door2.Draw();
                door3.Draw();
                break;
            case GameState.Treasure:
                treasure.Draw();
                break;
            case GameState.Monster:
                monster.Draw();
                break;
            case GameState.GameOver:
                gameOver.Draw();
                break;
        }


    }

    public void setLife(int lives)
    {
        _playerLives = lives;
    }
 
}