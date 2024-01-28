using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Gamer : Sprite{
    // the player

    //the position where player should be
    int startX;
    int startY;
    //coin amount
    public static int score;
    public static bool almost;
    //movement speed
    float speed = 2;
    //sound effects
    Sound boom;
    SoundChannel channel;
    //respawn indication
    public static bool restart;

    public Gamer(int x, int y, Sound death) : base("Player.png"){
        //Respawn();
        //size
        width = 30;
        height = 30;

        this.x = x;
        this.y = y;

        startX = x;
        startY = y;

        score = 0;
        //death sound
        boom = death;

        restart = false;
        almost = false;
       
    }
    //player movement
    void Update(){

        if (Input.GetKey(Key.LEFT)){

            x -= speed;

        }
        else if (Input.GetKey(Key.RIGHT)){

            x += speed;

        }
        if (Input.GetKey(Key.UP)){

            y -= speed;

        }
        else if (Input.GetKey(Key.DOWN)){

            y += speed;

        }

    }
    //death response
    void Respawn(){

        restart = true;

    }
    //how player reacts if colliding with the walls or coins
    void OnCollision(GameObject other){
        //wall collision
        if(other is Lava || other is Enemy || other is Enemy1){

            channel = boom.Play();

            Respawn();

        }// coin collision
        if (other is Coin){

            Coin coin = other as Coin;
            coin.Pickup();

            score++;

        }

    }
    // coins collected
    public int GetScore() {

        return score;

    }

}