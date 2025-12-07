using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Day2;

internal class IdRange(long Start, long End)
{
    public List<long> GetInvalidIds()
    {
        return GetIds()
            .Where(i => !IsValid(i))
            .ToList();
    }

    private bool IsValid(long id)
    {
        // Invalid if:
        //  the ID is the same pattern twice.
        // e.g. 123123 invalid

        int digitCount = (int)Math.Floor(Math.Log10(id)) + 1;
        if (digitCount % 2 == 1)
        {
            // If it has an odd number of digits, it can't be repeated - so it is valid.
            return true;
        }

        string numString = id.ToString();
        int p1 = int.Parse(numString[..((int)digitCount / 2)]);
        int p2 = int.Parse(numString[((int)digitCount / 2)..]);

        return p1 != p2;
    }

    private IEnumerable<long> GetIds()
    {
        for (long i = Start; i <= End; i++)
        {
            yield return i;
        }
    }
}