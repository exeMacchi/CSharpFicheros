using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_02___Clase_File_2
{
    class Program
    {
        static void Main()
        {
            /* 
                En este ejercicio, se lee un archivo de texto con líneas de texto y líneas 
                vacías. El objetivo es crear un nuevo archivo de texto escribiendo el 
                contenido del archivo original, pero eliminando las  líneas vacías.
            */

            // Ruta archivo con líneas vacías
            string rutaLineasVacias = Path.Combine(Directory.GetCurrentDirectory(), 
                                                   "ejemplo02ConLineasVacias.txt");

            // Ruta archivo donde se vuelca el contenido sin las líneas vacías.
            string rutaSinLineasVacias = Path.Combine(Directory.GetCurrentDirectory(),
                                                      "ejemplo02SinLineasVacias.txt");

            if (!File.Exists(rutaLineasVacias))
            {
                // Si no existe el archivo, se crea un modelo de uso.
                File.CreateText(rutaLineasVacias).Close();

                string[] vlineas = new string[3];
                vlineas[0] = "Esta es una línea con contenido.";
                vlineas[1] = "\n";
                vlineas[2] = "Esta es una línea post líneas vacías, en teoría, después de " +
                             "la modificación, debería aparecer debajo de la anterior línea.";

                File.WriteAllLines(rutaLineasVacias, vlineas);
            }

            string[] lineas = File.ReadAllLines(rutaLineasVacias);

            // Se crea una lista para poder remover con facilidad el contenido vacío.
            List<string> listaLineas = new List<string>(lineas);

            // Se verifica línea por línea, sin espacios de por medio, si existe una línea vacía.
            // En caso de existir, se remueve y se continúa con las demás.
            for (int i = 0; i < listaLineas.Count; i++)
            {
                if (listaLineas[i].Trim() == "")
                {
                    listaLineas.RemoveAt(i);
                    i--;
                }
            }

            // Luego se vuelca todo el contenido de la lista al fichero nuevo.
            File.WriteAllLines(rutaSinLineasVacias, listaLineas.ToArray());

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Operación realizada con éxito.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
