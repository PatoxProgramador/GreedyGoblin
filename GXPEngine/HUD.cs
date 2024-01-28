using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

public class HUD : Canvas {
    //score HUD related to player
    private Gamer player;

    public HUD(Gamer play) : base(800,600){

        player = play;

    }
    // coin score
    void Update()
    {

        //displayed text in canvas
        graphics.Clear(Color.Empty);
        
        DrawText("Score: " + player.GetScore() + "/" + Level.max, 0, 580, "Arial", 7, 0xFFFFFF);

    }
    // the text information
    void DrawText(string text, float x, float y, string fontName, int fontSize, int textColor)
    {

        graphics.DrawString(text, new Font(fontName, fontSize), new SolidBrush(ColorFromHex(textColor)), x, y);

    }
    Color ColorFromHex(int hexValue)
    {

        return Color.FromArgb((hexValue >> 16) & 0xFF,(hexValue >> 8) & 0xFF, hexValue & 0xFF);

    }

}