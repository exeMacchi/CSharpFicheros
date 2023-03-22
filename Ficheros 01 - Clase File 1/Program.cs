using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_01___Clase_File_1
{
    class Program
    {
        static void Main()
        {
            /*
                Primer acercamiento a la clase System.IO.File. 
                En este ejercicio se escriben en un archivo de texto un par de cadenas en 
                una ruta predeterminada.
            */

            // Crear una ruta de archivo basada en el directorio actual
            // (carpeta bin junto al ejecutable).
            string nombreArchivo = "ejemplo01.txt";
            string ruta = Path.Combine(Directory.GetCurrentDirectory(), nombreArchivo);

            string[] datos = new string[15];
            for (int i = 0; i < datos.Length; i++)
            {
                datos[i] = $"Línea {i + 1}";
            }

            // Crear el archivo, o sobreescribirlo, y escribir texto sobre este
            File.WriteAllLines(ruta, datos);

            // Verificar la existencia del archivo
            if (File.Exists(ruta))
            {
                // Leer el fichero de texto
                string[] datosLectura = File.ReadAllLines(ruta);

                foreach (string linea in datosLectura)
                {
                    Console.WriteLine(linea);
                }
            }
            else
            {
                Console.WriteLine("En la ruta indicada no existe o no aparece el archivo " +
                                  "que quiere abrir.");
            }
            Console.ReadKey();
        }
    }
}
