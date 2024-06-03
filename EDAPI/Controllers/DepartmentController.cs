using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.Models.ModelDAL;
using Microsoft.AspNetCore.Mvc;

namespace EDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase 
    {
        private readonly IDepartmentBL _departmentBL;

        public DepartmentController(IDepartmentBL departmentBL)
        {
            _departmentBL = departmentBL;
        }

        //[HttpGet]
        //public IActionResult GetAllDept()
        //{
        //    var departments = _departmentBL.GetAllDepartment();
        //    if (departments == null || !departments.Any())
        //    {
        //        return NotFound("No departments found.");
        //    }
        //    return Ok(departments);
        //}
    }
}
