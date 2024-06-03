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
using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.DAL.Implementation.departmentDAL;
using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.BLL.Implementation.departmentBL;
using EmployeeDirectory.Presentation.Constants;
using EmployeeDirectory.Presentation.Presentation;
using EmployeeDirectory.Models.ModelDAL;
using EmployeeDirectory.BLL.Implementation.LocationBL;
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
            services.AddSingleton<PresentationLayer>();
            services.AddSingleton<Constants>();
            services.AddSingleton<Helper>();
            services.AddSingleton<EmployeeManagment>();
            services.AddSingleton<RoleManagment>();
            services.AddSingleton<LocationManagment>();
            services.AddSingleton<DepartmentMangment>();
            services.AddSingleton<EmployeeEfContext>();
            var provider= services.BuildServiceProvider();
            var layer=provider.GetService<PresentationLayer>();
            layer.Run();
        }
    }
}
