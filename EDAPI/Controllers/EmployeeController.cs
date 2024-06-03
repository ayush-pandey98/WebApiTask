using EmployeeDirectory.BLL.Interface.employeeBL;
using Microsoft.AspNetCore.Mvc;

namespace EDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        IEmployeeBL _employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
           var employees =  _employeeBL.GetAllEmployees();
            return Ok(employees);
        }
    }
}
