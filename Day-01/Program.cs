namespace DayOne;

static class Program
{
    public static void Main()
    {
        var input = File.ReadAllLines("../DayOne/Inputs/main.txt").ToList();
        var moves = input.Select(line => line.StartsWith('L') ? -(int.Parse(line.Substring(1))) : int.Parse(line.Substring(1))).ToList();

        Console.Write("Part One: ");
        Console.WriteLine(PartOne(moves)); 
        
        Console.Write("Part Two: ");
        Console.WriteLine(PartTwo(moves));
    }
        
    private static int PartOne(List<int> input)
    {
        int currentPosition = 50;
        int result = 0;

        for (int i = 0; i < input.Count; i++)
        {
            currentPosition = CalculateRemainder((currentPosition + input[i]));
            
            if (currentPosition == 0)
            {
                result++;
            }
        }

        return result;
    }

    private static int PartTwo(List<int> input)
    {
        int currentPosition = 50;
        int result = 0;

        for (int i = 0; i < input.Count; i++)
        {
            int newPosition = currentPosition + input[i];
            if (newPosition > 0)
            {
                result += newPosition / 100; 
            }
            else
            {
                int firstZero = (currentPosition == 0) ? 0 : -100;
                result += (newPosition + firstZero) / -100;
            }

            currentPosition = CalculateRemainder(newPosition);
        }
        
        return result;
    }

    private static int CalculateRemainder(int position)
    {
        int remainder = (position) % 100;
        return (remainder < 0) ? 100 + remainder : remainder;
    }
}