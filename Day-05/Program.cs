namespace Day_05
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("../Day-05/input/main.txt");
            var ranges = new List<(long start, long end)>();
            var ids = new List<long>();
            
            var foundEmpty = false;
            foreach (var line in input)
            {
                if (!foundEmpty )
                {
                    if (line == "")
                    {
                        foundEmpty = true;
                        continue;
                    }
                    ranges.Add((long.Parse(line.Split('-')[0]), long.Parse(line.Split('-')[1])));
                }
                else
                {
                    ids.Add(long.Parse(line));
                }
            }
            
            ranges = ranges.OrderBy(x => x.start).ToList();
            ids.Sort();
            
            Console.Write("Part one: ");
            Console.WriteLine(PartOne(ranges, ids));
            
            Console.Write("Part two: ");
            Console.WriteLine(PartTwo(ranges));
        }
        
        static int PartOne(List<(long start, long end)> ranges, List<long> ids)
        {
            int result = 0;
            int rangeIndex = 0;
            int idIndex = 0;

            while (rangeIndex < ranges.Count && idIndex < ids.Count)
            {
                var currentRange = ranges[rangeIndex];
                var currentId = ids[idIndex];

                if (currentRange.start <= currentId && currentRange.end >= currentId)
                {
                    result++;
                    idIndex++;
                } 
                else if (currentRange.end < currentId)
                {
                    rangeIndex++;
                }
                else if (currentRange.start > currentId)
                {
                    idIndex++;
                }
            }
            return result;
        }

        static long PartTwo(List<(long start, long end)> ranges)
        {
            long result = 0;
            long prevEnd = 0;

            foreach (var range in ranges)
            {
                if (range.start > prevEnd)
                {
                    result += range.end - range.start + 1;
                    prevEnd = range.end;
                }
                else if (range.end > prevEnd) 
                {
                   result += range.end - prevEnd;
                   prevEnd = range.end;
                }
            }
            
            return result;
        }
    }
};

