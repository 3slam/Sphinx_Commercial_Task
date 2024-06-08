using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Commercial_Task.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private int x = 36;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            int xx = x;

        }
    }
}
