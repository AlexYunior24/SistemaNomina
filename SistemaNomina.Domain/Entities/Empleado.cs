using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Entities
{
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


        public abstract decimal CalcularSalario();

        public override string ToString()
        {
            return $"{PrimerNombre} {ApellidoPaterno} - NSS: {NumeroSeguroSocial} - Sueldo: {CalcularSalario():C}";
        }
    }

    
}
