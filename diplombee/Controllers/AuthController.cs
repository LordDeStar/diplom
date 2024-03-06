using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using diplombee.Model;

namespace diplombee.Controllers
{
    public class AuthController : Controller
    {
        // GET: AuthController
        BeeContext context;
        public AuthController()
        {
            context = new BeeContext();
        }
        public object login(Client client)
        {
            var auth = context.Clients.FirstOrDefault(c => c.LoginClient == client.LoginClient && c.PasswordClient == client.PasswordClient);
            var wor = context.Clients.FirstOrDefault(c => c.LoginClient != client.LoginClient && c.PasswordClient != client.PasswordClient);
            if (auth == null)
                return "Пользователь не найден";
            return auth;

        }
        public ActionResult Index()
        {
            return View("Index");
        }
        public string CreateClient(Client client)
        {
            try
            {
                var id = context.Clients.Max(a => a.Idclients) + 1;
                client.Idclients = id;
                context.Clients.Add(client);
                context.SaveChanges();
                return "Регистрация прошла успешно";
            }
            catch (Exception ex)
            {
                return $"Возникла ошибка: {ex.Message}";
            }

        }

        // GET: AuthController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: AuthController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
