namespace Day1;

internal static class DialReader
{
    public static List<DialMovement> GetMovements(string file)
    {
        return File.ReadAllLines(file)
            .Select(l => new DialMovement()
            {
                Direction = l[0] == 'L'
                    ? DialDirection.Left
                    : DialDirection.Right,
                Clicks = int.Parse(l[1..^0])
            })
            .ToList();
    }
}