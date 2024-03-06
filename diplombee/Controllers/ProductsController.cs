using diplombee.Model;
using Microsoft.AspNetCore.Mvc;

namespace diplombee.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Products()
        {
            using (BeeContext db  = new BeeContext())
            {
                var res = db.PriseLists.ToList();
                return View(res);
            }
            
        }
        [HttpGet]
        public IActionResult Products(int id)
        {
            using (BeeContext db = new BeeContext())
            {
                var res = db.PriseLists.ToList();
                res = res.Where(item => item.Categoyid == id).ToList();
                return View(res);
            }
        }

    }
}
