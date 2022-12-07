class Day7 : IDay
{
    public const int TotalSize = 70000000;
    public const int UpdateSize = 30000000;

    public object Part1(List<string> lines)
    {
        var filesystem = ReadFileSystem(lines);

        var largeFolders = new List<int>();
        Sum(filesystem, largeFolders, 100000);

        return largeFolders.Sum();
    }

    public object Part2(List<string> lines)
    {
        var filesystem = ReadFileSystem(lines);

        var largeFolders = new List<int>();
        
        var used = Sum(filesystem, largeFolders, 0);
        var free = TotalSize - used;
        var needed = UpdateSize - free;

        return largeFolders.Where(x => x > needed).Min();
    }

    private Dictionary<string, object> ReadFileSystem(List<string> lines)
    {
        var cd = string.Empty;
        var filesystem = new Dictionary<string, object>();

        foreach (var line in lines)
        {
            Dictionary<string, object> directory;

            // read command
            if (line[0] == '$')
            {
                var command = line.Substring(2).Split(" ");

                if (command[0] == "cd")
                {
                    var dir = command[1];
                    directory = GetDirectory(filesystem, cd);

                    if (dir == "..")
                    {
                        cd = cd.Substring(0, cd.LastIndexOf("/"));
                    }
                    else if (dir == "/")
                    {
                        cd = "";
                    }
                    else
                    {
                        cd += "/" + dir;

                        if (!directory.ContainsKey(dir))
                        {
                            directory[dir] = new Dictionary<string, object>();
                        }
                    }
                }

                continue;
            }

            // read output
            directory = GetDirectory(filesystem, cd);
            var output = line.Split(" ");

            if (output[0] != "dir")
            {
                directory[output[1]] = int.Parse(output[0]);
            }
        }

        return filesystem;
    }

    private Dictionary<string, object> GetDirectory(Dictionary<string, object> filesystem, string path)
    {
        if (path == string.Empty)
        {
            return filesystem;
        }

        foreach (var directory in path.Split("/", StringSplitOptions.RemoveEmptyEntries))
        {
            filesystem = (Dictionary<string, object>)filesystem[directory];
        }

        return filesystem;
    }

    private int Sum(Dictionary<string, object> filesystem, List<int> largeFolders, int atmost)
    {
        var sum = 0;

        foreach (var entry in filesystem)
        {
            if (entry.Value is int)
            {
                sum += (int)entry.Value;
            }
            else
            {
                var size = Sum((Dictionary<string, object>)entry.Value, largeFolders, atmost);

                if (atmost == 0 || size <= atmost)
                {
                    largeFolders.Add(size);
                }

                sum += size;
            }
        }

        return sum;
    }
}