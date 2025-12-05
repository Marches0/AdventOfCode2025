using System;
using System.Collections.Generic;
using System.Text;

namespace Day1;

internal enum DialDirection
{
    Left = 1,
    Right
};

internal class DialMovement
{
    public required int Clicks { get; set; }
    public required DialDirection Direction { get; set; }
}

internal class Dial
{
    public int CurrentNumber { get; private set; }

    public Dial(int startingNumber)
    {
        CurrentNumber = startingNumber;
    }

    public void Move(DialMovement movement)
    {
        int clicksChange = movement.Direction == DialDirection.Left
            ?  movement.Clicks
            : -movement.Clicks;

        CurrentNumber += clicksChange;


        if (CurrentNumber > 99)
        {

        }
    }
}