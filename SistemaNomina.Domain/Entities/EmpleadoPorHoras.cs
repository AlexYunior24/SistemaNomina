using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Entities
{
    public class EmpleadoPorHoras : Empleado
    {
        public decimal SueldoPorHora { get; set; }
        public decimal HorasTrabajadas { get; set; }

        protected EmpleadoPorHoras() { }

        public EmpleadoPorHoras(string apellidoPaterno, string numeroSeguroSocial, decimal sueldoPorHora, decimal horasTrabajadas)
            : base(apellidoPaterno, numeroSeguroSocial)
        {
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
        }
        public override decimal CalcularSalario()
        {
            if (HorasTrabajadas <= 40)
            {
                return SueldoPorHora * HorasTrabajadas;
            }
            else
            {
                decimal horasExtra = HorasTrabajadas - 40;
                return (SueldoPorHora * 40) + (horasExtra * SueldoPorHora * 1.5m);
            }
        }


        public override string ToString()
        {
            return $"[ID: {Id}] {ApellidoPaterno} | NSS: {NumeroSeguroSocial} | Horas: {HorasTrabajadas} | Sueldo/Hora: {SueldoPorHora:C} | Pago: {CalcularSalario():C}";
        }
    }
}
