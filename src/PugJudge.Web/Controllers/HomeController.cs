using Microsoft.AspNetCore.Mvc;
using PugJudge.Service.Lookup;

namespace PugJudge.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Lookup(string name, string realm)
        {
            var service = new LookupService();

            var response = service.LookupCharacter(name, realm);

            return View(response);
        }
    }
}
