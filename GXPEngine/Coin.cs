using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Coin : Sprite{
    //the coins to be collected
    //sound coin makes
    Sound richer;

    public Coin(int x, int y) : base("Coin.png"){
        //position being placed
        this.x = x;
        this.y = y;

        richer = new Sound("coin.wav", false, false);

    }
    //action of coin being grabbed
    public void Pickup(){

        richer.Play();
        LateDestroy();

    }

}