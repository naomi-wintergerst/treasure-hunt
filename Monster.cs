using System;
using SplashKitSDK;
using System.Collections.Generic;

public class Monster
{
    public Bitmap monsterBitmap;
    public double X { get; private set; }
    public double Y { get; private set; }
    public Monster(double x, double y)
    {
        X = x;
        Y = y;
       monsterBitmap = new Bitmap("Monster", "resources/images/monster.png");
    }
    public void Draw()
    {

        monsterBitmap.Draw(X, Y);
    }
}