using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.Models.ModelDAL;
using EmployeeDirectory.Models.ModelPresentation;


namespace EmployeeDirectory.BLL.Implementation.departmentBL
{
    public class DepartmentBL:IDepartmentBL
    {
        private readonly IDepartmentDAL _departmentDAL;
        public DepartmentBL(IDepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }
        public bool AddDepartment(DepartmentDto department)
        {
            Department departmentDAL = new Department()
            {
                Value = department.Value
            };
            return _departmentDAL.Add(departmentDAL);
        }
        public List<Department> GetAllDepartment()
        {
            return _departmentDAL.GetAll();
        }
        public string GetDepartmentById(int id)
        {
            return _departmentDAL.GetNameById(id);
        }
        public int GetDepartmentId(string department)
        {
            return _departmentDAL.GetIdByName(department);
        }
    }
}
