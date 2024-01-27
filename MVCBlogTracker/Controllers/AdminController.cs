using Microsoft.AspNetCore.Mvc;
using MVCBlogTracker.Models;

namespace MVCBlogTracker.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {

            return View(new Admin());

        }

        [HttpPost]
        public ActionResult Login(Admin signin)
        {
            IEnumerable<Admin> adminlist;
            HttpResponseMessage response = GlobalVar.WebApiClient.GetAsync("AdminInfoes").Result;
            adminlist = response.Content.ReadAsAsync<IEnumerable<Admin>>().Result;
            foreach (Admin admin in adminlist)
            {
                if (admin.EmailId == signin.EmailId && admin.Password == signin.Password)
                {
                    return RedirectToAction("Index", "Emp");
                }

            }
            return View();
        }
    }
}
