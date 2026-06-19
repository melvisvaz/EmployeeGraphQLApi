using EmployeeGraphQLApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeGraphQLApi.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Alice", LastName = "Smith", Email = "alice@company.com", Department = "Engineering", Salary = 95000 },
                new Employee { Id = 2, FirstName = "Bob", LastName = "Jones", Email = "bob@company.com", Department = "Sales", Salary = 70000 },
                new Employee { Id = 3, FirstName = "Carol", LastName = "Lee", Email = "carol@company.com", Department = "Engineering", Salary = 105000 }
            );
        }
    }
}
