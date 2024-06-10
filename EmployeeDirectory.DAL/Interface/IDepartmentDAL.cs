using EmployeeDirectory.Model.ModelDAL;

namespace EmployeeDirectory.DAL.Interface.departmentDAL
{
    public interface IDepartmentDAL
    {
        public List<Department> GetAll();
        public bool Add(Department department);
        public int GetDepartmentId(string departmentName);
    }
}
