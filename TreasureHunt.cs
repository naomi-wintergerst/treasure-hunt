using System;
using SplashKitSDK;
using System.Collections.Generic;

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

    public List<int> treasureDoorList; 

    public int score = 0;
    public int currentRoom; 

    public Potion potion; 
    public enum GameState
    {
        Room,
        Monster,
        Treasure,
        Potion, 
        GameOver
    };
    public GameState gameState;

    public TreasureHunt(Window gamewindow)
    {
        gameOver = new GameOver(gamewindow);
        treasure = new Treasure(137, 137);
        monster = new Monster(75, 75);
        potion = new Potion(137, 137);
        gameState = GameState.Room;
        myScoreFont = SplashKit.LoadFont("NanumGothic", "resources/fonts/NanumGothic-Regular.otf");

        _LivesBitmap = new Bitmap("My Lives", "resources/images/heart.png");//creates bitmap for hearts/lives
        _playerLives = 3;
        Door.Clicked clickedHandler = new Door.Clicked(DoorClicked);
        // doorBitmap = new Bitmap("door1", "resources/images/door.jpeg");
        door1 = new Door(0, 150, ref clickedHandler, 1);
        door2 = new Door(175,175, ref clickedHandler, 2);
        door3 = new Door(350, 150, ref clickedHandler, 3);
        _gameWindow = gamewindow;

        currentRoom = 0; 

        treasureDoorList = new List<int>();
        treasureDoorList.Add(1);
        treasureDoorList.Add(2);
        treasureDoorList.Add(3);
        treasureDoorList.Add(1);
        treasureDoorList.Add(3);
        treasureDoorList.Add(2);
        treasureDoorList.Add(1);
        treasureDoorList.Add(1);
        treasureDoorList.Add(3);
        treasureDoorList.Add(2);








    }
    public void DoorClicked(int doorNumber)
    {
        int treasureDoor = treasureDoorList[currentRoom];
        if (currentRoom == 4 && doorNumber ==treasureDoor){
            _playerLives= _playerLives +1; 
            currentRoom = currentRoom+1; 
            gameState = GameState.Potion;
        }
        else if (doorNumber == treasureDoor)
        {
            currentRoom = currentRoom +1; 
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
        if (currentRoom == treasureDoorList.Count)
        {
            gameState = GameState.GameOver;
            gameOver.playerScore = score; 
            gameOver.winner = true; 
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
            case GameState.Potion:
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
            case GameState.Potion:
                potion.Draw();
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