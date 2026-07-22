using System;

class YouTubeChannel
{
    // Event - that will notify all subscriber
    public event Action? VideoUploaded;

    public void UploadVideo()
    {
        Console.WriteLine("📺 New video uploaded!");

        // Notify all subscribers
        VideoUploaded?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        YouTubeChannel channel = new YouTubeChannel();

        // Subscribers
        channel.VideoUploaded += Balaji;
        channel.VideoUploaded += John;

        // Upload a new video
        channel.UploadVideo();
    }

    static void Balaji()
    {
        Console.WriteLine("Balaji received notification.");
    }

    static void John()
    {
        Console.WriteLine("John received notification.");
    }
}