using System.IO;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "jokeBook.txt";
        string[] jokeLines = System.IO.File.ReadAllLines (fileName);

        foreach (string joke in jokeLines)
        {
            Console.WriteLine(joke);
        }        
    }
}