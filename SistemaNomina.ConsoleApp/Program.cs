using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaNomina.ConsoleApp.UI;
using SistemaNomina.Data.Context;
using SistemaNomina.Data.Repositories;
using SistemaNomina.Domain.Entities;
using SistemaNomina.Services.Services;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

//var options = new DbContextOptionsBuilder<NominaDbContext>()
//    .UseSqlServer(connectionString)
//    .Options;

//using var context = new NominaDbContext(options);
//context.Database.EnsureCreated();

//var repository = new EmpleadoRepository(context);
//var service = new EmpleadoService(repository);
//var menu = new MenuPrincipal(service);

var repository = new EmpleadoRepositoryMemoria();
var service = new EmpleadoService(repository);
var menu = new MenuPrincipal(service);

// Seed data - empleados de prueba
repository.AgregarEmpleado(new EmpleadoAsalariado("Juan", "García", "123-45-6789", 5000m));
repository.AgregarEmpleado(new EmpleadoAsalariado("María", "López", "234-56-7890", 6500m));
repository.AgregarEmpleado(new EmpleadoAsalariado("Carlos", "Martínez", "345-67-8901", 4800m));

repository.AgregarEmpleado(new EmpleadoPorHoras("Pérez", "456-78-9012", 150m, 45m));
repository.AgregarEmpleado(new EmpleadoPorHoras("Rodríguez", "567-89-0123", 120m, 40m));
repository.AgregarEmpleado(new EmpleadoPorHoras("Sánchez", "678-90-1234", 200m, 38m));

repository.AgregarEmpleado(new EmpleadoPorComision("Ana", "Flores", "789-01-2345", 50000m, 0.10m));
repository.AgregarEmpleado(new EmpleadoPorComision("Luis", "Torres", "890-12-3456", 75000m, 0.08m));
repository.AgregarEmpleado(new EmpleadoPorComision("Elena", "Ramírez", "901-23-4567", 60000m, 0.12m));

repository.AgregarEmpleado(new EmpleadoAsalariadoPorComision("Pedro", "Morales", "012-34-5678", 80000m, 0.10m, 3000m));
repository.AgregarEmpleado(new EmpleadoAsalariadoPorComision("Laura", "Jiménez", "123-45-6780", 95000m, 0.09m, 3500m));
repository.AgregarEmpleado(new EmpleadoAsalariadoPorComision("Roberto", "Díaz", "234-56-7891", 70000m, 0.11m, 2800m));

menu.MostrarMenu();