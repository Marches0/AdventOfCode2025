using System;
using System.Collections.Generic;
using System.Text;

namespace Day4;

internal class PrintGrid(List<List<PrintGridContent>> gridContent)
{
    private readonly List<List<PrintGridContent>> _gridContent = gridContent;

    public PrintGridContent GetGridContent(int x, int y)
    {
        if (x < 0 || y < 0)
        {
            // out of bounds can be considered as empty
            return PrintGridContent.Empty;
        }

        if (y >= _gridContent.Count)
        {
            return PrintGridContent.Empty;
        }

        List<PrintGridContent> row = _gridContent[y];
        if (x >= row.Count)
        {
            return PrintGridContent.Empty;
        }

        return row[x];
    }

    // Assumes rectangle
    public (int width, int height) GetDimensions()
    {
        return (_gridContent[0].Count, _gridContent.Count);
    }
}

internal enum PrintGridContent
{
    Empty = 1,
    Paper = 2
}