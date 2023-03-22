using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficheros_13___Clase_FileStream_2
{
    class Program
    {
        static void Main()
        {
            /*
                En este ejercicio, se escribe una secuencia de bytes en un archivo de 
                texto utilizando una instancia FileStream.
            */

            string rutaSalida = Path.Combine(Directory.GetCurrentDirectory(), 
                                             "ejemplo13.txt");

            FileStream salida = File.Create(rutaSalida);
            for (int i = 0; i < 100; i++)
            {
                salida.WriteByte(97);
            }
            salida.Close();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Operación exitosa.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
