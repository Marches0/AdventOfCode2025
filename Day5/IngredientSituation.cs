using System;
using System.Collections.Generic;
using System.Text;

namespace Day5;

internal class IngredientSituation
{
    public required List<IngredientRange> FreshRanges { get; set; }
    public required List<long> IngredientIds { get; set; }
}

internal class IngredientRange(long start, long end)
{
    public long Start { get; } = start;
    public long End { get; } = end;

    public bool IsFresh(long ingredientId)
    {
        return ingredientId >= Start
            && ingredientId <= End;
    }

    public long Size => (End - Start) + 1; // Range is inclusive
}