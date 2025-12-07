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
    public int TouchedZeroCount { get; private set; }
    public int EndedZeroCount { get; private set; }

    public Dial(int startingNumber)
    {
        CurrentNumber = startingNumber;
    }

    public void Move(DialMovement movement)
    {
        // Movements > |100| have the same result as moving Movement mod 100.
        // So do that movement, and process the result, then add
        // to the changes as if we had done those extra 100s.
        int extraRotations = movement.Clicks / 100;
        int realClicks = movement.Clicks % 100;

        int clicksChange = movement.Direction == DialDirection.Left
            ? -realClicks
            : +realClicks;

        // If we were already at 0, then we have already counted
        // that touch, so don't recount it.
        // However! If we start *and* end at 0, then do count it
        // because that means we made a full cycle.
        bool zeroBeforeMovement = CurrentNumber == 0;
        int initialNumber = CurrentNumber;

        CurrentNumber += clicksChange;

        bool looped = false;
        
        // There's probably a formula for this, since having to loop
        // isn't that efficient. But I am lazy.
        while (CurrentNumber < 0 || CurrentNumber > 99)
        {
            looped = true;

            if (CurrentNumber > 99)
            {
                CurrentNumber -= 100; 
            }

            if (CurrentNumber < 0)
            {
                CurrentNumber += 100;
            }

            if (!zeroBeforeMovement)
            {
                ++TouchedZeroCount;
            }

            // But once we turn away, we want to count it again.
            zeroBeforeMovement = false;
        }

        TouchedZeroCount += extraRotations;

        if (CurrentNumber == 0)
        {
            ++EndedZeroCount;

            // We count the touch of zero when we loop, but we still care
            // if we end on it. Only add if we didn't loop though, since that is
            // already accounted for.
            if (!looped)
            {
                ++TouchedZeroCount;
            }
        }
    }
}