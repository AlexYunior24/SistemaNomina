using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNomina.Domain.Entities;

namespace SistemaNomina.Domain.Interfaces
{
    public interface IEmpleadoService
    {
        void AgregarEmpleado(Empleado empleado);
        Empleado? ObtenerPorId(int id);
        IEnumerable<Empleado> ObtenerTodosLosEmpleados();
        void ActualizarEmpleado(Empleado empleado);
        void EliminarEmpleado(int id);
        IEnumerable<Empleado> ReporteSemanal();
    }
}
