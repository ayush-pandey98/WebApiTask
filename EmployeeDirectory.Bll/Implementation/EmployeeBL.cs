using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.DAL.Interface.employeeDAL;
using EmployeeDirectory.Model.ModelDAL;
using EmployeeDirectory.Models.Presentation.Employee;
using EmployeeDirectory.BLL.Interface;
using EmployeeDirectory.Models.Presentation.Role;


namespace EmployeeDirectory.Bll
{
    public class EmployeeBL:IEmployeeBL
    {
        private readonly IEmployeeDAL _employeeDAL;
        private readonly IRoleDetailBL _roleDetailBL;
        private readonly IStatusBL _statusBL;
        public EmployeeBL(IEmployeeDAL employeeDAL, IRoleDetailBL roleDetailBL, IStatusBL statusBL)
        {
            _employeeDAL = employeeDAL;
            _roleDetailBL = roleDetailBL;
            _statusBL = statusBL;
        }
        public List<EmployeeDto> GetAllEmployees()
        {

            List<Employee> employeeDALList = _employeeDAL.GetAll();

            List<EmployeeDto> employeePresentationList = employeeDALList.Select(employeeDAL =>
            {
                RoleDto roleDetail = _roleDetailBL.GetRoleDetailById(employeeDAL.RoleDetailId);
                return new EmployeeDto
                {
                    Id = employeeDAL.Id,
                    FirstName = employeeDAL.FirstName,
                    LastName = employeeDAL.LastName,
                    Email = employeeDAL.Email,
                    Dob = employeeDAL.Dob,
                    PhoneNumber = employeeDAL.PhoneNumber,
                    ManagerId = employeeDAL.ManagerId,
                    Project = employeeDAL.ProjectId,
                    DepartmentId = roleDetail.DepartmentId,
                    LocationId = roleDetail.LocationId,
                    RoleId = roleDetail.Id,
                    JoiningDate = employeeDAL.JoiningDate,
                    RoleName = roleDetail.Name,
                    LocationName = roleDetail.LocationName,
                    DepartmentName = roleDetail.DepartmentName,
                };
            }).ToList();


            return employeePresentationList;
        }
        public bool AddEmployee(EmployeeDto employee)
        {
            int roleDetailId = _roleDetailBL.GetRoleDetailsId(employee.DepartmentId, employee.LocationId, employee.RoleId);
            Employee emp = new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JoiningDate = employee.JoiningDate,
                Dob = employee.Dob,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                ProjectId = employee.Project,
                ManagerId = employee.ManagerId,
                RoleDetailId = roleDetailId,
            };
            return _employeeDAL.Add(emp);
        }
        public EmployeeDto GetEmployee(string id)
        {
            Employee employeeDAL = _employeeDAL.GetById(id);
            RoleDto roleDetail = _roleDetailBL.GetRoleDetailById(employeeDAL.RoleDetailId);
            return new EmployeeDto
            {
                Id = employeeDAL.Id,
                FirstName = employeeDAL.FirstName,
                LastName = employeeDAL.LastName,
                Email = employeeDAL.Email,
                Dob = employeeDAL.Dob,
                PhoneNumber = employeeDAL.PhoneNumber,
                ManagerId=employeeDAL.ManagerId,
                Project = employeeDAL.ProjectId,
                DepartmentId = roleDetail.DepartmentId,
                LocationId = roleDetail.LocationId,
                RoleId = roleDetail.Id,
                JoiningDate = employeeDAL.JoiningDate,
                RoleName = roleDetail.Name,
                LocationName = roleDetail.LocationName,
                DepartmentName = roleDetail.DepartmentName,

            };
        }
        public bool DeleteEmployee(EmployeeDto employee)
        {
            int roleDetailId = _roleDetailBL.GetRoleDetailsId(employee.DepartmentId, employee.LocationId, employee.RoleId);
            int statusId = _statusBL.GetStatusId("Deleted");
            Employee emp = new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JoiningDate = employee.JoiningDate,
                Dob = employee.Dob,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                ProjectId = employee.Project,
                ManagerId = employee.ManagerId,
                RoleDetailId = roleDetailId,
                StatusId = statusId
            };
            return _employeeDAL.Delete(emp);
        }
        public bool EditEmployee(EmployeeDto employee,string id)
        {
            int roleDetailId = _roleDetailBL.GetRoleDetailsId(employee.DepartmentId, employee.LocationId, employee.RoleId);
            Employee emp = new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JoiningDate = employee.JoiningDate,
                Dob = employee.Dob,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                ProjectId = employee.Project,
                ManagerId = employee.ManagerId,
                RoleDetailId = roleDetailId,
                StatusId=2
            };
            return _employeeDAL.Update(emp, id);
        }

        
    }
}

