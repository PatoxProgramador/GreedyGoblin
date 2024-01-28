using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game {

	//Player player;
	//MouseMovement mouse;
	//Gravitonium gravel;
	//Gamer play;
	//Lava lava;
	//Coin coin;
	
	public MyGame() : base(800, 600, false)     // Create a window that's 800x600 and NOT fullscreen
	{

		//player = new Player();
		//mouse = new MouseMovement();
		//gravel = new Gravitonium();
		//play = new Gamer(width/2 + 130,height/2 - 130);
		//lava = new Lava();
		//coin = new Coin();

		//AddChild(play);
		/*
		AddChild(lava);
		AddChild(coin);
		*/
		Menu menu = new Menu();

		AddChild(menu);

	}

	void Update() {
		
	}

	static void Main()                          // Main() is the first method that's called when the program is run
	{

		new MyGame().Start();                   // Create a "MyGame" and start it

	}

}