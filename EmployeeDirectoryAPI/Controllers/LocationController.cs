using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.Models.ModelDAL;
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
        [HttpGet("{id}/LocationId")]
        public ActionResult GetLocationById(int id)
        {
            var location = _locationBL.GetLocationById(id);
            return Ok(location);    
        }
        [HttpGet("{locationName}/LoocationName")]
        public ActionResult GetIdByName(string locationName)
        {
            var locationId =  _locationBL.GetLocationId(locationName);
            return Ok(locationId);
        }
        [HttpPost]
        public IActionResult AddLocation([FromBody] LocationDto location)
        {
            if (location == null)
            {
                return BadRequest("Location is null.");
            }
            var loc = _locationBL.GetAllLocation()
                            .Where(l =>l.Value.Trim().ToUpper() == location.Value.Trim().ToUpper()).FirstOrDefault();
            if(loc != null)
            {
                return BadRequest("Location already exists");
            }
            if (!_locationBL.AddLocation(location))
            {
                return BadRequest("Something went wrong while saving");
            }
            return Ok("Successfully Added");
        }

    }
}
