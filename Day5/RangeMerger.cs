using System;
using System.Collections.Generic;
using System.Text;

namespace Day5;

internal class RangeMerger
{
    public static List<IngredientRange> MergeRanges(List<IngredientRange> candidates)
    {
        // If the start and end overlap, then we can join the ranges.
        List<IngredientRange?> sorted = candidates
            .OrderBy(c => c.Start)
            .ToList();

        // Since they are ordered, we can just go from start to back and check in series.
        for (int i = 0; i < sorted.Count - 1; i++)
        {
            IngredientRange? current = sorted[i];
            if (current == null) continue; // This one has been merged into another already.

            for (int j = i + 1; j < sorted.Count; j++)
            {
                IngredientRange? next = sorted[j];
                if (next == null) continue;

                if (Overlap(current, next))
                {
                    // No guarantee that the second one actually ends after this one,
                    // so use whichever ends last.
                    current = new IngredientRange(current.Start, Math.Max(current.End, next.End));
                    sorted[j] = null; // No longer considered.
                }
                else
                {
                    break; // If we didn't match on one now, we won't get one later, since it's ordered.
                }
            }

            sorted[i] = current;
        }

        return sorted.Where(r => r != null).ToList()!;
    }

    private static bool Overlap(IngredientRange a, IngredientRange b)
    {
        // 10-20 vs 15-25
        return a.Start <= b.End
            && a.End >= b.Start;
    }
}