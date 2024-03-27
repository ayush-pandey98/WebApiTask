using EmployeeDirectory.DAL.Interface;
using EmployeeDirectory.Models.Roles;
using Newtonsoft.Json;

namespace EmployeeDirectory.DAL.Roles
{
    public class RoleDAL:IRoleDAL
    {
        public List<Role> GetAll()
        {
            string RoleData = File.ReadAllText(@"C:\Users\ayush.p\Desktop\EmployeeDirecroty_Data\Roles.json");
            List<Role> roles = JsonConvert.DeserializeObject<List<Role>>(RoleData)!;
            return roles;
        }
        public void Add(Role role)
        {
            var roles = GetAll();
            if (roles != null) { 
                roles.Add(role);
            }
            else
            {
             roles = new List<Role> { role };
            }   
            Set(roles);
        }
        public void Set(List<Role> roles)
        {
            string json = JsonConvert.SerializeObject(roles);
            File.WriteAllText(@"C:\Users\ayush.p\Desktop\EmployeeDirecroty_Data\Roles.json", json);
        }


    }
}
