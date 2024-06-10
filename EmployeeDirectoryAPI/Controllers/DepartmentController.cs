using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.Models.ModelPresentation;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentBL _departmentBL;
        public DepartmentController(IDepartmentBL departmentBL)
        {
            _departmentBL = departmentBL;
        }
        [HttpGet]
            public ActionResult GetAllDepartments()
            {
                var departments = _departmentBL.GetAllDepartment();
                return Ok(departments);
            }
        
    }
}
