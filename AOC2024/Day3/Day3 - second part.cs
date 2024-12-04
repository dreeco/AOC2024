using System.Text.RegularExpressions;

namespace AOC2024;

public partial class Day3
{
    public static void Part2()
    {
        var lines = File.ReadAllLines("C:\\Users\\ano\\source\\repos\\AOC2024\\AOC2024\\Day3\\input.txt");

        var amount = 0;
        var enabled = true;
        foreach(var line in lines)
        {
            var matches = Regex.Matches(line, @"((mul)\((\d{1,3}),(\d{1,3})\))|((do)\(\))|((don't)\(\))");
            foreach(Match match in matches)
            {
                var v = match.Groups [0].Value;

                if(v.StartsWith("mul") && enabled)
                    amount += int.Parse(match.Groups [3].Value) * int.Parse(match.Groups [4].Value);
                if(v.StartsWith("don"))
                    enabled = false;
                else if(v.StartsWith("do"))
                    enabled = true;
            }
        }
        Console.WriteLine($"Total amount : {amount}");
    }
}