using System;
using SplashKitSDK;
using System.Collections.Generic;

public class Treasure
{
    public Bitmap treasureBitmap;
    public double X { get; private set; }
    public double Y { get; private set; }
    public Treasure(double x, double y)
    {
        X = x;
        Y = y;
        treasureBitmap = new Bitmap("My treasure", "resources/images/treasure.jpeg");
    }
    public void Draw()
    {

        treasureBitmap.Draw(X, Y);
    }
}