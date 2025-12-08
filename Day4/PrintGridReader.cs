using System;
using System.Collections.Generic;
using System.Text;

namespace Day4;

internal class PrintGridReader
{
    public static PrintGrid GetGrid(string fileName)
    {
        var bits = File.ReadAllLines(fileName)
            .Select(l => l.Select(GetGridContent).ToList())
            .ToList();

        return new PrintGrid(bits);
    }

    private static PrintGridContent GetGridContent(char content)
    {
        return content switch
        {
            '@' => PrintGridContent.Paper,
            '.' => PrintGridContent.Empty,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}