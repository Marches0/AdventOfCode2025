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
    public override string ToString() => $"{Direction} {Clicks}";
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
            ? -movement.Clicks
            : +movement.Clicks;

        CurrentNumber += clicksChange;

        if (CurrentNumber >= 100)
        {
            // Can be multiple times over 99, e.g. at 2000
            // Take off as many 99s as possible to get us back down.
            int over = CurrentNumber / 100;
            CurrentNumber -= over * 100;
        }

        if (CurrentNumber < 0)
        {
            // Need minimum 1 since we need to go back above 0.
            int over = (-CurrentNumber / 100) + 1;

            // Also needs an extra 1 added!
            CurrentNumber += over * 100;
        }

        // These numbers can feed into each other, e.g. adding
        // from < 0 can hit 100, so check each one a second time to make sure
        // it's correct.
        if (CurrentNumber >= 100)
        {
            // Can be multiple times over 99, e.g. at 2000
            // Take off as many 99s as possible to get us back down.
            int over = CurrentNumber / 100;
            CurrentNumber -= over * 100;
        }

        if (CurrentNumber < 0)
        {
            // Need minimum 1 since we need to go back above 0.
            int over = (-CurrentNumber / 100) + 1;

            // Also needs an extra 1 added!
            CurrentNumber += over * 100;
        }
    }
}