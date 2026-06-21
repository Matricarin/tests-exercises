using Task002_Throttling;

namespace TasksPart1_TestProject;

public sealed class Task002ThrottlingTests
{
    [Fact]
    public async Task RunTask002_CheckThreadsCount()
    {
        var list = new List<string>()
        {
            "https://www.google.com",
            "https://www.youtube.com",
            "https://www.wikipedia.org",
            "https://www.reddit.com",
            "https://www.amazon.com",
            "https://www.microsoft.com",
            "https://www.apple.com",
            "https://www.github.com",
            "https://stackoverflow.com",
            "https://www.linkedin.com",
            "https://www.netflix.com",
            "https://www.bbc.com",
            "https://www.nytimes.com",
            "https://www.cnn.com",
            "https://www.openai.com",
            "https://www.twitter.com",
            "https://www.instagram.com",
            "https://www.facebook.com",
            "https://www.twitch.tv",
            "https://www.imdb.com",
            "https://www.quora.com",
            "https://www.medium.com",
            "https://www.paypal.com",
            "https://www.dropbox.com",
            "https://www.spotify.com"
        };

        var report = await ThrottlingSolver.ProcessUrlsAsync(list, 4, CancellationToken.None);

        Assert.NotEmpty(report);
    }
}