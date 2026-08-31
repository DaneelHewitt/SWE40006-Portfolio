using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assign2Daneel.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string ApplicationName { get; } = "SWE40006 Deployment Dashboard";
    public string Technology { get; } = "C# / ASP.NET Core";
    public string Framework { get; } = ".NET 10";

    public string AppEnvironment { get; private set; } = string.Empty;
    public DateTime ServerTime { get; private set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        AppEnvironment =
            System.Environment.GetEnvironmentVariable("APP_ENVIRONMENT")
            ?? "Not configured";

        ServerTime = DateTime.Now;

        _logger.LogInformation(
            "Deployment Dashboard accessed at {Time}",
            ServerTime);
    }
}