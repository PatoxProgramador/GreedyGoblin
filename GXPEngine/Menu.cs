using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

public class Menu : GameObject
{
    //All the buttons and background from start, gameplay and endScene
    Button button;
    Quit quit;
    Title title;
    BackToMenu backToMenu;
    EndScene endScene;
    EndButton end;

    Level level;
    StopClock time;
    // flag to change the scenes
    bool flag;
    bool finish;
    //sound effects and music
    Sound click;
    Sound music;
    Sound levelMusic;
    Sound scary;
    // the channel for each scene
    SoundChannel movement;
    SoundChannel gameplay;
    SoundChannel ending;

    public Menu() : base()
    {
        // this stay for all the game, just visibility changes
        button = new Button();
        quit = new Quit();
        title = new Title();
        endScene = new EndScene();
        end = new EndButton();
        backToMenu = new BackToMenu();

        AddChild(title);
        AddChild(button);
        AddChild(quit);
        //positioning
        button.x = (game.width - (button.width + 60)) / 2;
        button.y = 380;

        quit.x = 500;
        quit.y = 200;

        title.x = 0;
        title.y = 0;

        click = new Sound("Button.wav", false, false);
        music = new Sound("StartMusic.wav", true, true);
        levelMusic = new Sound("music.wav", true, true);
        scary = new Sound("Ending.wav", true, true);

        finish = false;

        StopClock.countdownValue = 180;

        ShowMenu();

    }

    void Update()
    {
        /*
         if (Input.GetKeyDown(Key.F1))
        {
            Console.WriteLine(  game.GetDiagnostics());
        }
        */

        if (Input.GetMouseButtonDown(0))
        {
            //interactions with every UI button
            if (button.HitTestPoint(Input.mouseX, Input.mouseY) && !flag)
            {
                //start button
                movement.Stop();

                movement = click.Play();

                time = new StopClock();
                AddChild(time);

                StartGame();
                HideMenu();

            }
            else if (backToMenu.HitTestPoint(Input.mouseX, Input.mouseY) && flag)
            {
                //gameplay button
                movement = click.Play();

                DeleteWorld();

                time.Destroy();

                ShowMenu();

            }
            else if (end.HitTestPoint(Input.mouseX, Input.mouseY) && finish)
            {
                //Console.WriteLine("End button clicked");
                //endscene button
                movement = click.Play();

                HideEnd();

                ShowMenu();

            }
            else if (quit.HitTestPoint(Input.mouseX, Input.mouseY) && !flag)
            {
                //get out of game button
                game.Destroy();

            }

        }
        // death loop
        if (Gamer.restart)
        {

            DeleteWorld();

            StartGame();

        }
        //score for every level
        if ((StopClock.countdownValue <= 0 || Level.end) && !finish) // Is this the place to put this value????
        {

            DeleteWorld();

            time.Destroy();

            ShowEnd();

            Gamer.score = 0;

            Level.end = false;

        }

    }
    // link this method with respawn from gamer
    // creates gameplay scene
    void StartGame()
    {

        if (!flag && !finish)
        {

            level = new Level();
            backToMenu = new BackToMenu();

            BackToMenu[] f = FindObjectsOfType<BackToMenu>();
            if (f.Length > 1)
            {

                for (int i = 1; i < f.Length; i++)
                {

                    f[i].Destroy();

                }

            }

            AddChild(level);
            AddChild(backToMenu);

            backToMenu.x = 340;
            backToMenu.y = 520;

            gameplay = levelMusic.Play();

            flag = true;

        }

    }
    //gameplay destruction
    void DeleteWorld()
    {

        level.Destroy();
        backToMenu.Destroy();

        gameplay.Stop();

        flag = false;

    }
    //start scene
    void HideMenu()
    {

        button.visible = false;
        title.visible = false;
        quit.visible = false;

    }

    void ShowMenu()
    {

        StopClock.countdownValue = 180;

        movement = music.Play();

        button.visible = true;
        title.visible = true;
        quit.visible = true;

        flag = false;

    }
    //endscene
    void ShowEnd()
    {

        if (!finish) {

            endScene = new EndScene();
            end = new EndButton();

            AddChild(endScene);
            AddChild(end);

            end.y = 409;

            ending = scary.Play();

            finish = true;

        }

    }
    void HideEnd()
    {

        if (finish)
        {
            //Console.WriteLine("Hiding end");
            end.Destroy();
            endScene.Destroy();

            finish = false;

            ending.Stop();

        }

    }

}