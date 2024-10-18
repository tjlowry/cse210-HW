using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video("How to Code in C#", "John Smith", 300);
        Video video2 = new Video("C# Basics Tutorial", "Jane Doe", 450);
        Video video3 = new Video("Advanced C# Techniques", "Alex Johnson", 600);

        video1.AddComment("Alice", "Great tutorial!");
        video1.AddComment("Bob", "Really helpful, thanks!");
        video1.AddComment("Charlie", "Loved the explanations.");

        video2.AddComment("David", "This was a bit too fast for me.");
        video2.AddComment("Eve", "Clear and concise!");

        video3.AddComment("Frank", "I learned a lot!");
        video3.AddComment("Grace", "Very informative.");

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}
