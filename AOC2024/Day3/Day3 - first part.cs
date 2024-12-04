using System.Text.RegularExpressions;

namespace AOC2024;

public partial class Day3
{

    public static void Part1()
    {
        var lines = File.ReadAllLines("C:\\Users\\ano\\source\\repos\\AOC2024\\AOC2024\\Day3\\input.txt");

        var amount = 0;

        foreach(var line in lines)
        {
            var matches = Regex.Matches(line, @"mul\((\d{1,3}),(\d{1,3})\)");
            foreach(Match match in matches)
            {
                amount += int.Parse(match.Groups [1].Value) * int.Parse(match.Groups [2].Value);
            }
        
        }
        Console.WriteLine($"Total amount : {amount}");
    }

}