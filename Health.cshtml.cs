using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assign2Daneel.Pages
{
    public class HealthModel : PageModel
    {
        public string Status { get; private set; } = string.Empty;
        public DateTime CheckedAt { get; private set; }

        public void OnGet()
        {
            Status = "Healthy";
            CheckedAt = DateTime.Now;
        }
    }
}
