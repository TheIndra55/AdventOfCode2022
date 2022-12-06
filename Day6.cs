class Day6 : IDay
{
    public object Part1(List<string> lines)
    {
        var line = lines[0];

        for (int i = 3; i < line.Length; i++)
        {
            var last = line.Skip(i - 3).Take(4);

            if (last.GroupBy(x => x).All(x => x.Count() == 1))
            {
                return i + 1;
            }
        }

        return null;
    }

    public object Part2(List<string> lines)
    {
        var line = lines[0];

        for (int i = 14; i < line.Length; i++)
        {
            var last = line.Skip(i - 13).Take(14);

            if (last.GroupBy(x => x).All(x => x.Count() == 1))
            {
                return i + 1;
            }
        }

        return null;
    }
}