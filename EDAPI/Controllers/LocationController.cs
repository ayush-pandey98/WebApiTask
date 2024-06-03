using Microsoft.AspNetCore.Mvc;

namespace EDAPI.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
