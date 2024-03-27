using EmployeeDirectory.Models;
using Newtonsoft.Json;
using EmployeeDirectory.DAL.Interface;
namespace EmployeeDirectory.DAL
{
    public class EmployeeDAL:IEmployeeDAL
    {
        public List<Employee> GetAll()
        {
            string employeeData = File.ReadAllText(@"C:\Users\ayush.p\Desktop\EmployeeDirecroty_Data\employees.json");
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(employeeData)!;
            return employees;
        }
        public void Add(Employee employee)
        {
            var employees = GetAll();
            employees.Add(employee);
            Set(employees);
        }
        public Employee GetById(string id)
        {
            var employees = GetAll();
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
            File.WriteAllText(@"C:\Users\ayush.p\Desktop\EmployeeDirecroty_Data\employees.json", json);
        }
    }
}
