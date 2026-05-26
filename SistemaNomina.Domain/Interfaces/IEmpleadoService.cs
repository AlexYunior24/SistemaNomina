using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNomina.Domain.Entities;

namespace SistemaNomina.Domain.Interfaces
{
    /// <summary>
    /// Contrato que define la lógica de negocio para la gestión de empleados.
    /// </summary>
    public interface IEmpleadoService
    {
        void AgregarEmpleado(Empleado empleado);
        EmpleadoAsalariado? ObtenerAsalariadoPorId(int id);
        EmpleadoPorHoras? ObtenerPorHorasPorId(int id);
        EmpleadoPorComision? ObtenerPorComisionPorId(int id);
        EmpleadoAsalariadoPorComision? ObtenerAsalariadoPorComisionPorId(int id);
        IEnumerable<Empleado> ObtenerTodosLosEmpleados();
        void ActualizarEmpleado(Empleado empleado);
        void EliminarEmpleado(Empleado empleado);
        
        IEnumerable<Empleado> ReporteSemanal();
        IEnumerable<EmpleadoAsalariado> ObtenerEmpleadosAsalariados();
        IEnumerable<EmpleadoPorHoras> ObtenerEmpleadosPorHoras();
        IEnumerable<EmpleadoPorComision> ObtenerEmpleadosPorComision();
        IEnumerable<EmpleadoAsalariadoPorComision> ObtenerEmpleadosAsalariadosPorComision();
        
    }
}
