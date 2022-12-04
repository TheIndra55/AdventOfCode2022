class Day4 : IDay
{
    public object Part1(List<string> lines)
    {
        var jobs = new List<(int, int)[]>();

        foreach (var line in lines)
        {
            var pairs = line.Split(",").Select(x => GetRange(x)).ToArray();

            jobs.Add(pairs);
        }

        return jobs.Where(x => IsOverlap(x)).Count();
    }

    public object Part2(List<string> lines)
    {
        var jobs = new List<(int, int)[]>();

        foreach (var line in lines)
        {
            var pairs = line.Split(",").Select(x => GetRange(x)).ToArray();

            jobs.Add(pairs);
        }

        return jobs.Where(x => IsOverlap(x) || IsOverlapAll(x)).Count();
    }

    private (int, int) GetRange(string range)
    {
        var sections = range.Split("-");
        return (int.Parse(sections[0]), int.Parse(sections[1]));
    }

    private bool IsOverlap((int, int)[] pairs)
    {
        return
            (pairs[0].Item1 >= pairs[1].Item1 && pairs[0].Item2 <= pairs[1].Item2)
            ||
            (pairs[1].Item1 >= pairs[0].Item1 && pairs[1].Item2 <= pairs[0].Item2);
    }

    private bool IsOverlapAll((int, int)[] pairs)
    {
        var range2 = Range(pairs[1].Item1, pairs[1].Item2);
        return Range(pairs[0].Item1, pairs[0].Item2).Any(x => range2.Contains(x));
    }

    private IEnumerable<int> Range(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            yield return i;
        }
    }
}