using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("What is the magic number?");
        // string magicNumResponse = Console.ReadLine();
        // int magicNum = int.Parse(magicNumResponse);

        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1,101);

        int guessNum = 0;

        do 
        {
            Console.WriteLine("What is your guess?");
            string guessResponse = Console.ReadLine();
            guessNum = int.Parse(guessResponse);

            if (magicNum > guessNum)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNum == guessNum)
            {
                Console.WriteLine("You guessed it!");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        } while (guessNum != magicNum);
    }
}