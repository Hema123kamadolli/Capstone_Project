using Microsoft.AspNetCore.Mvc;
using MVCBlogTracker.Models;

namespace MVCBlogTracker.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Blog> adminlist;
            HttpResponseMessage response = GlobalVar.WebApiClient.GetAsync("BlogInfoes").Result;
            adminlist = response.Content.ReadAsAsync<IEnumerable<Blog>>().Result;
            return View(adminlist);
        }

        public IActionResult Display()
        {
            IEnumerable<Blog> adminlist;
            HttpResponseMessage response = GlobalVar.WebApiClient.GetAsync("BlogInfoes").Result;
            adminlist = response.Content.ReadAsAsync<IEnumerable<Blog>>().Result;
            return View(adminlist);
        }
        public IActionResult Create()
        {
            return View(new Blog());
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            HttpResponseMessage response = GlobalVar.WebApiClient.PostAsJsonAsync("BlogInfoes", blog).Result;
            return RedirectToAction("Display");
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Blog");
        }
    }
}
