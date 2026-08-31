using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assign2Daneel.Pages;

public class HealthModel : PageModel
{
    private readonly ILogger<HealthModel> _logger;

    public string Status { get; private set; } = string.Empty;
    public DateTime CheckedAt { get; private set; }

    public HealthModel(ILogger<HealthModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Status = "Healthy";
        CheckedAt = DateTime.Now;

        _logger.LogInformation(
            "Health check accessed at {Time}. Status: {Status}",
            CheckedAt,
            Status);
    }
}