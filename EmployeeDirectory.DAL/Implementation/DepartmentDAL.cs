using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.Models.department;
using Newtonsoft.Json;

namespace EmployeeDirectory.DAL.Implementation.departmentDAL
{
    public class DepartmentDAL:IDepartmentDAL
    {
        public List<Department> GetAll()
        {
            string locationData = File.ReadAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\Department.json");
            List<Department> departments = JsonConvert.DeserializeObject<List<Department>>(locationData)!;
            return departments;
        }
        public void Add(Department location)
        {
            var departments = GetAll();
            if (departments == null)
            {
                departments = new List<Department>();
            }
            departments.Add(location);
            Set(departments);

        }
        public void Set(List<Department> departments)
        {
            string json = JsonConvert.SerializeObject(departments);
            File.WriteAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\Department.json", json);
        }
    }
}
