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
        var score = 0;

        for (var i = 0; i < lines.Count; i++)
        {
            for (var j = 0; j < lines[i].Length; j++)
            {
                CheckVisibility(lines, i, j, out var scene);

                if (scene > score) score = scene;
            }
        }

        return score;
    }

    private bool CheckVisibility(List<string> lines, int x, int y)
    {
        // check edge
        if (x == 0 || y == 0 || x == lines.Count - 1 || y == lines[0].Length - 1)
        {
            return true;
        }

        return CheckVisibility(lines, x, y, out var _);
    }

    private bool CheckVisibility(List<string> lines, int x, int y, out int score)
    {
        var height = lines[x][y];
        var hidden = 0;

        score = 0;
        var trees = 0;

        // up
        for (var i = x - 1; i >= 0; i--)
        {
            trees++;
            if (lines[i][y] >= height) { hidden++; break; }
        }

        score = trees;
        trees = 0;

        // down
        for (var i = x + 1; i < lines.Count; i++)
        {
            trees++;
            if (lines[i][y] >= height) { hidden++; break; }
        }

        score *= trees;
        trees = 0;

        // left
        for (var i = y - 1; i >= 0; i--)
        {
            trees++;
            if (lines[x][i] >= height) { hidden++; break; }
        }

        score *= trees;
        trees = 0;

        // right
        for (var i = y + 1; i < lines[0].Length; i++)
        {
            trees++;
            if (lines[x][i] >= height) { hidden++; break; }
        }

        score *= trees;
        trees = 0;

        return hidden != 4;
    }
}