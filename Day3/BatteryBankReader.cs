using System;
using System.Collections.Generic;
using System.Text;

namespace Day3;

internal static class BatteryBankReader
{
    public static IEnumerable<BatteryBank> GetBatteryBanks(string fileName)
    {
        return File.ReadAllLines(fileName)
            .Select(l => l.Select(b => (int)char.GetNumericValue(b)))
            .Select(r => new BatteryBank(r.ToList()))
            /*.ToList()*/;
    }
}