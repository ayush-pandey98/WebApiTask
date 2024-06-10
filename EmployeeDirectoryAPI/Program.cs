using System.Text;
using EmployeeDirectory.Bll;
using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.BLL.Implementation;
using EmployeeDirectory.BLL.Implementation.departmentBL;
using EmployeeDirectory.BLL.Implementation.LocationBL;
using EmployeeDirectory.BLL.Interface;
using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.DAL;
using EmployeeDirectory.DAL.Implementation;
using EmployeeDirectory.DAL.Implementation.departmentDAL;
using EmployeeDirectory.DAL.Implementation.location;
using EmployeeDirectory.DAL.Interface;
using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.DAL.Interface.employeeDAL;
using EmployeeDirectory.DAL.Interface.location;
using EmployeeDirectory.DAL.Interface.roleDAL;
using EmployeeDirectory.DAL.Roles;
using EmployeeDirectory.Model.ModelDAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeDirectoryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEmployeeDAL, EmployeeDAL>();
            builder.Services.AddScoped<IRoleDAL, RoleDAL>();
            builder.Services.AddScoped<IEmployeeBL, EmployeeBL>();
            builder.Services.AddScoped<IRoleBL, RoleBL>();
            builder.Services.AddScoped<IlocationDAL, LocationDAL>();
            builder.Services.AddScoped<ILocationBL, LocationBL>();
            builder.Services.AddScoped<IDepartmentDAL, DepartmentDAL>();
            builder.Services.AddScoped<IDepartmentBL, DepartmentBL>();
            builder.Services.AddScoped<IRoleDetailBL,RoleDetailBL>();
            builder.Services.AddScoped<IRoleDetailsDAL,RoleDetailDAL>();
            builder.Services.AddScoped<EmployeeDirectoryDbContext>();
            builder.Services.AddScoped<IStatusDAL,StatusDAL>();
            builder.Services.AddScoped<IStatusBL,StatusBL>();
            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
