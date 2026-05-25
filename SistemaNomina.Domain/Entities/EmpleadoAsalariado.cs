using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Entities
{
    public class EmpleadoAsalariado : Empleado
    {
        public decimal SalarioSemanal { get; set; }

        protected EmpleadoAsalariado() { }

        public EmpleadoAsalariado(string primerNombre, string apellidoPaterno, string numeroSeguroSocial, decimal salarioSemanal)
            : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
        {
            SalarioSemanal = salarioSemanal;
        }

        public override decimal CalcularSalario()
        {
            return SalarioSemanal;
        }
    }
}
