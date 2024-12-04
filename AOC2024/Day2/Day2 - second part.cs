namespace AOC2024;

public partial class Day2
{
    public static void Part2()
    {
        var lines = File.ReadAllLines("C:\\Users\\ano\\source\\repos\\AOC2024\\AOC2024\\Day2\\input.txt");
        var amount = 0;
        foreach(var line in lines)
        {
            var numbers = line.Split(' ').Select(int.Parse).ToList();
            if(IsOk2(numbers))
                amount++;
            else {
                for(var i = 0;i < numbers.Count;i++) {
                    var newNumbers = numbers.Where((int value, int index) => index != i);
                    if(IsOk2(newNumbers))
                    {
                        amount++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"Total amount : {amount}");
    }

    private static bool IsOk2(IEnumerable<int> numbers)
    {
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