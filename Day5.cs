class Day5 : IDay
{
    public object Part1(List<string> lines)
    {
        var stacks = ReadStacks(ref lines);

        // continue with procedures
        foreach (var line in lines)
        {
            var procedure = line.Split(" ");
            int count = int.Parse(procedure[1]), from = int.Parse(procedure[3]), to = int.Parse(procedure[5]);

            for (int i = 0; i < count; i++)
            {
                var crate = stacks[from - 1][0];

                stacks[to - 1].Insert(0, crate);
                stacks[from - 1].RemoveAt(0);
            }
        }

        return string.Join("", stacks.Where(x => x != null).Select(x => x[0]));
    }

    public object Part2(List<string> lines)
    {
        var stacks = ReadStacks(ref lines);

        // continue with procedures
        foreach (var line in lines)
        {
            var procedure = line.Split(" ");
            int count = int.Parse(procedure[1]), from = int.Parse(procedure[3]), to = int.Parse(procedure[5]);

            var crates = stacks[from - 1].Take(count);

            stacks[to - 1].InsertRange(0, crates);
            stacks[from - 1].RemoveRange(0, count);
        }

        return string.Join("", stacks.Where(x => x != null).Select(x => x[0]));
    }

    private IEnumerable<string> Split(string line, int length)
    {
        for (var i = 0; i < line.Length; i += length)
        {
            yield return line.Substring(i, length - 1);
        }
    }

    private List<char>[] ReadStacks(ref List<string> lines)
    {
        var stacks = new List<char>[16];

        // parse the entire mess of stacks
        foreach (var line in lines)
        {
            var crates = Split(line, 4);

            int i = 0;
            foreach (var stack in crates)
            {
                if (stacks[i] == null)
                {
                    stacks[i] = new List<char>();
                }

                if (stack.StartsWith("["))
                {
                    stacks[i].Add(stack[1]);
                }

                i++;
            }

            // until empty line
            if (line == "") break;
        }

        // skip over stacks and seperator and take those lines
        lines = lines.Skip(stacks.Max(x => x?.Count ?? 0) + 2).ToList();

        return stacks;
    }
}