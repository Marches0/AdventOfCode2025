using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2;

internal static class IdGroupReader
{
    public static IEnumerable<IdRange> GetRanges(string file)
    {
        return File.ReadAllText(file)
            .Split(',')
            .Select(r =>
            {
                string[] parts = r.Split('-');
                return new IdRange(long.Parse(parts[0]), long.Parse(parts[1]));
            });
    }
}