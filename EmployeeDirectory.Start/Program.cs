using EmployeeDirectory.Bll;
using EmployeeDirectory.DAL;
using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.DAL.Roles;
using EmployeeDirectory.Presentation;
using Microsoft.Extensions.DependencyInjection;
using EmployeeDirectory.DAL.Interface.roleDAL;
using EmployeeDirectory.DAL.Interface.employeeDAL;
using EmployeeDirectory.Presentation.Interface;
using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.DAL.Interface.location;
using EmployeeDirectory.DAL.Implementation.location;
using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.BLL.Implementation.Location;
using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.DAL.Implementation.departmentDAL;
using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.BLL.Implementation.departmentBL;
namespace EmployeeDirectory.Start
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new();
            services.AddTransient<IEmployeeDAL, EmployeeDAL>();
            services.AddTransient<IRoleDAL, RoleDAL>();
            services.AddTransient<IEmployeeBL, EmployeeBL>();
            services.AddTransient<IRoleBL, RoleBL>();
            services.AddTransient<Iinput, Input>();
            services.AddTransient<IlocationDAL,LocationDAL>();
            services.AddTransient<ILocationBL,LocationBL>();
            services.AddTransient<IDepartmentDAL,DepartmentDAL>();
            services.AddTransient<IDepartmentBL,DepartmentBL>();
            var provider= services.BuildServiceProvider();
            PresentationLayer layer = new PresentationLayer(provider.GetService<IEmployeeBL>()!,provider.GetService<Iinput>()!,provider.GetService<IRoleBL>()!, provider.GetService<ILocationBL>()!, provider.GetService<IDepartmentBL>()!);
            layer.Run();
        }
    }
}
