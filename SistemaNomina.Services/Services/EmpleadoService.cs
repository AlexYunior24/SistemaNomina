using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNomina.Domain.Entities;
using SistemaNomina.Domain.Interfaces;

namespace SistemaNomina.Services.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }
        public void AgregarEmpleado(Empleado empleado)
        {
            _empleadoRepository.AgregarEmpleado(empleado);
        }
        public Empleado? ObtenerPorId(int id)
        {
            return _empleadoRepository.ObtenerPorId(id);
        }
        public IEnumerable<Empleado> ObtenerTodosLosEmpleados()
        {
            return _empleadoRepository.ObtenerTodosLosEmpleados();
        }
        public void ActualizarEmpleado(Empleado empleado)
        {
            _empleadoRepository.ActualizarEmpleado(empleado);
        }
        public void EliminarEmpleado(int id)
        {
            _empleadoRepository.EliminarEmpleado(id);
        }
        public IEnumerable<Empleado> ReporteSemanal()
        {
            return _empleadoRepository.ObtenerTodosLosEmpleados();
        }
    }
}
