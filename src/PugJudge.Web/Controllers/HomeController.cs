using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PugJudge.Domain.Models;
using PugJudge.Domain.ViewModels;
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

        [HttpGet]
        public async Task<IActionResult> Lookup(string name, string realm)
        {
            var service = new LookupService();

            var response = await service.LookupCharacter(name, realm);

            var characterProgression = new CharacterProgressionViewModel(new Character{Name = name, Realm = realm}, response);

            return View(characterProgression);
        }
    }
}
