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

        public EmpleadoAsalariado? ObtenerAsalariadoPorId(int id)
    => _context.EmpleadosAsalariados.FirstOrDefault(e => e.Id == id);

        public EmpleadoPorHoras? ObtenerPorHorasPorId(int id)
            => _context.EmpleadosPorHoras.FirstOrDefault(e => e.Id == id);

        public EmpleadoPorComision? ObtenerPorComisionPorId(int id) 
            => _context.EmpleadosPorComision.FirstOrDefault(e => e.Id == id);

        public EmpleadoAsalariadoPorComision? ObtenerAsalariadoPorComisionPorId(int id)
            => _context.EmpleadosAsalariadosPorComision.FirstOrDefault(e => e.Id == id);

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
            switch (empleado)
            {
                case EmpleadoAsalariado asalariado:
                    _context.EmpleadosAsalariados.Update(asalariado);
                    break;
                case EmpleadoPorHoras porHoras:
                    _context.EmpleadosPorHoras.Update(porHoras);
                    break;
                case EmpleadoAsalariadoPorComision asalComision:
                    _context.EmpleadosAsalariadosPorComision.Update(asalComision);
                    break;
                case EmpleadoPorComision porComision:
                    _context.EmpleadosPorComision.Update(porComision);
                    break;
            }
            _context.SaveChanges();
        }

        public void EliminarEmpleado(Empleado empleado)
        {
            switch (empleado)
            {
                case EmpleadoAsalariado a: _context.EmpleadosAsalariados.Remove(a); break;
                case EmpleadoPorHoras h: _context.EmpleadosPorHoras.Remove(h); break;
                case EmpleadoAsalariadoPorComision ac: _context.EmpleadosAsalariadosPorComision.Remove(ac); break;
                case EmpleadoPorComision c: _context.EmpleadosPorComision.Remove(c); break;
            }
            _context.SaveChanges();
        }

        public IEnumerable<EmpleadoAsalariado> ObtenerAsalariados()
        {
            return _context.EmpleadosAsalariados.ToList();
        }

        public IEnumerable<EmpleadoPorHoras> ObtenerPorHoras()
        {
            return _context.EmpleadosPorHoras.ToList();
        }

        public IEnumerable<EmpleadoPorComision> ObtenerPorComision()
        {
            return _context.EmpleadosPorComision.ToList();
        }

        public IEnumerable<EmpleadoAsalariadoPorComision> ObtenerAsalariadosPorComision()
        {
            return _context.EmpleadosAsalariadosPorComision.ToList();
        }

    }
}
