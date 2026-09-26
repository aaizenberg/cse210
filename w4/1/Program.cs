class Program
{
    static List<Video> LoadData()
    {
        List<Video> videos = new List<Video>();

        Video firstVideo = new Video("C# for begginers", "Code Academy", 600);
        firstVideo.AddComment(new Comment("Alex", "Great explanation!!!!"));
        firstVideo.AddComment(new Comment("Maria", "Very helpful video"));
        firstVideo.AddComment(new Comment("John", "Thanks for the video"));
        videos.Add(firstVideo);

        Video secondVideo = new Video("Best video ever", "Dev123", 480);
        secondVideo.AddComment(new Comment("Sam", "I am learning C#!!!!"));
        secondVideo.AddComment(new Comment("Emma", "This was really motivating"));
        secondVideo.AddComment(new Comment("Leo", "The examples were easy to follow"));
        videos.Add(secondVideo);

        Video thirdVideo = new Video("Design system", "Tech Simplified", 720);
        thirdVideo.AddComment(new Comment("Nina", "Now makes cense"));
        thirdVideo.AddComment(new Comment("Chris", "Could you explain hexadecimal next?"));
        thirdVideo.AddComment(new Comment("Olivia", "I liked the visual examples"));
        videos.Add(thirdVideo);

        Video fourthVideo = new Video("Simple app", "Code Academy", 540);
        fourthVideo.AddComment(new Comment("Daniel", "I built it along with you"));
        fourthVideo.AddComment(new Comment("Sofia", "The explanation helped"));
        fourthVideo.AddComment(new Comment("Max", "What should I build next?"));
        videos.Add(fourthVideo);

        return videos;
    }

    static void DisplayData(List<Video> videos)
    {
        ArgumentNullException.ThrowIfNull(videos);

        foreach (Video video in videos)
        {
            if (video is null)
            {
                throw new InvalidOperationException("contains an invalid video");
            }

            Console.WriteLine(video.GetDisplayText());
            Console.WriteLine();
        }
    }

    static void Main()
    {
        List<Video> videos = LoadData();
        DisplayData(videos);
    }
}
