namespace PlaywrightDemo.Infrastructure.Config.Models
{
    public sealed class PlaywrightSettings
    {
        public string BaseUrl { get; set; } = null!;
        public int TimeoutMs { get; set; } = 30000;
    }
}
