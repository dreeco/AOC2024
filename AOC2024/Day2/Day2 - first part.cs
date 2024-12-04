namespace AOC2024;

public partial class Day2
{
    private enum Way
    {
        Unknown,
        Decreasing,
        Increasing
    }

    public static void Part1()
    {
        var lines = File.ReadAllLines("C:\\Users\\ano\\source\\repos\\AOC2024\\AOC2024\\Day2\\input.txt");
        var amount = 0;
        foreach(var line in lines)
        {
            if(IsOk(line))
                amount++;
        }

        Console.WriteLine($"Total amount : {amount}");
    }

    private static bool IsOk(string line)
    {
        var numbers = line.Split(' ').Select(int.Parse);

        var way = Way.Unknown;
        int? previous = null;
        foreach(var current in numbers)
        {
            if(previous == null)
            {
                previous = current;
                continue;
            }
            
            var diff = current - (previous ?? 0);
            if(Math.Abs(diff) > 3 || diff == 0)
                return false;

            var currentWay = diff switch
            {
                < 0 => Way.Decreasing,
                > 0 => Way.Increasing,
                _ => throw new NotImplementedException()
            };

            if(way == Way.Unknown)
                way = currentWay;

            else if(way != currentWay)
                return false;

            previous = current;
        }
        return true;
    }
}