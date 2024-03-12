namespace Cloupard.Services.Settings.Settings;

public class SwaggerSettings
{
    public const string SectionName = "Swagger";
    
    public bool Enabled { get; private set; } = false;

    public SwaggerSettings()
    {
        Enabled = false;
    }
}