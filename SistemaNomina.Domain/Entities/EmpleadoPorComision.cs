using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Entities
{
    /// <summary>
    /// Empleado cuyo pago se calcula como un porcentaje de sus ventas brutas.
    /// </summary>
    public class EmpleadoPorComision : Empleado
    { 
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision { get; set; }

        protected EmpleadoPorComision() { }

        public EmpleadoPorComision(string primerNombre, string apellidoPaterno, string numeroSeguroSocial, decimal ventasBrutas, decimal tarifaComision)
            : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
        {
            VentasBrutas = ventasBrutas;
            TarifaComision = tarifaComision;
        }
        public override decimal CalcularSalario()
        {
            return VentasBrutas * TarifaComision;
        }

        public override string ToString()
        {
            return $"[ID: {Id}] {PrimerNombre} {ApellidoPaterno} | NSS: {NumeroSeguroSocial} | Ventas: {VentasBrutas:C} | Comisión: {TarifaComision:P} | Pago: {CalcularSalario():C}";
        }
    }
}
