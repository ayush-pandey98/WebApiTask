using Microsoft.AspNetCore.Mvc;

namespace EDAPI.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
