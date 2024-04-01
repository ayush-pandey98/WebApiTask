using EmployeeDirectory.Models.department;

namespace EmployeeDirectory.BLL.Interface.departmentBL
{
    public interface IDepartmentBL
    {
        public void AddDepartment(Department department);
        public List<Department> GetAllDepartment();
    }
}
