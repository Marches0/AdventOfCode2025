namespace Day2;

public class Day2Solver
{
    public void Solve(string file)
    {
        IEnumerable<IdRange> ranges = IdGroupReader.GetRanges(file);
        List<long> invalids = ranges
            .SelectMany(r => r.GetInvalidIds())
            .ToList();

        var sum = invalids.Sum();
        Console.WriteLine(sum);
    }
}
