using EmployeeDirectory.Bll;
using EmployeeDirectory.DAL;
using EmployeeDirectory.Bll.Interface;
using EmployeeDirectory.DAL.Roles;
using EmployeeDirectory.Presentation;
using Microsoft.Extensions.DependencyInjection;
using EmployeeDirectory.DAL.Interface;
using EmployeeDirectory.Presentation.Interface;
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
            var provider= services.BuildServiceProvider();
            PresentationLayer layer = new PresentationLayer(provider.GetService<IEmployeeBL>()!,provider.GetService<Iinput>()!,provider.GetService<IRoleBL>()!);
            layer.Run();
        }
    }
}
