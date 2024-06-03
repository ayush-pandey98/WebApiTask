using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Models.ModelDAL;

public partial class EmployeeEfContext : DbContext
{
    public EmployeeEfContext()
    {
    }

    public EmployeeEfContext(DbContextOptions<EmployeeEfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=TL197;Initial Catalog=EmployeeEF;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("department");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("locations");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
