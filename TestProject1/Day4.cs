namespace TestProject
{
    public class Day4
    {
        [Fact]
        public void TestPartOneSampleData()
        {
            var arr = @"MMMSXXMASM
        MSAMXMSMSA
        AMXSXMAAMM
        MSAMASMSMX
        XMASAMXAMM
        XXAMMXXAMA
        SMSMSASXSS
        SAXAMASAAA
        MAMMMXMMMM
        MXMXAXMASX".Split('\n').Select(x => x.Trim()).ToArray();

            AOC2024.Day4.ParseInput(arr);

            Assert.Equal(18, AOC2024.Day4.total);
        }
    }
}