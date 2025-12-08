namespace Day3;

internal class BatteryBank(List<int> batteries)
{
    public List<int> Batteries { get; } = batteries;
}

internal class JoltageSolver
{
    public static int GetMaxJoltage(BatteryBank bank)
    {
        // Make the highest number from the digits given.
        // Must keep the order of the digits in the bank, e.g. 12345 -> 45 is highest, not 54

        // Get the highest digit from all, apart from the last which doesn't matter.
        var batteryPositions = bank.Batteries
            .Select((j, i) => new { Joltage = j, Position = i })
            .ToList();

        var firstDigit = batteryPositions
            .SkipLast(1)
            .MaxBy(p => p.Joltage)!;

        var lastDigit = batteryPositions
            .Skip(firstDigit.Position + 1)
            .MaxBy(p => p.Joltage)!;

        return (firstDigit.Joltage * 10) + lastDigit.Joltage;
    }
}