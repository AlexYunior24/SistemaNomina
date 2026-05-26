using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Entities
{

    /// <summary>
    /// Clase base abstracta que representa un empleado de la empresa.
    /// Define los datos comunes y el contrato de cálculo de pago para todos los tipos de empleado.
    /// </summary>
    public abstract class Empleado 
    {
        public int Id { get; set; }
        public string? PrimerNombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string NumeroSeguroSocial { get; set; } = string.Empty;

        protected Empleado() { }


        protected Empleado(string primerNombre, string apellidoPaterno, string numeroSeguroSocial)
        {
            PrimerNombre = primerNombre; 
            ApellidoPaterno = apellidoPaterno;
            NumeroSeguroSocial = numeroSeguroSocial;
        }

        protected Empleado(string apellidoPaterno, string numeroSeguroSocial)
        {
            ApellidoPaterno = apellidoPaterno;
            NumeroSeguroSocial = numeroSeguroSocial;
        }

        /// <summary>
        /// Calcula el pago semanal del empleado según su tipo de contrato.
        /// </summary>
        /// <returns>El monto a pagar al empleado en la semana.</returns>
        public abstract decimal CalcularSalario();

        public override string ToString()
        {
            return $"[ID: {Id}] {PrimerNombre} {ApellidoPaterno} - NSS: {NumeroSeguroSocial} - Sueldo: {CalcularSalario():C}";
        }
    }

    
}
