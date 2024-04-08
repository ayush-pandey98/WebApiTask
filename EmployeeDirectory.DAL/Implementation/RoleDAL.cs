using EmployeeDirectory.DAL.Interface.roleDAL;
using EmployeeDirectory.Models.Roles;
using Newtonsoft.Json;

namespace EmployeeDirectory.DAL.Roles
{
    public class RoleDAL:IRoleDAL
    {
        public List<RoleModelDAL> GetAll()
        {
            string RoleData = File.ReadAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\Role.json");
            List<RoleModelDAL> roles = JsonConvert.DeserializeObject<List<RoleModelDAL>>(RoleData)!;
            return roles;
        }
        public void Add(RoleModelDAL role)
        {
            var roles = GetAll();
            if (roles != null) { 
                roles.Add(role);
            }
            else
            {
             roles = new List<RoleModelDAL> { role };
            }   
            Set(roles);
        }
        public void Set(List<RoleModelDAL> roles)
        {
            string json = JsonConvert.SerializeObject(roles);
            File.WriteAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\Role.json", json);
        }


    }
}
