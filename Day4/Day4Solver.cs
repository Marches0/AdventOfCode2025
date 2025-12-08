namespace Day4;

public class Day4Solver
{
    public void Solve(string fileName)
    {
        var grid = PrintGridReader.GetGrid(fileName);

        (int width, int height) = grid.GetDimensions();

        int accessiblePaperCount = 0;
        int initialFoundPaper = 0;

        do
        {
            // Keep testing and removing until we don't remove any paper in that interation,
            // at which point we are done.
            initialFoundPaper = accessiblePaperCount;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    PrintGridContent content = grid.GetGridContent(x, y);
                    if (content == PrintGridContent.Paper && PrintGridAccessibilityCalculator.IsAccessible(x, y, grid))
                    {
                        ++accessiblePaperCount;
                        grid.RemovePaper(x, y);
                    }
                }
            }
        } while (initialFoundPaper != accessiblePaperCount);

        Console.WriteLine(accessiblePaperCount);
    }
}
