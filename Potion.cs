using System;
using SplashKitSDK;

public class Potion
{
    public Bitmap potionBitmap;
    public double X { get; private set; }
    public double Y { get; private set; }
    public Potion(double x, double y)
    {
        X = x;
        Y = y;
        potionBitmap = new Bitmap("potion", "resources/images/potion.png");
    }
    public void Draw()
    {

        potionBitmap.Draw(X, Y);
    }
}