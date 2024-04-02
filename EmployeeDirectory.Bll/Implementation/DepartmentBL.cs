
using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.Models.department;


namespace EmployeeDirectory.BLL.Implementation.departmentBL
{
    public class DepartmentBL:IDepartmentBL
    {
        private IDepartmentDAL _departmentDAL;
        public DepartmentBL(IDepartmentDAL _departmentDAL)
        {
            this._departmentDAL = _departmentDAL;
        }
        public void AddDepartment(Department department)
        {

            _departmentDAL.Add(department);
        }
        public List<Department> GetAllDepartment()
        {
            return _departmentDAL.GetAll();
        }
        public string GetDepartmentById(int id)
        {
            var departments = _departmentDAL.GetAll();
            return departments.Find(loc => loc.Id == id).Value;
        }
    }
}
