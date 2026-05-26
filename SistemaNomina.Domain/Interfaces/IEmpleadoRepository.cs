using SistemaNomina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Interfaces
{
    public interface IEmpleadoRepository
    {
        void AgregarEmpleado(Empleado empleado);
        EmpleadoAsalariado? ObtenerAsalariadoPorId(int id);
        EmpleadoPorHoras? ObtenerPorHorasPorId(int id);
        EmpleadoPorComision? ObtenerPorComisionPorId(int id);
        EmpleadoAsalariadoPorComision? ObtenerAsalariadoPorComisionPorId(int id);
        IEnumerable<Empleado> ObtenerTodosLosEmpleados();
        void ActualizarEmpleado(Empleado empleado);
        void EliminarEmpleado(Empleado empleado);
        
        IEnumerable<EmpleadoAsalariado> ObtenerAsalariados();
        IEnumerable<EmpleadoPorHoras> ObtenerPorHoras();
        IEnumerable<EmpleadoPorComision> ObtenerPorComision();
        IEnumerable<EmpleadoAsalariadoPorComision> ObtenerAsalariadosPorComision();
        
    }
}
