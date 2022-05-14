using System;
using SplashKitSDK;
using System.Collections.Generic;

public class Door
{
    // delegates
    public delegate void Clicked();
    // properties
    public double X { get; private set; }
    public double Y { get; private set; }
    private Bitmap doorBitmap;
    private Clicked clicked;
    public Door(double x, double y, ref Clicked clickedHandler)
    {
        X = x;
        Y = y;
        doorBitmap = new Bitmap("door1", "resources/images/door.jpeg");
        clicked = clickedHandler;
    }
    public void Draw()
    {
        doorBitmap.Draw(X, Y);
    }
    public void HandleInput()
    {
        float mouseX = SplashKit.MouseX();
        float mouseY = SplashKit.MouseY();

        if (SplashKit.MouseClicked(MouseButton.LeftButton) && mouseX > X && mouseX < X + 150 && mouseY >Y && mouseY<Y +150)
        {
            clicked();
        };

    }

}