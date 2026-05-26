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
        public EmpleadoAsalariado? ObtenerAsalariadoPorId(int id)
            => _empleadoRepository.ObtenerAsalariadoPorId(id);

        public EmpleadoPorHoras? ObtenerPorHorasPorId(int id)
            => _empleadoRepository.ObtenerPorHorasPorId(id);

        public EmpleadoPorComision? ObtenerPorComisionPorId(int id)
            => _empleadoRepository.ObtenerPorComisionPorId(id);

        public EmpleadoAsalariadoPorComision? ObtenerAsalariadoPorComisionPorId(int id)
            => _empleadoRepository.ObtenerAsalariadoPorComisionPorId(id);
        public IEnumerable<Empleado> ObtenerTodosLosEmpleados()
        {
            return _empleadoRepository.ObtenerTodosLosEmpleados();
        }
        public void ActualizarEmpleado(Empleado empleado)
        {
            _empleadoRepository.ActualizarEmpleado(empleado);
        }
        public void EliminarEmpleado(Empleado empleado)
        {
            _empleadoRepository.EliminarEmpleado(empleado);
        }
        public IEnumerable<Empleado> ReporteSemanal()
        {
            return _empleadoRepository.ObtenerTodosLosEmpleados();
        }

        
        public IEnumerable<EmpleadoAsalariado> ObtenerEmpleadosAsalariados()
        {
            return _empleadoRepository.ObtenerAsalariados();
        }

        public  IEnumerable<EmpleadoPorHoras> ObtenerEmpleadosPorHoras()
        {
            return _empleadoRepository.ObtenerPorHoras();
        }

        public IEnumerable<EmpleadoPorComision> ObtenerEmpleadosPorComision()
        {
            return _empleadoRepository.ObtenerPorComision();
        }

        public IEnumerable<EmpleadoAsalariadoPorComision> ObtenerEmpleadosAsalariadosPorComision()
        {
            return _empleadoRepository.ObtenerAsalariadosPorComision();
        }
        


    }
}
