using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.Model.ModelDAL;
using EmployeeDirectory.Models.ModelPresentation;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeDirectoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationBL _locationBL;
        public LocationController(ILocationBL locationBL)
        {
            _locationBL = locationBL;
        }
        [HttpGet]
        public ActionResult GetAllDepartments()
        {
            var locations = _locationBL.GetAllLocation();
            return Ok(locations);
        }    

    }
}
