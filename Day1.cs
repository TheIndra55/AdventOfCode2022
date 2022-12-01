class Day1 : IDay
{
    public object Part1(List<string> lines)
    {
        var calories = CalculateCalories(lines);

        return calories.Last();
    }

    public object Part2(List<string> lines)
    {
        var calories = CalculateCalories(lines);
        calories.Reverse();

        return calories.Take(3).Sum();
    }

    private List<int> CalculateCalories(List<string> lines)
    {
        var items = new List<int>();
        var elf = 0;

        items.Add(0);

        foreach (var line in lines)
        {
            if (line == "")
            {
                elf++;
                items.Add(0);
                
                continue;
            }

            items[elf] += int.Parse(line);
        }

        items.Sort();

        return items;
    }
}