using GXPEngine;
using GXPEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Enemy : Sprite
{

    float speed = 0.4f;
    //The Enemy
    public Enemy(int x, int y) : base("Enemy.png")
    {

        this.x = x;
        this.y = y;

    }

    void Update()
    {

            GoRight();

    }

    void GoRight()
    {

        x = x + speed;

        if (x <= 64 || x >= 448)
        {

            speed = speed * -1;

        }

    }

}