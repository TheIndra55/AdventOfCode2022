class Day8 : IDay
{
    public object Part1(List<string> lines)
    {
        var trees = 0;

        for (var i = 0; i < lines.Count; i++)
        {
            for (var j = 0; j < lines[i].Length; j++)
            {
                if (CheckVisibility(lines, i, j))
                {
                    trees++;
                }
            }
        }

        return trees;
    }

    public object Part2(List<string> lines)
    {
        return null;
    }
    
    /**
            y----
        x
        |
        |

    */

    bool CheckVisibility(List<string> lines, int x, int y)
    {
        // check edge
        if (x == 0 || y == 0 || x == lines.Count - 1 || y == lines[0].Length - 1)
        {
            return true;
        }

        var height = lines[x][y];
        var hidden = 0;

        // up
        for (int i = x - 1; i >= 0; i--)
        {
            if (lines[i][y] >= height) { hidden++; break; }
        }

        // down
        for (int i = x + 1; i < lines.Count; i++)
        {
            if (lines[i][y] >= height) { hidden++; break; }
        }

        // left
        for (int i = y - 1; i >= 0; i--)
        {
            if (lines[x][i] >= height) { hidden++; break; }
        }

        // right
        for (int i = y + 1; i < lines[0].Length; i++)
        {
            if (lines[x][i] >= height) { hidden++; break; }
        }

        return hidden != 4;
    }
}