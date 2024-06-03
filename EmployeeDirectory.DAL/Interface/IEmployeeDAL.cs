using EmployeeDirectory.Models.ModelDAL;

namespace EmployeeDirectory.DAL.Interface.employeeDAL
{
    public interface IEmployeeDAL
    {
        public List<Employee> GetAll();
        public bool Add(Employee employee);
        public Employee GetById(string id);
        public bool Delete(Employee employee);
        public bool Update(Employee employee, string id);
    }
}
