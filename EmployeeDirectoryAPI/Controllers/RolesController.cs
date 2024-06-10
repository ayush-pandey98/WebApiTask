using EmployeeDirectory.BLL.Interface;
using EmployeeDirectory.Models.Presentation.Role;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRoleDetailBL _roleDetailBL;
        public RolesController(IRoleDetailBL roleDetailBL)
        {
          _roleDetailBL = roleDetailBL;
        }
        [HttpGet]
        public ActionResult GetAllRoles()
        {
            var roles = _roleDetailBL.GetAllRoleDetails();
            return Ok(roles);
        }

        [HttpPost]
        public ActionResult AddRole([FromBody] RoleDto role)
        {
            if (role == null)
            {
                return BadRequest("Role is null.");
            }
            var rol = _roleDetailBL.GetAllRoleDetails()
                            .Where(r => r.Name.Trim().ToUpper() == role.Name.Trim().ToUpper() && r.LocationId == role.LocationId && r.DepartmentId == role.DepartmentId).FirstOrDefault();
            if (rol != null)
            {
                return BadRequest("Role already exists");
            }
            if (!_roleDetailBL.AddRoleDetail(role))
            {
                return BadRequest("Something went wrong while saving");
            }
            return Ok("Successfully Added");
        }
    }
}
