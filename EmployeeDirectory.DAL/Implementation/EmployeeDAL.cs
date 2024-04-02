using EmployeeDirectory.Models;
using Newtonsoft.Json;
using EmployeeDirectory.DAL.Interface.employeeDAL;
namespace EmployeeDirectory.DAL
{
    public class EmployeeDAL:IEmployeeDAL
    {
        public List<Employee> GetAll()
        {
            string employeeData = File.ReadAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\Employee.json");
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(employeeData)!;
            return employees;
        }
        public void Add(Employee employee)
        {
            var employees = GetAll();
            if(employees == null) { employees = new List<Employee>(); }
            employees.Add(employee);
            Set(employees);
        }
        public Employee GetById(string id)
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
        public void Set(List<Employee> employees)
        {
            string json = JsonConvert.SerializeObject(employees);
            File.WriteAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\Employee.json", json);
        }
    }
}
