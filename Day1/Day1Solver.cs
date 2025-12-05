
namespace Day1
{
    public class Day1Solver
    {
        public int Solve(string file)
        {
            List<DialMovement> movements = DialReader.GetMovements(file);
            Dial dial = new(50);

            int zeroes = 0;

            foreach (DialMovement movement in movements)
            { 
                dial.Move(movement);
                if (dial.CurrentNumber == 0)
                {
                    ++zeroes;
                }
            }

            return zeroes;
        }
    }
}