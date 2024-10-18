using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video("10-Minute Healthy Meals", "Tasty Kitchen", 600);
        Video video2 = new Video("C# Basics for Beginners", "CodeWithMe", 900);
        Video video3 = new Video("NBA Highlights", "NBA", 1200);

        video1.AddComment("EmmaW", "Loved these meal ideas! So quick and easy.");
        video1.AddComment("HealthyLife123", "I made the quinoa salad and it was delicious!");
        video1.AddComment("ChefMike", "Perfect for meal prep. Thanks for the tips!");


        video2.AddComment("CodeLover", "This helped me a lot as a beginner, thanks!");
        video2.AddComment("LearningDev", "You should explain loops a bit more, but overall great tutorial.");
        video2.AddComment("TechFan", "Awesome, finally understand C# syntax!");

        video3.AddComment("superfan1", "That dunk was crazyyyy");
        video3.AddComment("randomuser", "Lebron is still nowhere close to MJ");
        video3.AddComment("sunfan123", "THe Suns are winning it all this year");

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}
