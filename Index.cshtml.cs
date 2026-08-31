using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assign2Daneel.Pages
{
    public class IndexModel : PageModel
    {
        public string ApplicationName { get; } = "SWE40006 Deployment Dashboard";
        public string Technology { get; } = "C# / ASP.NET Core";
        public string Framework { get; } = ".NET 10";
        public DateTime ServerTime { get; private set; }

        public void OnGet()
        {
            ServerTime = DateTime.Now;
        }
    }
}