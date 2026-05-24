using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNomina.Domain.Entities;
using SistemaNomina.Domain.Interfaces;

namespace SistemaNomina.Data.Repositories
{
    internal class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly List<Empleado> _empleados = new();
        private int _nextId = 1;
        public void AgregarEmpleado(Empleado empleado)
        {
            empleado.Id = _nextId++;
            _empleados.Add(empleado);
        }
        public Empleado? ObtenerPorId(int id)
        {
            return _empleados.FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<Empleado> ObtenerTodosLosEmpleados()
        {
            return _empleados;
        }
        public void ActualizarEmpleado(Empleado empleado)
        {
            var index = _empleados.FindIndex(e => e.Id == empleado.Id);
            if (index == -1)
            {
                throw new KeyNotFoundException($"No se encontró el empleado con Id {empleado.Id}");
            }

            _empleados[index] = empleado;
        }
        public void EliminarEmpleado(int id)
        {
            var empleado = ObtenerPorId(id);
            if (empleado == null)
            {
                throw new KeyNotFoundException($"No se encontró el empleado con Id {id}");
            }
            else
            {
                _empleados.Remove(empleado);
            }
        }

    }
}
