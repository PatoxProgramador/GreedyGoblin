using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

public class StopClock : Canvas
{

    private float countdownTimer;
    public static int countdownValue;
    private float timeScale = 0.001f; // slows down timer

    public StopClock() : base(800, 600)
    {

        countdownTimer = 180f; // Initial countdown time in seconds
        countdownValue = (int)countdownTimer;

    }
    // coin score
    void Update()
    {
        // Update the countdown timer
        if (countdownValue > 0)
        {

            countdownTimer -= Time.deltaTime * timeScale;

        }

        // Update the countdown
        countdownValue = (int)Math.Floor(countdownTimer);

        //displayed text in canvas
        graphics.Clear(Color.Empty);

        DrawText("Time Left: " + countdownValue, 700, 580, "Arial", 7, 0xFFFFFF);

    }
    // the text information
    void DrawText(string text, float x, float y, string fontName, int fontSize, int textColor)
    {

        graphics.DrawString(text, new Font(fontName, fontSize), new SolidBrush(ColorFromHex(textColor)), x, y);

    }
    Color ColorFromHex(int hexValue)
    {

        return Color.FromArgb((hexValue >> 16) & 0xFF, (hexValue >> 8) & 0xFF, hexValue & 0xFF);

    }

}