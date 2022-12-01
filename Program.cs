using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using System.Reflection;

var command = new RootCommand
{
    new Option<int>("--day", "The day to execute"),
    new Option<int>("--part", "The part of the puzzle"),
    new Option<FileInfo>("--input", "The puzzle input file")
};

command.Handler = CommandHandler.Create<int, int, FileInfo>((day, part, input) => {
    // find the day class
    var types = Assembly.GetExecutingAssembly().GetTypes();
    var days = types.Where(x => typeof(IDay).IsAssignableFrom(x));

    var foundDay = days.FirstOrDefault(x => x.Name == "Day" + day);
    var instance = (IDay)Activator.CreateInstance(foundDay);

    // read input file
    var lines = File.ReadAllLines(input.FullName).ToList();

    object answer = null;
    if (part == 1) answer = instance.Part1(lines);
    if (part == 2) answer = instance.Part2(lines);

    Console.WriteLine("Your puzzle answer is: " + answer);
});

command.Invoke(args);