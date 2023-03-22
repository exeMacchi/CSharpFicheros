using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_09___StreamReader_2
{
    class Program
    {
        static void Main()
        {
            /*
                En este ejercicio, utilizando instancias StreamWriter y StreamReader, 
                se lee un archivo de texto y se crea otro pasándole solo las líneas pares 
                con texto.
            */

            string rutaOriginal = Path.Combine(Directory.GetCurrentDirectory(), 
                                               "ejemplo09ImparesYPares.txt");

            string rutaModificacion = Path.Combine(Directory.GetCurrentDirectory(),
                                                   "ejemplo09SoloPares.txt");

            if ( !File.Exists(rutaOriginal) )
            {
                // En caso de no existir, se crea un modelo de uso.
                StreamWriter escritor = new StreamWriter(rutaOriginal, true);
                for (int i = 1; i <= 20; i++)
                {
                    escritor.WriteLine($"Línea {i}");
                }
                escritor.Close();
            }

            StreamReader lectorDeFlujo = File.OpenText(rutaOriginal);
            StreamWriter escritorDeFlujo = File.CreateText(rutaModificacion);

            string[] lineas = File.ReadAllLines(rutaOriginal);

            for (int i = 0; i < lineas.Length; i++)
            {
                if ( (i + 1) % 2 == 0)
                {
                    escritorDeFlujo.WriteLine(lineas[i]);
                }
            }

            // Se cierra primero el StreamWriter
            escritorDeFlujo.Close();
            lectorDeFlujo.Close();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Operación exitosa");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
