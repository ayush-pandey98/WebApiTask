using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.Models.Presentation.Role;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRoleBL _roleBL;
        public RolesController(IRoleBL roleBL)
        {
          _roleBL = roleBL;
        }
        [HttpGet]
        public ActionResult GetAllRoles()
        {
            var roles  =  _roleBL.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{roleId}/RoleId")]
        public ActionResult GetRoleById(int id)
        {
            string role =  _roleBL.GetRoleById(id);
            return Ok(role);
        }
        [HttpGet("{roleName}/RoleName")]
        public ActionResult GetRoleIdByName(string roleName)
        {
            int roleId = _roleBL.GetIdByRole(roleName);
            return Ok(roleId);
        }

        [HttpPost]
        public ActionResult AddRole([FromBody] RoleDto role)
        {
            if (role == null)
            {
                return BadRequest("Role is null.");
            }
            var rol = _roleBL.GetAllRoles()
                            .Where(r => r.Name.Trim().ToUpper() == role.Name.Trim().ToUpper() && r.Location.Trim().ToUpper()==role.Location.Trim().ToUpper()).FirstOrDefault();
            if (rol != null)
            {
                return BadRequest("Role already exists");
            }
            if (!_roleBL.AddRole(role))
            {
                return BadRequest("Something went wrong while saving");
            }
            return Ok("Successfully Added");
        }
    }
}
