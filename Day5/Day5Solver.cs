namespace Day5;

public class Day5Solver
{
    public void Solve(string fileName)
    {
        IngredientSituation situation = IngredientReader.Read(fileName);

        List<IngredientRange> merged = RangeMerger.MergeRanges(situation.FreshRanges);
        var totalFresh = merged.Sum(m => m.Size);

        Console.WriteLine(totalFresh);
    }
}
