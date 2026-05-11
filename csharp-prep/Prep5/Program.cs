using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNum = PromptUserNumber(); 
        int numSquare = SquareNumber(userNum);
        int birthYear;
        PromptUserBirthYear(out birthYear);

        DisplayResult(userName, numSquare, birthYear);
    }
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favNum = int.Parse(Console.ReadLine());

        return favNum; 
    }

    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write($"Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int favNum)
    {
        int square = favNum * favNum;

        return square;
    }

    static void DisplayResult(string userName, int square, int birthYear)
    {
        Console.WriteLine($"{userName}, your number squared is {square}.");
        Console.WriteLine($"{userName}, you will turn {2026 - birthYear} years old this year (in 2026).");
    }
}