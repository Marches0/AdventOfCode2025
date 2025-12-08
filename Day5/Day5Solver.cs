

namespace Day5;

public class Day5Solver
{
    public void Solve(string fileName)
    {
        IngredientSituation situation = IngredientReader.Read(fileName);

        List<long> freshCount = situation.IngredientIds
            .Where(i => situation.FreshRanges.Any(r => r.IsFresh(i)))
            .ToList();

        Console.WriteLine(freshCount.Count);
    }
}
