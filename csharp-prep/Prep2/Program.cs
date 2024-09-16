using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What was your grade percetange? ");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);
        string letter = "";
        if (number > 89)
        {
            letter = "A";
        }
        else if (number > 79)
        {
            letter = "B";
        }
        else if (number > 69)
        {
            letter = "C";
        }
        else if (number > 59)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}");
        if (number > 69)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You did not pass.");
        }
    }
}