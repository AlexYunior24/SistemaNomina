using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaNomina.Data.Context;
using SistemaNomina.Domain.Entities;
using SistemaNomina.Domain.Interfaces;

namespace SistemaNomina.Data.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly NominaDbContext _context;

        public EmpleadoRepository(NominaDbContext context)
        {
            _context = context;
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            _context.Add(empleado);
            _context.SaveChanges();
        }

        public Empleado? ObtenerPorId(int id)
        {
            return _context.EmpleadosAsalariados.FirstOrDefault(e => e.Id == id)
                ?? _context.EmpleadosPorHoras.FirstOrDefault(e => e.Id == id)
                ?? _context.EmpleadosPorComision.FirstOrDefault(e => e.Id == id)
                ?? (Empleado?)_context.EmpleadosAsalariadosPorComision.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Empleado> ObtenerTodosLosEmpleados()
        {
            var todosEmpleados = new List<Empleado>();

            todosEmpleados.AddRange(_context.EmpleadosAsalariados);
            todosEmpleados.AddRange(_context.EmpleadosPorHoras);
            todosEmpleados.AddRange(_context.EmpleadosPorComision);
            todosEmpleados.AddRange(_context.EmpleadosAsalariadosPorComision);
            return todosEmpleados;
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            _context.Update(empleado);
            _context.SaveChanges();
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
                _context.Remove(empleado);
                _context.SaveChanges();
            }
        }

    }
}
