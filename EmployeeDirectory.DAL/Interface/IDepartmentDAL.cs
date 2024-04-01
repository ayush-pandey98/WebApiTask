using EmployeeDirectory.Models.department;

namespace EmployeeDirectory.DAL.Interface.departmentDAL
{
    public interface IDepartmentDAL
    {
        public List<Department> GetAll();
        public void Set(List<Department> departments);
        public void Add(Department department);
    }
}
