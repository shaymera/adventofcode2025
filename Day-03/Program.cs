namespace DayThree
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("../DayThree/Input/main.txt")
                .Select(x => x.ToCharArray().Select(y => int.Parse(y.ToString())).ToList()).ToList();

            Console.Write("Part 1: ");
            Console.WriteLine(Calculate(input, 2));
            Console.Write("Part 2: ");
            Console.WriteLine(Calculate(input, 12));
        }

        private static long Calculate(List<List<int>> input, int n)
        {
            long result = 0;

            foreach (var row in input)
            {
                result += HighestNumbers(row, n);
            }
            return result;
        }

        private static long HighestNumbers(List<int> input, int n)
        {
            string result = "";
            int start = 0;

            for (int i = 0; i < n; i++)
            {
                int highest = 0;
                int latestIndex = input.Count - (n - i);
                for (int j = start; j <= latestIndex; j++)
                {
                    if (input[j] > highest)
                    {
                        highest = input[j];
                        start = j + 1;
                    }
                }

                result += highest;
            }

            return long.Parse(result);
        }
    }
}