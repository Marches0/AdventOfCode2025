
namespace Day3;

public class Day3Solver
{
    public void Solve(string fileName)
    {
        IEnumerable<BatteryBank> banks = BatteryBankReader.GetBatteryBanks(fileName);
        var joltages = banks.Select(b => JoltageSolver.GetMaxJoltage(b, 12));
        Console.WriteLine(joltages.Sum());
    }
}