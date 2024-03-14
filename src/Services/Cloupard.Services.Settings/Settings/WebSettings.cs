namespace Cloupard.Services.Settings.Settings;

public class WebSettings
{
    public const string SectionName = "Api";
    
    public string Url { get; private set; } = string.Empty;
}