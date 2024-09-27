using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What would your perfect day tomorrow look like?"
        };

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Random random = new Random();
                string prompt = prompts[random.Next(prompts.Count)];
                Console.WriteLine($"Prompt: {prompt}");

                Console.Write("Your response: ");
                string response = Console.ReadLine();


                Console.Write("Where did you go today? ");
                string whereDidYouGo = Console.ReadLine();

                journal.AddEntry(prompt, response, whereDidYouGo);
            }

            else if (choice == "2")
            {
                journal.DisplayJournal();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename to save the journal: ");
                string filename = Console.ReadLine();
                journal.SaveJournal(filename);
                Console.WriteLine("Journal saved successfully.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename to load the journal: ");
                string filename = Console.ReadLine();
                journal.LoadJournal(filename);
                Console.WriteLine("Journal loaded successfully.");
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
