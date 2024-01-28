using GXPEngine;
using GXPEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Enemy1 : Sprite
{

    float speed = -0.4f;
    //The Enemy
    public Enemy1(int x, int y) : base("Enemy.png")
    {

        this.x = x;
        this.y = y;

    }

    void Update()
    {

        GoUp();

    }

    void GoUp()
    {

        y = y + speed;

        if (y <= 64 || y >= 448)
        {

            speed = speed * -1;

        }

    }

}