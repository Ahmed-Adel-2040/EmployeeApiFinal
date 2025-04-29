
using Employment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employment.Infrastructure.DataContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        // Represents the Employees table in the database
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   
        }
    }
}
