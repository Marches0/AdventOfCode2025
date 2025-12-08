using System;
using System.Collections.Generic;
using System.Text;

namespace Day4;

internal class PrintGridAccessibilityCalculator
{
    public static bool IsAccessible(int x, int y, PrintGrid grid)
    {
        // Must be surrounded by fewer than four rolls of paper in the directly
        // neighbouring eight tiles
        int paperNeighbours = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                // This is the square we are checking accessibility for,
                // it is not considered.
                if (i == 0 && j == 0) continue;

                if (grid.GetGridContent(x + i, y + j) == PrintGridContent.Paper)
                {
                    ++paperNeighbours;
                }
            }
        }

        return paperNeighbours < 4;
    }
}