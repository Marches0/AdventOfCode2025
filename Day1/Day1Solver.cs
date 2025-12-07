
namespace Day1
{
    public class Day1Solver
    {
        public int Solve(string file)
        {
            List<DialMovement> movements = DialReader.GetMovements(file);
            Dial dial = new(50);

            Console.WriteLine($"Start {dial.CurrentNumber}");
            foreach (DialMovement movement in movements)
            {
                int initialPosition = dial.CurrentNumber;
                dial.Move(movement);
                Console.WriteLine($"{initialPosition,-2} -> {dial.CurrentNumber,2} {movement,-9} - {dial.TouchedZeroCount}");
            }

            return dial.TouchedZeroCount;
        }
    }
}