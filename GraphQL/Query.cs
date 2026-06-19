using EmployeeGraphQLApi.data;
using EmployeeGraphQLApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeGraphQLApi.GraphQL
{
    public class Query
    {
        public IQueryable<Employee> GetEmployees([Service] AppDbContext context) =>
            context.Employees;

        public async Task<IEnumerable<Employee>> SearchEmployees(
            [Service] AppDbContext context,
            string? name,
            string? department)
        {
            var query = context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(e =>
                    e.FirstName.Contains(name) || e.LastName.Contains(name));

            if (!string.IsNullOrWhiteSpace(department))
                query = query.Where(e => e.Department == department);

            var data =  await query.ToListAsync();
            return data;
        }
    }
}
