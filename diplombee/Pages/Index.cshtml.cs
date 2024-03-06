using diplombee.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace diplombee.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Category> Categories { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            using (BeeContext db = new BeeContext())
            {
                Categories = db.Categories.ToList();
            }
        }

        public void OnGet()
        {

        }
    }
}