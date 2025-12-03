using System.Text.RegularExpressions;

namespace DayTwo
{
    class Program
    {
        static void Main()
        {
            var input = new List<(string, string)>(
                File.ReadAllText("../Day-02/Input/main.txt")
                        .Split(',')
                        .Select(x => (x.Split('-').First(), x.Split('-').Last()))
                        .ToList()); 
            
            Console.Write("Part one: ");
            Console.WriteLine(PartOne(input));
            
            Console.Write("Part two: ");
            Console.WriteLine(PartTwo(input));
        }

        private static ulong PartOne(List<(string firstId, string secondId)> input)
        {
            ulong result = 0;

            foreach (var range in input)
            {
                ulong index = ulong.Parse(range.firstId); 
                ulong end = ulong.Parse(range.secondId);

                while (index <= end)
                {
                    if (ValidateId(index.ToString()))
                    {
                        result += index;
                    }
                    index++;
                }
            }
            
            return result;
        }
        private static bool ValidateId(string id)
        {
            int length =  id.Length;
            if (length % 2 == 0) //&& !id.StartsWith('0')
            {
                int middle =  length / 2;
                if (id.Substring(0, middle).Equals(id.Substring(middle, length - middle)))
                {
                    return true;
                }
            }

            return false;
        }

        private static ulong PartTwo(List<(string firstId, string secondId)> input)
        {
            ulong result = 0;

            foreach (var range in input)
            {
                ulong index = ulong.Parse(range.firstId);
                ulong end = ulong.Parse(range.secondId);
                
                while (index <= end)
                {
                    if (CheckMatches(index.ToString()))
                    {
                        result += index;
                    }
                    index++;
                }
            }
            return result;
        }

        private static bool CheckMatches(string id)
        {
            int length = id.Length;
            int middle = length / 2;
            
            for (int i = 1; i <= middle; i++)
            {
                if (length % i == 0)
                {
                    string pattern = id.Substring(0, i);
                    var rg = new Regex(pattern);
                    if (rg.Matches(id).Count == ( length / i ))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}