using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

public class Level : GameObject
{

    bool second;

    public static bool end;

    public static int max;
    //level block sizes
    const int WIDTH = 12;
    const int HEIGHT = 9;
    const int SPACING = 64;

    int tile;

    int repeat;
    // sound effects
    Sound death;
    // level design
    int[,] level1 = new int[HEIGHT, WIDTH]{

        { 2,2,2,2,2,2,2,2,2,2,2,2},
        { 2,0,0,2,1,0,1,2,0,0,1,2},
        { 2,1,0,2,0,0,2,2,0,2,2,2},
        { 2,2,1,2,0,2,0,3,0,2,1,2},
        { 2,1,0,0,0,0,0,0,0,0,0,2},
        { 2,2,1,2,0,2,1,2,0,2,0,2},
        { 2,0,0,2,0,0,2,2,0,2,0,2},
        { 2,1,0,0,0,0,1,2,1,2,1,2},
        { 2,2,2,2,2,2,2,2,2,2,2,2}

    };
    int[,] level2 = new int[HEIGHT, WIDTH]{

        { 2,2,2,2,2,2,2,2,2,2,2,2},
        { 2,1,0,2,1,0,1,2,0,0,3,2},
        { 2,2,0,2,0,0,2,2,0,2,2,2},
        { 2,4,0,0,0,0,0,0,0,2,1,2},
        { 2,0,2,1,2,0,2,2,0,0,0,2},
        { 2,0,0,2,0,0,0,2,0,2,0,2},
        { 2,0,2,0,2,0,1,2,0,2,0,2},
        { 2,1,0,0,0,0,0,2,5,2,1,2},
        { 2,2,2,2,2,2,2,2,2,2,2,2}


    };

    public Level()
    {

        second = false;

        end = false;

        repeat = 0;

        death = new Sound("Explosion.wav", false, false);

        SetupLevel();

    }
    // creates the blocks of the level
    void SetupLevel()
    {

        for (int j = 0; j < HEIGHT; j++)
        {

            for (int i = 0; i < WIDTH; i++)
            {

                if (!second)
                {

                    max = 13;

                    tile = level1[j, i];

                }
                else if (second)
                {

                    max = 8;

                    tile = level2[j, i];

                }
              


                CreateTile(i, j, tile); // Ideally: here you count and decide what the target should be... (not hard coded)

            }

        }

    }
    //specifies the tiles created
    void CreateTile(int i, int j, int tile)
    {

        switch (tile)
        {

            case 1:

                Coin coin = new Coin(i * SPACING, j * SPACING);

                AddChild(coin);

                break;

            case 2:

                Lava lava = new Lava(i * SPACING, j * SPACING);

                AddChild(lava);

                break;

            case 3:

                Gamer play = new Gamer(i * SPACING, j * SPACING, death);

                AddChild(play);

                    HUD hud = new HUD(play);

                    AddChild(hud);

                break;

            case 4:

                Enemy lep = new Enemy(i * SPACING, j * SPACING);

                AddChild(lep);

                break;

            case 5:

                Enemy1 lep1 = new Enemy1(i * SPACING, j * SPACING);

                AddChild(lep1);

                break;

        }

    }
    void Update()
    {

        if (Gamer.score == max && !second)
        {

            second = true;

            LvlDestroy();

            SetupLevel();

            Gamer.score = 0;

        }
        else if (Gamer.score == max && second)
        {

            second = false;

            LvlDestroy();

            SetupLevel();

            end = true;

        }
      
    }
        void LvlDestroy()
        {

                HUD[] trash = FindObjectsOfType<HUD>();

                foreach (HUD a in trash)
                {

                    a.Destroy();

                }

            Enemy[] lep = FindObjectsOfType<Enemy>();
            Enemy1[] lep1 = FindObjectsOfType<Enemy1>();

            foreach (Enemy a in lep)
            {

                a.Destroy();

            }
            foreach (Enemy1 a in lep1)
            {

                a.Destroy();

            }

            Lava[] trash2 = FindObjectsOfType<Lava>();
            Gamer[] trash3 = FindObjectsOfType<Gamer>();

            foreach (Lava a in trash2)
            {

                a.Destroy();

            }
            foreach (Gamer a in trash3)
            {

                a.Destroy();

            }

        }

    }