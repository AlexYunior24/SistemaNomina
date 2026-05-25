using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaNomina.Data.Context;
using SistemaNomina.Data.Repositories;
using SistemaNomina.Services.Services;
using SistemaNomina.ConsoleApp.UI;


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

var repository = new EmpleadoRepository(context);
var service = new EmpleadoService(repository);
var menu = new MenuPrincipal(service);

menu.MostrarMenu();