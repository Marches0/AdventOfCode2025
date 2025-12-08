using System;
using System.Collections.Generic;
using System.Text;

namespace Day5;

internal class IngredientReader
{
    public static IngredientSituation Read(string fileName)
    {
        List<IngredientRange> freshRanges = new();
        List<long> ingredientIds = new();

        Action<string> processor = (l) =>
        {
            if (string.IsNullOrWhiteSpace(l))
            {
                processor = (l) =>
                {
                    ingredientIds.Add(long.Parse(l));
                };
                return;
            }

            var parts = l.Split('-');
            freshRanges.Add(new IngredientRange(long.Parse(parts[0]), long.Parse(parts[1])));
        };


        foreach (var line in File.ReadAllLines(fileName))
        {
            processor(line);
        }

        return new()
        {
            FreshRanges = freshRanges,
            IngredientIds = ingredientIds
        };
    }
}