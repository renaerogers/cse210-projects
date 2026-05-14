using System.IO;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "jokeBook.txt";
        using StreamWriter outFile = new StreamWriter(fileName);
        outFile.WriteLine("How can you tell a kid plays trombone at the park?");
        outFile.WriteLine("They can't swing because they are too busy complaining about the slide.");
    }
}