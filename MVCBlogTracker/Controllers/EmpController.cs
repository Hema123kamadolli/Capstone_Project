using Microsoft.AspNetCore.Mvc;
using MVCBlogTracker.Models;

namespace MVCBlogTracker.Controllers
{
    public class EmpController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Emp> adminlist;
            HttpResponseMessage response = GlobalVar.WebApiClient.GetAsync("EmpInfoes").Result;
            adminlist = response.Content.ReadAsAsync<IEnumerable<Emp>>().Result;
            return View(adminlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Emp());
        }
        [HttpPost]
        public IActionResult Create(Emp emp)
        {
            HttpResponseMessage response = GlobalVar.WebApiClient.PostAsJsonAsync("EmpInfoes", emp).Result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View(new Emp());
        }

        [HttpPost]
        public ActionResult Login(Emp signin)
        {
            IEnumerable<Emp> adminlist;
            HttpResponseMessage response = GlobalVar.WebApiClient.GetAsync("EmpInfoes").Result;
            adminlist = response.Content.ReadAsAsync<IEnumerable<Emp>>().Result;
            foreach (Emp admin in adminlist)
            {
                if (admin.EmailId == signin.EmailId && admin.PassCode == signin.PassCode)
                {
                    return RedirectToAction("Index", "Blog");
                }

            }
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Emp");
        }
    }
}
