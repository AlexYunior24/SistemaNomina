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
        Empleado? ObtenerPorId(int id);
        IEnumerable<Empleado> ObtenerTodosLosEmpleados();
        void ActualizarEmpleado(Empleado empleado);
        void EliminarEmpleado(int id);
    }
}
