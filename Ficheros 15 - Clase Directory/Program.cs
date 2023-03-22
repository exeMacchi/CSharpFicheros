using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_15___Clase_Directory
{
    class Program
    {
        static void Main()
        {
            /*
                En este ejercicio, se utiliza la clase Directory para leer un directorio 
                en búsqueda de archivos .png y .jpg para mostrar los nombres de estos por 
                consola. Asimismo, también se muestra por consola los nombres de los 
                subdirectorios.
            */
            string rutaDirectorio = @"Acá iría algún directorio con imágenes y subcarpetas";

            if ( !File.Exists(rutaDirectorio) )
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Error: no se ha podido leer la ruta de acceso al " +
                                  "directorio.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            string[] imgPNG = Directory.GetFiles(rutaDirectorio, "*.png");
            string[] imgJPG = Directory.GetFiles(rutaDirectorio, "*.jpg");
            string[] imgCarpetas = Directory.GetDirectories(rutaDirectorio);

            foreach(string png in imgPNG)
            {
                Console.WriteLine(png);
            }
            Console.WriteLine();

            foreach(string jpg in imgJPG)
            {
                Console.WriteLine(jpg);
            }
            Console.WriteLine();

            foreach (string carpetas in imgCarpetas)
            {
                Console.WriteLine(carpetas);
            }
        }
    }
}
