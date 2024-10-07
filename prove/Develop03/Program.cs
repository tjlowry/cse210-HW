using System;
// I think I went above and beyond by giving the user options for which scripture they want to memorize from a list. 
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths"),
            new Scripture(new Reference("Moroni", 7, 33), "And Christ hath said: If ye will have faith in me ye shall have power to do whatsoever thing is expedient in me"),
            new Scripture(new Reference("1 Nephi", 20, 10), "For, behold, I have refined thee, I have chosen thee in the furnace of affliction"),
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose a scripture to memorize:");
            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetReferenceDisplayText()}");
            }
            Console.WriteLine("Enter the number of your choice or type 'quit' to exit:");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break; 
            }

            if (int.TryParse(input, out int choice) && choice > 0 && choice <= scriptures.Count)
            {
                Scripture selectedScripture = scriptures[choice - 1];

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine(selectedScripture.GetDisplayText());

                    if (selectedScripture.IsCompletelyHidden())
                    {
                        Console.WriteLine("All words in this scripture are hidden.");
                        Console.WriteLine("\nType 'menu' to return to the scripture selection menu, or 'quit' to exit.");

                        input = Console.ReadLine();
                        if (input.ToLower() == "quit")
                        {
                            return; 
                        }
                        else if (input.ToLower() == "menu")
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
                        input = Console.ReadLine();

                        if (input.ToLower() == "quit")
                        {
                            return;
                        }
                        selectedScripture.HideRandomWords(3);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}