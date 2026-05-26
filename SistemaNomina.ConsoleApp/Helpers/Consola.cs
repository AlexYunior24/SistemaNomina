using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.ConsoleApp.Helpers
{
    public static class Consola
    {
        public static decimal LeerDecimal(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (decimal.TryParse(Console.ReadLine(), out decimal resultado) && resultado >= 0)
                    return resultado;

                Console.WriteLine("Valor inválido. Ingrese un número válido.");
            }
        }

        public static int LeerEntero(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int resultado) && resultado >= 0)
                    return resultado;

                Console.WriteLine("Valor inválido. Ingrese un número entero válido.");
            }
        }

        public static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                var texto = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(texto))
                    return texto;

                Console.WriteLine("Este campo no puede estar vacío.");
            }
        }
    }
}
