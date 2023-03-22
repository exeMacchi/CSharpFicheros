using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_03___Clase_File_3
{
    class Program
    {
        static void Main()
        {
            /*
                En este ejercicio se lee un archivo de texto con letras en minúsculas y, 
                luego, se crea un archivo de texto conviritendo todo el texto en mayúsculas. 
                Por cierto, también se eliminan las líneas vacías.
            */

            string rutaMinusculas = Path.Combine(Directory.GetCurrentDirectory(), 
                                                 "ejemplo03Minusculas.txt");

            string rutaMayusculas = Path.Combine(Directory.GetCurrentDirectory(),
                                                 "ejemplo03Mayusculas.txt");

            if ( !File.Exists(rutaMinusculas) )
            {
                // En caso de no existir el archivo, se crea un modelo de uso.
                File.CreateText(rutaMinusculas).Close();

                string[] lineasMin = new string[]
                {
                    "Esta es una línea en minúsculas.",
                    "Despúés de la conversión todo esto estará en mayúsculas.",
                    "",
                    "Por cierto, también se eliminarán las líneas vacías, como la que " +
                    "estaba arriba de esta línea."
                };

                File.WriteAllLines(rutaMinusculas, lineasMin);
            }

            string[] lineasMinusculas = File.ReadAllLines(rutaMinusculas);

            List<string> listaLineas = new List<string>(lineasMinusculas);

            for (int i = 0; i < listaLineas.Count; i++)
            {
                if (listaLineas[i].Trim() == "")
                {
                    listaLineas.RemoveAt(i);
                    i--;
                }
                else
                {
                    listaLineas[i] = listaLineas[i].ToUpper();
                }
            }

            File.WriteAllLines(rutaMayusculas, listaLineas.ToArray());

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Conversión existosa!");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
