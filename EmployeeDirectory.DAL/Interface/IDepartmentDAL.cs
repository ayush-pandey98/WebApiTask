using EmployeeDirectory.Models.ModelDAL;

namespace EmployeeDirectory.DAL.Interface.departmentDAL
{
    public interface IDepartmentDAL
    {
        public List<Department> GetAll();
        public bool Add(Department department);
        public string GetNameById(int id);
        public int GetIdByName(string name);
    }
}
