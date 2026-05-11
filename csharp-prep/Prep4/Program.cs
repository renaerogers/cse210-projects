using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNum = -1; 
        while (userNum != 0)
        {
            Console.WriteLine("Enter a number (0 to quit): ");
            string userResponse = Console.ReadLine();
            userNum = int.Parse(userResponse); 

            if (userNum != 0)
            {
                numbers.Add(userNum);
            }
        }

        int numSum = 0;
        foreach (int num in numbers)
        {
            numSum += num;
        }
        Console.WriteLine($"The sum of the numbers is: {numSum}");

        float numAvg = ((float)numSum) / numbers.Count;
        Console.WriteLine($"The average of the numbers is: {numAvg}");

        int bigNum = numbers[0];

        foreach (int num in numbers)
        {
            if (num > bigNum)
            {
                bigNum = num;
            }
        }

        Console.WriteLine($"The biggest number is: {bigNum}");
    }
}