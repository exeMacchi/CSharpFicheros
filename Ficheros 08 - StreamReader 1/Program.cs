using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_08___StreamReader_1
{
    class Program
    {
        static void Main()
        {
            /* Primer acercamiento a la instancia StreamReader */

            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "ejemplo08.txt");

            // Es prioritario que el archivo exista para poder leerlo con una instancia
            // de la clase StreamReader
            if ( !File.Exists(ruta) )
            {
                StreamWriter escritorFlujo = new StreamWriter(ruta, true);

                for (int i = 0; i < 15; i++)
                {
                    escritorFlujo.WriteLine($"Línea {i + 1}");
                }

                escritorFlujo.Close();
            }

            // Declaración de un StreamReader
            StreamReader lectorDeFlujo = File.OpenText(ruta);
            
            string linea;
            do
            {
                linea = lectorDeFlujo.ReadLine();
                if (linea != null)
                {
                    Console.WriteLine(linea);
                }

            } while (linea != null);

            // IMPORANTE
            lectorDeFlujo.Close();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Operación exitosa.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
