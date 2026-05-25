using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Entities
{
    public class EmpleadoAsalariadoPorComision : Empleado
    {
        public decimal SalarioBase { get; set; }
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision { get; set; }

        protected EmpleadoAsalariadoPorComision() { }

        public EmpleadoAsalariadoPorComision(string primerNombre, string apellidoPaterno, string numeroSeguroSocial, decimal ventasBrutas, decimal tarifaComision, decimal salarioBase)
            : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
        {
            SalarioBase = salarioBase;
            VentasBrutas = ventasBrutas;
            TarifaComision = tarifaComision;
        }
        public override decimal CalcularSalario()
        {
            return (VentasBrutas * TarifaComision) + SalarioBase + (SalarioBase * 0.10m);
        }
    }
}
