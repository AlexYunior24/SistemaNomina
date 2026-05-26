using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNomina.Domain.Entities;
using SistemaNomina.Domain.Interfaces;


namespace SistemaNomina.Data.Repositories
{
    public class EmpleadoRepositoryMemoria : IEmpleadoRepository
    {
        private readonly List<EmpleadoAsalariado> _asalariados = new();
        private readonly List<EmpleadoPorHoras> _porHoras = new();
        private readonly List<EmpleadoPorComision> _porComision = new();
        private readonly List<EmpleadoAsalariadoPorComision> _asalariadosPorComision = new();

        private int _nextId = 1;

        public void AgregarEmpleado(Empleado empleado)
        {
            empleado.Id = _nextId++;

            switch (empleado)
            {
                case EmpleadoAsalariado a: _asalariados.Add(a); break;
                case EmpleadoPorHoras h: _porHoras.Add(h); break;
                case EmpleadoAsalariadoPorComision ac: _asalariadosPorComision.Add(ac); break;
                case EmpleadoPorComision c: _porComision.Add(c); break;
            }
        }

        public IEnumerable<Empleado> ObtenerTodosLosEmpleados()
        {
            var todos = new List<Empleado>();
            todos.AddRange(_asalariados);
            todos.AddRange(_porHoras);
            todos.AddRange(_porComision);
            todos.AddRange(_asalariadosPorComision);
            return todos;
        }

        public IEnumerable<EmpleadoAsalariado> ObtenerAsalariados() => _asalariados;
        public IEnumerable<EmpleadoPorHoras> ObtenerPorHoras() => _porHoras;
        public IEnumerable<EmpleadoPorComision> ObtenerPorComision() => _porComision;
        public IEnumerable<EmpleadoAsalariadoPorComision> ObtenerAsalariadosPorComision() => _asalariadosPorComision;

        public EmpleadoAsalariado? ObtenerAsalariadoPorId(int id)
            => _asalariados.FirstOrDefault(e => e.Id == id);

        public EmpleadoPorHoras? ObtenerPorHorasPorId(int id)
            => _porHoras.FirstOrDefault(e => e.Id == id);

        public EmpleadoPorComision? ObtenerPorComisionPorId(int id)
            => _porComision.FirstOrDefault(e => e.Id == id);

        public EmpleadoAsalariadoPorComision? ObtenerAsalariadoPorComisionPorId(int id)
            => _asalariadosPorComision.FirstOrDefault(e => e.Id == id);

        public void ActualizarEmpleado(Empleado empleado)
        {
            // En memoria los objetos se modifican por referencia
            // no necesitamos hacer nada adicional
        }

        public void EliminarEmpleado(Empleado empleado)
        {
            switch (empleado)
            {
                case EmpleadoAsalariado a: _asalariados.Remove(a); break;
                case EmpleadoPorHoras h: _porHoras.Remove(h); break;
                case EmpleadoAsalariadoPorComision ac: _asalariadosPorComision.Remove(ac); break;
                case EmpleadoPorComision c: _porComision.Remove(c); break;
            }
        }
    }
}
