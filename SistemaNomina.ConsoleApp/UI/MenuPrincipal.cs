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
                        MenuReporteSemanal();
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
            Console.WriteLine("2. Ver Empleados");
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
                    MenuVerEmpleados();
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

            Console.WriteLine("\nEmpleado agregado exitosamente. Presione cualquier tecla...");
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

            Console.WriteLine("\nEmpleado agregado exitosamente. Presione cualquier tecla...");
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

            Console.WriteLine("\nEmpleado agregado exitosamente. Presione cualquier tecla...");
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

            Console.WriteLine("\nEmpleado agregado exitosamente. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private void MenuVerEmpleados()
        {

            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       VER EMPLEADOS            ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Todos los Empleados");
            Console.WriteLine("2. Empleados Asalariados");
            Console.WriteLine("3. Empleados por Horas");
            Console.WriteLine("4. Empleados por Comisión");
            Console.WriteLine("5. Empleados Asalariados por Comisión");
            Console.WriteLine("0. Volver");
            Console.WriteLine("=================================");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1": MostrarEmpleados("Todos", _service.ObtenerTodosLosEmpleados()); break;
                case "2": MostrarEmpleados("Asalariados", _service.ObtenerEmpleadosAsalariados()); break;
                case "3": MostrarEmpleados("Por Horas", _service.ObtenerEmpleadosPorHoras()); break;
                case "4": MostrarEmpleados("Por Comisión", _service.ObtenerEmpleadosPorComision()); break;
                case "5": MostrarEmpleados("Asalariados por Comisión", _service.ObtenerEmpleadosAsalariadosPorComision()); break;
                case "0": break;
                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
            }
        }

        private void MostrarEmpleados(string tipo, IEnumerable<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine($"   EMPLEADOS {tipo.ToUpper()}");
            Console.WriteLine("=================================");

            if (!empleados.Any())
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                foreach (var empleado in empleados)
                {
                    Console.WriteLine(empleado.ToString());
                    Console.WriteLine("---------------------------------");
                }
                Console.WriteLine($"Total: {empleados.Count()} empleado(s)");
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
            Console.WriteLine("1. Empleado Asalariado");
            Console.WriteLine("2. Empleado por Horas");
            Console.WriteLine("3. Empleado por Comisión");
            Console.WriteLine("4. Empleado Asalariado por Comisión");
            Console.WriteLine("0. Volver");
            Console.WriteLine("=================================");
            Console.Write("Seleccione el tipo: ");

            switch (Console.ReadLine())
            {
                case "1":
                    MostrarEmpleados("Asalariados", _service.ObtenerEmpleadosAsalariados());
                    Console.Write("Ingrese el ID: ");
                    var idAsal = int.Parse(Console.ReadLine() ?? "0");
                    var asalariado = _service.ObtenerAsalariadoPorId(idAsal);
                    if (asalariado == null) { MostrarNoEncontrado(); return; }
                    Console.Write("Nuevo Salario Semanal: ");
                    asalariado.SalarioSemanal = decimal.Parse(Console.ReadLine() ?? "0");
                    _service.ActualizarEmpleado(asalariado);
                    MostrarExito("actualizado");
                    break;

                case "2":
                    MostrarEmpleados("Por Horas", _service.ObtenerEmpleadosPorHoras());
                    Console.Write("Ingrese el ID: ");
                    var idHoras = int.Parse(Console.ReadLine() ?? "0");
                    var porHoras = _service.ObtenerPorHorasPorId(idHoras);
                    if (porHoras == null) { MostrarNoEncontrado(); return; }
                    Console.Write("Nuevo Sueldo por Hora: ");
                    porHoras.SueldoPorHora = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nuevas Horas Trabajadas: ");
                    porHoras.HorasTrabajadas = decimal.Parse(Console.ReadLine() ?? "0");
                    _service.ActualizarEmpleado(porHoras);
                    MostrarExito("actualizado");
                    break;

                case "3":
                    MostrarEmpleados("Por Comisión", _service.ObtenerEmpleadosPorComision());
                    Console.Write("Ingrese el ID: ");
                    var idCom = int.Parse(Console.ReadLine() ?? "0");
                    var porComision = _service.ObtenerPorComisionPorId(idCom);
                    if (porComision == null) { MostrarNoEncontrado(); return; }
                    Console.Write("Nuevas Ventas Brutas: ");
                    porComision.VentasBrutas = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nueva Tarifa de Comisión: ");
                    porComision.TarifaComision = decimal.Parse(Console.ReadLine() ?? "0");
                    _service.ActualizarEmpleado(porComision);
                    MostrarExito("actualizado");
                    break;

                case "4":
                    MostrarEmpleados("Asalariados por Comisión", _service.ObtenerEmpleadosAsalariadosPorComision());
                    Console.Write("Ingrese el ID: ");
                    var idAC = int.Parse(Console.ReadLine() ?? "0");
                    var asalComision = _service.ObtenerAsalariadoPorComisionPorId(idAC);
                    if (asalComision == null) { MostrarNoEncontrado(); return; }
                    Console.Write("Nuevas Ventas Brutas: ");
                    asalComision.VentasBrutas = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nueva Tarifa de Comisión: ");
                    asalComision.TarifaComision = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nuevo Salario Base: ");
                    asalComision.SalarioBase = decimal.Parse(Console.ReadLine() ?? "0");
                    _service.ActualizarEmpleado(asalComision);
                    MostrarExito("actualizado");
                    break;
            }
        }

        private void EliminarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       ELIMINAR EMPLEADO        ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Empleado Asalariado");
            Console.WriteLine("2. Empleado por Horas");
            Console.WriteLine("3. Empleado por Comisión");
            Console.WriteLine("4. Empleado Asalariado por Comisión");
            Console.WriteLine("0. Volver");
            Console.WriteLine("=================================");
            Console.Write("Seleccione el tipo: ");

            Empleado? empleado = Console.ReadLine() switch
            {
                "1" => ObtenerEmpleadoParaEliminar(_service.ObtenerEmpleadosAsalariados(),
                           id => _service.ObtenerAsalariadoPorId(id)),
                "2" => ObtenerEmpleadoParaEliminar(_service.ObtenerEmpleadosPorHoras(),
                           id => _service.ObtenerPorHorasPorId(id)),
                "3" => ObtenerEmpleadoParaEliminar(_service.ObtenerEmpleadosPorComision(),
                           id => _service.ObtenerPorComisionPorId(id)),
                "4" => ObtenerEmpleadoParaEliminar(_service.ObtenerEmpleadosAsalariadosPorComision(),
                           id => _service.ObtenerAsalariadoPorComisionPorId(id)),
                _ => null
            };

            if (empleado == null) return;

            Console.WriteLine($"\n¿Está seguro que desea eliminar a {empleado.PrimerNombre} {empleado.ApellidoPaterno}? (S/N): ");

            if (Console.ReadLine()?.ToUpper() == "S")
            {
                _service.EliminarEmpleado(empleado);
                MostrarExito("eliminado");
            }
            else
            {
                Console.WriteLine("Operación cancelada. Presione cualquier tecla...");
                Console.ReadKey();
            }
        }

        private Empleado? ObtenerEmpleadoParaEliminar(IEnumerable<Empleado> lista, Func<int, Empleado?> buscar)
        {
            MostrarEmpleados("", lista);
            Console.Write("Ingrese el ID: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            var empleado = buscar(id);
            if (empleado == null) MostrarNoEncontrado();
            return empleado;
        }

        private void MostrarNoEncontrado()
        {
            Console.WriteLine("❌ Empleado no encontrado. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private void MostrarExito(string accion)
        {
            Console.WriteLine($"\nEmpleado {accion} exitosamente. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private void MenuReporteSemanal()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       REPORTE SEMANAL          ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Reporte General");
            Console.WriteLine("2. Reporte Asalariados");
            Console.WriteLine("3. Reporte por Horas");
            Console.WriteLine("4. Reporte por Comisión");
            Console.WriteLine("5. Reporte Asalariados por Comisión");
            Console.WriteLine("0. Volver");
            Console.WriteLine("=================================");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1": MostrarReporte("General", _service.ReporteSemanal()); break;
                case "2": MostrarReporte("Asalariados", _service.ObtenerEmpleadosAsalariados()); break;
                case "3": MostrarReporte("Por Horas", _service.ObtenerEmpleadosPorHoras()); break;
                case "4": MostrarReporte("Por Comisión", _service.ObtenerEmpleadosPorComision()); break;
                case "5": MostrarReporte("Asalariados por Comisión", _service.ObtenerEmpleadosAsalariadosPorComision()); break;
                case "0": break;
                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
            }
        }

        private void MostrarReporte(string tipo, IEnumerable<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine($"   REPORTE SEMANAL {tipo.ToUpper()}");
            Console.WriteLine("=================================");

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
                    Console.WriteLine("---------------------------------");
                    totalNomina += empleado.CalcularSalario();
                }

                Console.WriteLine("=================================");
                Console.WriteLine($"Total Nómina: {totalNomina:C}");
                Console.WriteLine("=================================");
            }

            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }
    }
}

