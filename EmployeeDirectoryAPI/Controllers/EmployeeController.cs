using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.Model.ModelDAL;
using EmployeeDirectory.Models.Presentation.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL _employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }
      
        [HttpGet]
        public ActionResult GetAllEmployee() {
            var employees = _employeeBL.GetAllEmployees();
            return Ok(employees);
        }
        [HttpGet("{employeeId}/employee")]
        public ActionResult GetOneEmp(string employeeId)
        {
            var employee = _employeeBL.GetEmployee(employeeId);
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDto employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }
            var emp = _employeeBL.GetAllEmployees()
                            .Where(e => e.Id.Trim().ToUpper() == employee.Id.Trim().ToUpper()).FirstOrDefault();
            if (emp != null)
            {
                return BadRequest("Employee already exists");
            }
            if (!_employeeBL.AddEmployee(employee))
            {
                return BadRequest("Something went wrong while saving");
            }
            return Ok("Successfully Added");
        }

        [HttpPut("{empId}")]
        public IActionResult UpdateEmployee(string empId, [FromBody] EmployeeDto employee) {
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }
            var emp = _employeeBL.GetEmployee(empId);
            if (emp == null)
            {
                return NotFound();
            }
            if (!_employeeBL.EditEmployee(employee, empId))
            {
                return BadRequest("Something went wrong while updating");
            }
            return NoContent();
        }

        [HttpDelete("{empId}")]
        public IActionResult DeleteEmployee(string empId)
        {
            if(empId == null)
            {
                return BadRequest("Employee Id is null");
            }
            EmployeeDto employee = _employeeBL.GetEmployee(empId);
            if(employee == null)
            {
                return NotFound();
            }
            if (!_employeeBL.DeleteEmployee(employee))
            {
                return BadRequest("Something went wrong while saving");
            }
            return NoContent() ;

        }
    }
}
