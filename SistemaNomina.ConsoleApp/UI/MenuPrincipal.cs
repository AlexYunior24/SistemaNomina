using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNomina.Domain.Entities;
using SistemaNomina.Domain.Interfaces;

namespace SistemaNomina.ConsoleApp.UI
{
    public class MenuPrincipal
    {
        private readonly IEmpleadoService _service;

        public MenuPrincipal(IEmpleadoService service)
        {
            _service = service;
        }

        public void MostrarMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Nómina ===");
                Console.WriteLine("1. Gestion de Empleados");
                Console.WriteLine("2. Reporte Semanal");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MenuGestionEmpleados();
                        break;
                    case "2":
                        MostrarReporteSemanal();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void MenuGestionEmpleados()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("     GESTIÓN DE EMPLEADOS       ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Agregar Empleado");
            Console.WriteLine("2. Ver todos los Empleados");
            Console.WriteLine("3. Actualizar Empleado");
            Console.WriteLine("4. Eliminar Empleado");
            Console.WriteLine("0. Volver");
            Console.WriteLine("=================================");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AgregarEmpleado();
                    break;
                case "2":
                    VerTodosLosEmpleados();
                    break;
                case "3":
                    ActualizarEmpleado();
                    break;
                case "4":
                    EliminarEmpleado();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
            }
        }

        private void AgregarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       AGREGAR EMPLEADO         ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Empleado Asalariado");
            Console.WriteLine("2. Empleado por Horas");
            Console.WriteLine("3. Empleado por Comisión");
            Console.WriteLine("4. Empleado Asalariado por Comisión");
            Console.WriteLine("0. Volver");
            Console.WriteLine("=================================");
            Console.Write("Seleccione el tipo: ");

            switch (Console.ReadLine())
            {
                case "1": AgregarAsalariado(); break;
                case "2": AgregarPorHoras(); break;
                case "3": AgregarPorComision(); break;
                case "4": AgregarAsalariadoPorComision(); break;
                case "0": break;
            }
        }

        private void AgregarAsalariado()
        {
            Console.Clear();
            Console.WriteLine("-- Nuevo Empleado Asalariado --");

            Console.Write("Primer Nombre: ");
            var nombre = Console.ReadLine() ?? string.Empty;

            Console.Write("Apellido Paterno: ");
            var apellido = Console.ReadLine() ?? string.Empty;

            Console.Write("Número de Seguro Social: ");
            var nss = Console.ReadLine() ?? string.Empty;

            Console.Write("Salario Semanal: ");
            var salario = decimal.Parse(Console.ReadLine() ?? "0");

            _service.AgregarEmpleado(new EmpleadoAsalariado(nombre, apellido, nss, salario));

            Console.WriteLine("\n✅ Empleado agregado exitosamente. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private void AgregarPorHoras()
        {
            Console.Clear();
            Console.WriteLine("-- Nuevo Empleado por Horas --");

            Console.Write("Apellido Paterno: ");
            var apellido = Console.ReadLine() ?? string.Empty;

            Console.Write("Número de Seguro Social: ");
            var nss = Console.ReadLine() ?? string.Empty;

            Console.Write("Sueldo por Hora: ");
            var sueldoHora = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Horas Trabajadas: ");
            var horas = decimal.Parse(Console.ReadLine() ?? "0");

            _service.AgregarEmpleado(new EmpleadoPorHoras(apellido, nss, sueldoHora, horas));

            Console.WriteLine("\n✅ Empleado agregado exitosamente. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private void AgregarPorComision()
        {
            Console.Clear();
            Console.WriteLine("-- Nuevo Empleado por Comisión --");

            Console.Write("Primer Nombre: ");
            var nombre = Console.ReadLine() ?? string.Empty;

            Console.Write("Apellido Paterno: ");
            var apellido = Console.ReadLine() ?? string.Empty;

            Console.Write("Número de Seguro Social: ");
            var nss = Console.ReadLine() ?? string.Empty;

            Console.Write("Ventas Brutas: ");
            var ventas = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Tarifa de Comisión (ej: 0.10 para 10%): ");
            var tarifa = decimal.Parse(Console.ReadLine() ?? "0");

            _service.AgregarEmpleado(new EmpleadoPorComision(nombre, apellido, nss, ventas, tarifa));

            Console.WriteLine("\n✅ Empleado agregado exitosamente. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private void AgregarAsalariadoPorComision()
        {
            Console.Clear();
            Console.WriteLine("-- Nuevo Empleado Asalariado por Comisión --");

            Console.Write("Primer Nombre: ");
            var nombre = Console.ReadLine() ?? string.Empty;

            Console.Write("Apellido Paterno: ");
            var apellido = Console.ReadLine() ?? string.Empty;

            Console.Write("Número de Seguro Social: ");
            var nss = Console.ReadLine() ?? string.Empty;

            Console.Write("Ventas Brutas: ");
            var ventas = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Tarifa de Comisión (ej: 0.10 para 10%): ");
            var tarifa = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Salario Base: ");
            var salarioBase = decimal.Parse(Console.ReadLine() ?? "0");

            _service.AgregarEmpleado(new EmpleadoAsalariadoPorComision(nombre, apellido, nss, ventas, tarifa, salarioBase));

            Console.WriteLine("\n✅ Empleado agregado exitosamente. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private void VerTodosLosEmpleados()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       LISTA DE EMPLEADOS       ");
            Console.WriteLine("=================================");

            var empleados = _service.ObtenerTodosLosEmpleados();

            if (!empleados.Any())
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                foreach (var empleado in empleados)
                {
                    Console.WriteLine(empleado.ToString());
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        private void ActualizarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("      ACTUALIZAR EMPLEADO       ");
            Console.WriteLine("=================================");

            VerTodosLosEmpleados();

            Console.Write("Ingrese el ID del empleado a actualizar: ");
            var id = int.Parse(Console.ReadLine() ?? "0");

            var empleado = _service.ObtenerPorId(id);

            if (empleado == null)
            {
                Console.WriteLine("❌ Empleado no encontrado. Presione cualquier tecla...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nEmpleado encontrado: {empleado}");
            Console.WriteLine("Ingrese los nuevos datos:");

            switch (empleado)
            {
                case EmpleadoAsalariado asalariado:
                    Console.Write("Nuevo Salario Semanal: ");
                    asalariado.SalarioSemanal = decimal.Parse(Console.ReadLine() ?? "0");
                    break;

                case EmpleadoPorHoras porHoras:
                    Console.Write("Nuevo Sueldo por Hora: ");
                    porHoras.SueldoPorHora = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nuevas Horas Trabajadas: ");
                    porHoras.HorasTrabajadas = decimal.Parse(Console.ReadLine() ?? "0");
                    break;

                case EmpleadoAsalariadoPorComision asalComision:
                    Console.Write("Nuevas Ventas Brutas: ");
                    asalComision.VentasBrutas = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nueva Tarifa de Comisión: ");
                    asalComision.TarifaComision = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nuevo Salario Base: ");
                    asalComision.SalarioBase = decimal.Parse(Console.ReadLine() ?? "0");
                    break;

                case EmpleadoPorComision porComision:
                    Console.Write("Nuevas Ventas Brutas: ");
                    porComision.VentasBrutas = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nueva Tarifa de Comisión: ");
                    porComision.TarifaComision = decimal.Parse(Console.ReadLine() ?? "0");
                    break;
            }

            _service.ActualizarEmpleado(empleado);
            Console.WriteLine("\n✅ Empleado actualizado. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private void EliminarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       ELIMINAR EMPLEADO        ");
            Console.WriteLine("=================================");

            VerTodosLosEmpleados();

            Console.Write("Ingrese el ID del empleado a eliminar: ");
            var id = int.Parse(Console.ReadLine() ?? "0");

            var empleado = _service.ObtenerPorId(id);

            if (empleado == null)
            {
                Console.WriteLine("❌ Empleado no encontrado. Presione cualquier tecla...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\n¿Está seguro que desea eliminar a {empleado.PrimerNombre} {empleado.ApellidoPaterno}? (S/N): ");

            if (Console.ReadLine()?.ToUpper() == "S")
            {
                _service.EliminarEmpleado(id);
                Console.WriteLine("✅ Empleado eliminado. Presione cualquier tecla...");
            }
            else
            {
                Console.WriteLine("Operación cancelada. Presione cualquier tecla...");
            }

            Console.ReadKey();
        }

        private void MostrarReporteSemanal()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       REPORTE SEMANAL          ");
            Console.WriteLine("=================================");

            var empleados = _service.ReporteSemanal();

            if (!empleados.Any())
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                decimal totalNomina = 0;

                foreach (var empleado in empleados)
                {
                    Console.WriteLine(empleado.ToString());
                    totalNomina += empleado.CalcularSalario();
                }

                Console.WriteLine("=================================");
                Console.WriteLine($"Total Nómina Semanal: {totalNomina:C}");
                Console.WriteLine("=================================");
            }

            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }
    }
}

