namespace Day_04 
{
    class Program
    {
        private static readonly List<(int row, int col)> Directions =
        [
            (-1, -1),
            (-1,  0),
            (-1,  1),
            ( 0, -1),
            ( 0,  1),
            ( 1, -1),
            ( 1,  0),
            ( 1,  1)
        ];
        
        public static void Main()
        {
            var input = File.ReadAllLines("../Day-04/Input/main.txt").Select(x => x.ToCharArray()).ToArray();
            
            int rowCount = input.Length;
            int colCount = input.First().Length;
            
            var barrels = ParseInput(input, rowCount, colCount);
            
            Console.Write("Part one: ");
            Console.WriteLine(PartOne(barrels, rowCount, colCount));
            
            Console.Write("Part two: ");
            Console.WriteLine(PartTwo(barrels, rowCount, colCount));
        }
        
        private static HashSet<(int row, int col)> ParseInput(char[][] input, int rowCount, int colCount)
        {
            var set = new HashSet<(int row, int col)>();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (input[i][j] == '@')
                    {
                        set.Add((i, j));
                    }
                }
            }

            return set;
        }
        
        private static int PartOne(HashSet<(int row, int col)> barrels, int rowCount, int colCount)
        {
            int result = 0;

            foreach (var barrel in barrels)
            {
                if (CountSurroundingPaper(barrels, barrel, rowCount, colCount) < 4)
                {
                    result++;
                }
            }
            
            return result;
        }

        private static int PartTwo(HashSet<(int row, int col)> barrels, int rowCount, int colCount)
        {
            int result = 0;
            bool barrelsFound = true;

            while (barrelsFound)
            {
                var removedBarrels = new HashSet<(int row, int col)>();

                foreach (var barrel in barrels)
                {
                    if (CountSurroundingPaper(barrels, barrel, rowCount, colCount) < 4)
                    {
                        result++;
                        removedBarrels.Add(barrel);
                    }
                }
                
                if (removedBarrels.Count == 0)
                {
                    barrelsFound = false;
                }
                else
                {
                    barrels = RemoveBarrels(barrels, removedBarrels);
                }
            }
            
            return result;
        }
        
        private static int CountSurroundingPaper(HashSet<(int row, int col)> barrels, (int row, int col) pos, int rowCount, int colCount)
        {
            int result = 0;

            foreach (var direction in Directions)
            {
                (int row, int col) newPos = (pos.row + direction.row, pos.col + direction.col);
                if (!OutOfBounds(newPos, colCount, rowCount))
                {
                    if (CheckPaper(barrels, newPos))
                    {
                        result++;
                    };
                }
            }
            
            return result;
        }

        private static bool CheckPaper(HashSet<(int row, int col)> barrels, (int row, int col) pos)
        {
            return barrels.Contains(pos);
        }

        private static bool OutOfBounds((int row, int col) pos, int rowCount, int colCount)
        {
            return (pos.col < 0 || pos.col >= colCount || pos.row < 0 || pos.row >= rowCount);
        }

        private static HashSet<(int row, int col)> RemoveBarrels(HashSet<(int row, int col)> barrels,
            HashSet<(int row, int col)> removedBarrels)
        {
            foreach (var removedBarrel in removedBarrels)
            {
                barrels.Remove(removedBarrel);
            }
            return barrels;
        }
    }
}