class Day3 : IDay
{
    public object Part1(List<string> lines)
    {
        var items = new List<char>();

        foreach (var line in lines)
        {
            var compartment1 = line.Substring(0, line.Length / 2).ToCharArray();
            var compartment2 = line.Substring(line.Length / 2).ToCharArray();

            var share = compartment1
                .Where(x => compartment2.Contains(x))
                .GroupBy(x => x)
                .Select(x => x.First());

            items.AddRange(share);
        }

        return items.Sum(x => char.IsLower(x) ? x - 'a' + 1 : x - 'A' + 27);
    }

    public object Part2(List<string> lines)
    {
        var items = new List<char>();
        var rucksacks = new List<char[]>();

        var i = 0;
        foreach (var line in lines)
        {
            rucksacks.Add(line.ToCharArray());
            i++;

            if (i % 3 == 0)
            {
                var share = rucksacks[0]
                    .Where(x => rucksacks.All(y => y.Contains(x)))
                    .GroupBy(x => x)
                    .Select(x => x.First());

                items.AddRange(share);

                rucksacks.Clear();
            }
        }

        return items.Sum(x => char.IsLower(x) ? x - 'a' + 1 : x - 'A' + 27);
    }
}