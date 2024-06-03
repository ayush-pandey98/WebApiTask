using EmployeeDirectory.Models.ModelDAL;
using EmployeeDirectory.Models.ModelPresentation;

namespace EmployeeDirectory.BLL.Interface.departmentBL
{
    public interface IDepartmentBL
    {
        public bool AddDepartment(DepartmentDto department);
        public List<Department> GetAllDepartment();
        public string GetDepartmentById(int id);
        public int GetDepartmentId(string department);
    }
}
