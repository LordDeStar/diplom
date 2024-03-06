using diplombee.Model;
using Microsoft.AspNetCore.Mvc;

namespace diplombee.Controllers
{
    public class BasketController: Controller
    {
        [HttpPost]
        public void Add(string article)
        {
            using (BeeContext db = new BeeContext())
            {
                var item = db.PriseLists.FirstOrDefault(i => i.Article.Equals(article) && i.CostForOne > 0);
                
                if (! (item is null))
                {
                    BasketModel.Products.Add(item);
                    item.CountInStock--;
                    db.SaveChanges();
                }

            }
        }
        [HttpPost]
        public void Remove(string article)
        {
            using (BeeContext db = new BeeContext())
            {
                var item = db.PriseLists.FirstOrDefault(i => i.Article.Equals(article));

                if (!(item is null))
                {
                    BasketModel.Products.Remove(BasketModel.Products.First(i => i.Article.Equals(item.Article)));
                    item.CountInStock++;
                    
                    db.SaveChanges();
                }
            }
        }
        public IActionResult Show()
        {
            return View(BasketModel.Products);
        }
    }
}
