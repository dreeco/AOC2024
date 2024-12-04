namespace AOC2024;

public partial class Day1
{
    public static void Part1()
    {
        var lines = File.ReadAllLines("C:\\Users\\ano\\source\\repos\\AOC2024\\AOC2024\\Day1\\input.txt");
        var left = new List<int>();
        var right = new List<int>();
        foreach(var line in lines)
        {
            var parts = line.Split("   ");
            left.Add(int.Parse(parts [0]));
            right.Add(int.Parse(parts [1]));
        }
        var orderedLeft = left.OrderBy(l => l);
        var orderedRight = right.Order();
        var amount = 0;
        for(var index = 0;index < orderedLeft.Count();index++)
        {
            amount += Math.Abs(orderedLeft.ElementAt(index) - orderedRight.ElementAt(index));
        }

        Console.WriteLine($"Total amount : {amount}");
    }
}