// One of the creative things I added:
// I added something that checks what day of the week it is. Then it uses that info to add more specific prompts to the list.  

using System;
using System.Collections.Generic; 
using System.IO;

public class Journal
{
    //This creates the list of entries and prepares for it to be saved to a file
    private List<Entry> _entries = new List<Entry>();
    private const string Separator = "~|~"; 

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nStart writing something to see entries!");
            return;
            //This stops the rest of the code from happening and returns back to the beginning so they can make entries
        }
        
        Console.WriteLine("\n Journal Entries: ");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        //The entries are saved to an open file 
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // FIX 1: Changed EntryText to entry.EntryText (lowercase 'e' matching the variable context)
                writer.WriteLine($"{entry.Date}{Separator}{entry.PromptText}{Separator}{entry.EntryText}");
            }
        }
        Console.WriteLine("Journal has been saved successfully!");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("Sorry, that file doesn't exist...");
            return;
        }
        else
        {
            //This breaks apart what was put into the file
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string[] parts = line.Split(new[] {Separator}, StringSplitOptions.None);
                if (parts.Length == 3)
                {
                    Entry loadedEntry = new Entry(parts[1], parts[2]); // Load prompt and response
                    loadedEntry.Date = parts[0];                       // Restore the saved file date
                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine("Journal has been successfully loaded!");
        }
    }
}

public class Entry
{
    public string PromptText {get; set;}
    public string EntryText{get; set;}
    public string Date{get; set;} 

    public Entry(string prompt, string entry)
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateNow = theCurrentTime.ToShortDateString();

        //This was for some testing to see what DateTime.Now and .ToShortDateString did
        // Console.WriteLine($"It is: {theCurrentTime}");
        // Console.WriteLine($"It is: {dateNow}");

        PromptText = prompt; 
        EntryText = entry; 
        Date = dateNow;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {PromptText}");
        Console.WriteLine($"{EntryText}\n"); 
    }
}

public class PromptGenerator
{
    // These are the basic prompts the program has that can be asked any day. 
    List<string> promptList = new List<string> 
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something new you learned or realized today?",
        "Describe a small victory or moment of peace you experienced."
    };
    Random _random = new Random();

    // FIX 4: Added this constructor so that DailyPrompt() actually runs when the program starts!
    public PromptGenerator()
    {
        DailyPrompt();
    }

    public void DailyPrompt()
    {   
        // This determines the day of the week and depending on the day, adds new prompts to the list. 
        DayOfWeek currentDay = DateTime.Now.DayOfWeek; 

        if (currentDay == DayOfWeek.Sunday)
        {
            promptList.Add("Was there anything that stood out to you from church or your scripture study?");
            promptList.Add("What is one of your favorite hymns and why?");
        }
        else if (currentDay == DayOfWeek.Monday)
        {
            promptList.Add("What was something good that happened to you today?");
            promptList.Add("What small miracle did you see in your life today?");
        }
        else if (currentDay == DayOfWeek.Tuesday)
        {
            promptList.Add("What was the best food you had today?");
            promptList.Add("What was something that made you excited? ");
        }
        else if (currentDay == DayOfWeek.Wednesday)
        {
            promptList.Add("What was your favorite place you went to today?");
            promptList.Add("Name one thing you enjoyed doing today.");
        }
        else if (currentDay == DayOfWeek.Thursday)
        {
            promptList.Add("If you were a fruit, what fruit would you be?");
            promptList.Add("What were the top five most useful objects to you today?");
        }
        else if (currentDay == DayOfWeek.Friday)
        {
            promptList.Add("What was your favorite place you went to today?");
            promptList.Add("Name one thing you enjoyed doing today.");
        }
        else if (currentDay == DayOfWeek.Saturday)
        {
            promptList.Add("What was you did fun today that you usually don't do?");
            promptList.Add("Did you see any cool animals today? What was your favorite one?");
        }
        else
        {
            promptList.Add("If you had a million dollars, what would be the first thing you spent it on?");
        }
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(promptList.Count);
        return promptList[index];
    }
}

class RunProgram
{
    static void Main(string[] args)
    {
        // This creates a temporary journal to hold the journal entries from when you started running the program 
        // (When you quit, a new journal will be created when you open the program again. ) 
        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        
        string programRunning  = "yes"; 

        Console.WriteLine("Welcome to your Daily Writing Journal! \n");

        while (programRunning == "yes")
        {
            Console.WriteLine("\nPlease select one of the following:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Load a journal from a file");
            Console.WriteLine("4. Save the journal to a filename");
            Console.WriteLine("5. Quit program");
            
            Console.Write("\n What would you like to do? ");
            string input = Console.ReadLine(); 
            int choice = int.Parse(input); 

            if (choice == 1)
            {
                //This gives the user a prompt and saves the info as an entry
                string generatedPrompt = promptGen.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {generatedPrompt}");
                Console.Write("> ");

                string response = Console.ReadLine(); 
                Entry newEntry = new Entry(generatedPrompt, response);
                myJournal.AddEntry(newEntry);
            }
            else if (choice == 2)
            {
                //This should show all of the entries made this session
                myJournal.DisplayAll();  
            }
            else if (choice == 3)
            {
                //This should load and show a file after a filename is given
                Console.Write("What is the filename? ");
                string fileLoaded = Console.ReadLine(); 
                myJournal.LoadFromFile(fileLoaded);
            }
            else if (choice == 4)
            {
                //This should save the entries made to the end of a new file
                Console.Write("What is the filename? ");
                string fileSaved = Console.ReadLine();
                myJournal.SaveToFile(fileSaved);
            }
            else if (choice == 5)
            {
                //This should kill the program, 
                // meaning the program needs to be started again for the user to do anything else.
                programRunning = "no";
                Console.WriteLine("Thank you for taking the time to write today!");
                break; 
                //R 
            }
            else
            {
                //In case the user doesn't use numbers or the right numbers... 
                Console.WriteLine("Sorry, please try using one of the numbers listed. (From: 1 to 5)");
            }
        }
    }
}