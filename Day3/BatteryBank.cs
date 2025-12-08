namespace Day3;

internal class BatteryBank(List<int> batteries)
{
    public List<int> Batteries { get; } = batteries;
}

internal class JoltageSolver
{
    public static long GetMaxJoltage(BatteryBank bank, int digitCount)
    {
        // Make the highest number from the digits given.
        // Must keep the order of the digits in the bank, e.g. 12345 -> 45 is highest, not 54
        var batteryPositions = bank.Batteries
            .Select((j, i) => new { Joltage = j, Position = i })
            .ToList();

        // Get the highest digit from all, apart from the last which doesn't matter.
        List<int> digits = new List<int>(digitCount);
        int bankPosition = 0;

        for (int i = 0; i < digitCount; i++)
        {
            // We always want the highest number as early as possible,
            // but also the number with the most digits.
            // e.g. in a 2 digit number, we cannot start with the last number - because then we make a one digit number, instead of two.
            //      in a 3 digit number, we cannot start with the last two numbers because then we make a two/one digit number, instead of three.
            int reservedEndDigits = digitCount - digits.Count - 1;

            // We can greedily take numbers because the local optimum is the global optimum, as the number we choose always contributes
            // the most it can.
            var bestDigit = batteryPositions
                .SkipLast(reservedEndDigits)
                .Skip(bankPosition)
                .MaxBy(b => b.Joltage)!;

            bankPosition = bestDigit.Position + 1;
            digits.Add(bestDigit.Joltage);
        }

        
        // Multiply each digit by 10^pos so you get their proper position in the number.
        // Reversing makes the logic easier since we don't have to subtract from the total.
        return digits
            .Reverse<int>()
            .Select((d, i) => (d, i))
            .Aggregate(0L, (total, x) => total + (x.d * (long)Math.Pow(10, x.i)));
    }
}