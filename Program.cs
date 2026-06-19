using EmployeeGraphQLApi.data;
using EmployeeGraphQLApi.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("EmployeesDb"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering()   // enables built-in filter support
    .AddSorting()
    .AddProjections();

var app = builder.Build();

// Seed the in-memory DB
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.MapGraphQL(); // exposes endpoint at /graphql

app.Run();