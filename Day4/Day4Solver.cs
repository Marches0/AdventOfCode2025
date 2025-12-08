namespace Day4;

public class Day4Solver
{
    public void Solve(string fileName)
    {
        var grid = PrintGridReader.GetGrid(fileName);

        (int width, int height) = grid.GetDimensions();
        int accessiblePaperCount = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                PrintGridContent content = grid.GetGridContent(x, y);
                if (content == PrintGridContent.Paper && PrintGridAccessibilityCalculator.IsAccessible(x, y, grid))
                {
                    ++accessiblePaperCount;
                }
            }
        }

        Console.WriteLine(accessiblePaperCount);
    }
}
