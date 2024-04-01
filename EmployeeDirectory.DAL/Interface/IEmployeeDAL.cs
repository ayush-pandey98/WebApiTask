using EmployeeDirectory.Models;

namespace EmployeeDirectory.DAL.Interface.employeeDAL
{
    public interface IEmployeeDAL
    {
        public List<Employee> GetAll();
        public void Add(Employee employee);
        public Employee GetById(string id);
        public bool Delete(string id);
        public void Set(List<Employee> employees);
    }
}
