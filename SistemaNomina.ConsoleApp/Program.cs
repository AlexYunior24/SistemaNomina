using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaNomina.Data.Context;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var options = new DbContextOptionsBuilder<NominaDbContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new NominaDbContext(options);
context.Database.EnsureCreated();

Console.WriteLine("Conexión exitosa a SQL Server");
Console.ReadKey();