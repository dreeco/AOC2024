namespace AOC2024;

public partial class Day4
{
    public static void Part2()
    {
        var lines = File.ReadAllLines("C:\\Users\\ano\\source\\repos\\AOC2024\\AOC2024\\Day4\\input.txt");

        ParseInput2(lines);
        Console.WriteLine($"Total amount : {total}");
    }

    public static void ParseInput2(string [] lines)
    {
        for(var row = 0;row < lines.Length;row++)
        {
            var line = lines [row];
            for(var col = 0;col < line.Length;col++)
            {
                if(lines [row] [col] == 'A')
                {
                    var canGoTop = row > 0;
                    var canGoBottom = row < lines.Length - 1;

                    var canGoleft = col > 0;
                    var canGoRight = col < lines [row].Length - 1;

                    char? topLeft = canGoTop && canGoleft ? lines [row - 1] [col - 1] : null;
                    char? topRight = canGoTop && canGoRight ? lines [row - 1] [col + 1] : null;
                    char? bottomLeft = canGoBottom && canGoleft ? lines [row + 1] [col - 1] : null;
                    char? bottomRight = canGoBottom && canGoRight ? lines [row + 1] [col + 1] : null;

                    var antislash = (topLeft == 'M' && bottomRight == 'S') || (topLeft == 'S' && bottomRight == 'M');
                    var slash = (topRight == 'M' && bottomLeft == 'S') || (topRight == 'S' && bottomLeft == 'M');

                    if(antislash && slash)
                    {
                        total++;
                    }
                }
            }
        }
    }
}