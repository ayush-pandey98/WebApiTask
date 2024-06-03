using EmployeeDirectory.Bll;
using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.BLL.Implementation.departmentBL;
using EmployeeDirectory.BLL.Implementation.LocationBL;
using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.DAL;
using EmployeeDirectory.DAL.Implementation.departmentDAL;
using EmployeeDirectory.DAL.Implementation.location;
using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.DAL.Interface.employeeDAL;
using EmployeeDirectory.DAL.Interface.location;
using EmployeeDirectory.DAL.Interface.roleDAL;
using EmployeeDirectory.DAL.Roles;
using EmployeeDirectory.Models.ModelDAL;

namespace EDAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IEmployeeDAL, EmployeeDAL>();
            builder.Services.AddTransient<IRoleDAL, RoleDAL>();
            builder.Services.AddTransient<IEmployeeBL, EmployeeBL>();
            builder.Services.AddTransient<IRoleBL, RoleBL>();
            builder.Services.AddTransient<IlocationDAL, LocationDAL>();
            builder.Services.AddTransient<ILocationBL, LocationBL>();
            builder.Services.AddTransient<IDepartmentDAL, DepartmentDAL>();
            builder.Services.AddTransient<IDepartmentBL, DepartmentBL>();
            builder.Services.AddScoped<EmployeeEfContext>();
           // builder.Services.AddScoped<DepartmentController>();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
