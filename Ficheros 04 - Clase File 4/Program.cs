using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_04___Clase_File_4
{
    class Program
    {
        static void Main()
        {
            /*
                En este ejercicio se verifica la existencia de un archivo de texto en una
                ruta especificada. Si no existe el archivo, se crea el archivo, se escribe
                texto en él y se muestra en la consola el contenido. En cambio, si se 
                verifica la existencia del archivo de texto, se convierte todo su contenido
                de minúsculas a mayúsculas y, luego, se muestra el resultado en la consola. 
            */

            string rutaTexto = Path.Combine(Directory.GetCurrentDirectory(), 
                                            "ejemplo04.txt");

            string cadenaTexto = "Ejemplo de cadena de texto." +
                                 "\nCuando se cree el archivo de texto por primera vez, " +
                                 "este estará en minúsculas." +
                                 "\nCuando se verifique la existencia de este " +
                                 "archivo otra vez, el texto se convertirá en mayúsculas.";
            string cadenaArchivo;

            if (!File.Exists(rutaTexto))
            {
                File.WriteAllText(rutaTexto, cadenaTexto);
                cadenaArchivo = File.ReadAllText(rutaTexto);
                Console.WriteLine(cadenaArchivo);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Creación exitosa.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                File.WriteAllText(rutaTexto, cadenaTexto.ToUpper());
                cadenaArchivo = File.ReadAllText(rutaTexto);
                Console.WriteLine(cadenaArchivo);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Conversión exitosa.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
