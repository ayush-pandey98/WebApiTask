using EmployeeDirectory.Models;
using Newtonsoft.Json;
using EmployeeDirectory.DAL.Interface.employeeDAL;
namespace EmployeeDirectory.DAL
{
    public class EmployeeDAL:IEmployeeDAL
    {
        public List<EmployeeModelDAL> GetAll()
        {
            string employeeData = File.ReadAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\Employee.json");
            List<EmployeeModelDAL> employees = JsonConvert.DeserializeObject<List<EmployeeModelDAL>>(employeeData)!;
            return employees;
        }
        public void Add(EmployeeModelDAL employee)
        {
            var employees = GetAll();
            if(employees == null) { employees = new List<EmployeeModelDAL>(); }
            employees.Add(employee);
            Set(employees);
        }
        public EmployeeModelDAL GetById(string id)
        {
            var employees = GetAll();
            if (employees == null) return null;
            return employees.Find(emp => emp.Id == id)!;
        }
        public bool Delete(string id)
        {
            var employees = GetAll();
            var employee = GetById(id);
            if (employee != null)
            {
                employees.RemoveAll(emp => emp.Id == id);
                Set(employees);
                return true;
            }
            return false;
        }
        public void Set(List<EmployeeModelDAL> employees)
        {
            string json = JsonConvert.SerializeObject(employees);
            File.WriteAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\Employee.json", json);
        }
    }
}
