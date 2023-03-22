using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_05___Clase_File_5
{
    class Program
    {
        static void Main()
        {
            /*
                En este ejercicio, se lee un archivo de texto (o se crea si no existe), 
                se eliminan los espacios redundantes (espacios de más) de su contenido, 
                y se crea otro archivo de texto pasándole el resultado final.
            */

            string rutaEspaciosRedundantes = Path.Combine(Directory.GetCurrentDirectory(), 
                                                   "ejemplo05ConEspaciosRedundantes.txt");

            string rutaSinRedundancias = Path.Combine(Directory.GetCurrentDirectory(), 
                                                   "ejemplo05SinEspaciosRedundantes.txt");
            DateTime horario = DateTime.Now;

            if ( !File.Exists(rutaEspaciosRedundantes) )
            {
                // En caso de no existir el archivo, se crea un modelo.
                string textoRedundante = "  Este    es    un        ejemplo    con  " +
                    "espacios  redundantes      .\nLuego de    la      modificación    ,  " +
                    "el      texto  debería   estar    formateado   sin   espacios   de   más" +
                    "    ."; 

                File.WriteAllText(rutaEspaciosRedundantes, textoRedundante);
            }

            string textoOriginal = File.ReadAllText(rutaEspaciosRedundantes);
            StringBuilder textoModificado = new StringBuilder("");

            string[] cadenaTextoOriginal = textoOriginal.Trim().Split(' ');

            foreach (string cadena in cadenaTextoOriginal)
            {
                if (cadena != "")
                {
                    if (cadena.Contains(',') || cadena.Contains('.'))
                    {
                        textoModificado.Append(cadena);
                    }
                    else
                    {
                        textoModificado.Append(" " + cadena);
                    }
                }
            }

            Console.WriteLine(textoModificado.ToString().Trim());

            File.WriteAllText(rutaSinRedundancias, textoModificado.ToString().Trim());
            File.AppendAllText(rutaSinRedundancias, $"\n(última modificación " +
                                                    $"{horario.ToShortDateString()})");
        }
    }
}
