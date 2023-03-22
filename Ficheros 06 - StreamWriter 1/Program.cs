using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_06___StreamWriter_1
{
    class Program
    {
        static void Main()
        {
            /* Primer acercamiento al objeto StreamWriter */

            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "ejemplo06.txt");
            
            // Declaración de un StreamWriter
            StreamWriter escritorDeFlujo = new StreamWriter(ruta, false);

            // Escribir directamente en el fichero
            escritorDeFlujo.WriteLine("Esto se escribió desde una instancia de la clase " +
                                      "StreamWriter.");
            escritorDeFlujo.WriteLine("En teoría, esto sería la segunda línea escrita en " +
                                     "este fichero de texto.");

            // IMPORTANTE: cerrar la instancia para que no se pierda el contenido del fichero
            escritorDeFlujo.Close();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Proceso de escritura exitosa.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
