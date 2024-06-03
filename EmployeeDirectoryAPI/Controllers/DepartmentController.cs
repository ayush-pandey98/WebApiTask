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
        [HttpGet("{deptId}/DepartmentId")]
        public ActionResult GetDepartmentById(int deptId) {
            var department = _departmentBL.GetDepartmentById(deptId);
            return Ok(department);  
        }
        [HttpGet("{deptName}/DepartmentName")]
        public ActionResult GetIdByDepartmentName(string deptName)
        {
            var deptId = _departmentBL.GetDepartmentId(deptName);
            return Ok(deptId);  
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody] DepartmentDto department)
        {
            if (department == null)
            {
                return BadRequest("Location is null.");
            }
            var dep = _departmentBL.GetAllDepartment()
                            .Where(d => d.Value.Trim().ToUpper() == department.Value.Trim().ToUpper()).FirstOrDefault();
            if (dep != null)
            {
                return BadRequest("Department already exists");
            }
            if (!_departmentBL.AddDepartment(department))
            {
                return BadRequest("Something went wrong while saving");
            }
            return Ok("Successfully Added");
        }


    }
}
