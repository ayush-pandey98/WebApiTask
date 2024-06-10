using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.Model.ModelDAL;
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
                DepartmentName = department.Value
            };
            return _departmentDAL.Add(departmentDAL);
        }
        public List<Department> GetAllDepartment()
        {
            return _departmentDAL.GetAll();
        }

        public int GetDepartmentId(string  departmentName)
        {
            return _departmentDAL.GetDepartmentId(departmentName);
        }
        
    }
}
