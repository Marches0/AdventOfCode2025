namespace Day2;

internal class IdRange(long Start, long End)
{
    public List<long> GetInvalidIds()
    {
        return GetIds()
            .Where(IsInvalid)
            .ToList();
    }

    private bool IsInvalid(long id)
    {
        string idStr = id.ToString();

        // Invalid if the ID has the same pattern multiple times
        // e.g. 123123 (123, 123)
        //      565656 (56, 56, 56)
        return GetSequenceSizes(id)
            .Select(size =>
            {
                List<int> parts = idStr
                    .Chunk(size)
                    .Select(cs => int.Parse(new string(cs.ToArray())))
                    .ToList();

                return parts.All(p => p == parts[0]);
            })
            .Any(v => v == true);
    }

    private IEnumerable<int> GetSequenceSizes(long id)
    {
        // Just the divisors of the length of the ID.
        int digitCount = (int)Math.Floor(Math.Log10(id)) + 1;

        // I'm sure there is a better way to do this.
        for (int i = 1; i < 1 + digitCount / 2; i++)
        {
            if (digitCount % i == 0)
            {
                yield return i;
            }
        }
    }

    private IEnumerable<long> GetIds()
    {
        for (long i = Start; i <= End; i++)
        {
            yield return i;
        }
    }
}