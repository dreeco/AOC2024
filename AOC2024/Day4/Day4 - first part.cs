

namespace AOC2024;

public partial class Day4
{
    static (int Row, int Col) [] directions = [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)];
    private static HashSet<string> AlreadyAdded = new HashSet<string> ();
    private static HashSet<string> AlreadyAddedDir = new HashSet<string> ();
    public static int total = 0;
    public static void Part1()
    {
        var lines = File.ReadAllLines("C:\\Users\\ano\\source\\repos\\AOC2024\\AOC2024\\Day4\\input.txt");

        ParseInput(lines);
        Console.WriteLine($"Total amount : {total}");
    }

    public static void ParseInput(string [] lines)
    {
        for(var row = 0; row < lines.Length; row++)
        {
            var line = lines [row];
            for(var col = 0;col < line.Length;col++)
            {
                if(lines [row] [col] == 'X')
                {
                    foreach(var dir in directions)
                    {
                        SearchCharInDirection(lines, row, col, dir, 'M');
                    }
                }
            }

        }
    }

    private static void SearchCharInDirection(string [] lines, int row, int col, (int Row, int Col) dir, char currentSearch)
    {
        var currentRow = row + dir.Row;
        var currentCol = col + dir.Col;
        if(currentRow >= lines.Length || currentRow < 0 || currentCol < 0 || currentCol >= lines [row].Length)
            return;

        if(lines [currentRow] [currentCol] == currentSearch)
        {
            char? nextSearch = currentSearch switch
            {
                'M' => 'A',
                'A' => 'S',
                'S' => null,
                _ => throw new NotImplementedException()
            };

            if(nextSearch == null)
            {
                var xrow = currentRow - (3 * dir.Row);
                var xcol = currentCol - (3 * dir.Col);

                var mrow = currentRow - (2 * dir.Row);
                var mcol = currentCol - (2 * dir.Col);

                var arow = currentRow - (1 * dir.Row);
                var acol = currentCol - (1 * dir.Col);

                var x = lines [xrow] [xcol];
                var m = lines [mrow] [mcol];
                var a = lines [arow] [acol];
                Console.WriteLine($"[{currentRow}]\t[{currentCol}]\tFound XMAS : {x}{m}{a}{lines [currentRow] [currentCol]} from direction {dir.Row},{dir.Col}");
                total++;
                if(!AlreadyAdded.Add($"{xrow,5}{xcol,5}{mrow,5}{mcol,5}{arow,5}{acol,5}{currentRow,5}{currentCol,5}"))
                    Console.WriteLine($"Item {xrow,5}{xcol,5}{mrow,5}{mcol,5}{arow,5}{acol,5}{currentRow,5}{currentCol,5} already existing");

                else if(!AlreadyAddedDir.Add($"{currentRow,5}{currentCol,5}{dir.Row,5}{dir.Col,5}"))
                    Console.WriteLine($"Item {xrow,5}{xcol,5}{mrow,5}{mcol,5}{arow,5}{acol,5}{currentRow,5}{currentCol,5} already existing");

                return;
            }

            SearchCharInDirection(lines, currentRow, currentCol, dir, nextSearch.Value);
        }
    }

    private static bool FindSearchCharacterAround(string [] lines, int row, int col, char [] search)
    {

        foreach(var dir in directions)
        {
            var currentRow = row + dir.Row;
            var currentCol = col + dir.Col;
            if(currentRow >= lines.Length || currentRow < 0 || currentCol < 0 || currentCol >= lines [row].Length)
                continue;
            if(search.Contains(lines [currentRow] [currentCol]))
                return true;
        }
        return false;
    }

}