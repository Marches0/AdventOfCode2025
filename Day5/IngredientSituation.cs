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
    private readonly long _start = start;
    private readonly long _end = end;

    public bool IsFresh(long ingredientId)
    {
        return ingredientId >= _start
            && ingredientId <= _end;
    }
}