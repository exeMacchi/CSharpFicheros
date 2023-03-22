using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_10___Practica_1
{
    class Program
    {
        static void Main()
        {
            /*
                En este ejercicio, se crea un pequeño registro de inicio de sesión de 
                usuarios y de frases que este ingresa en la consola. Luego, toda la 
                información (nombre del usuario, frases y horario de ingreso) se guarda 
                en un archivo de texto.
            */

            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "ejemplo10LOG.txt");
            string usuario;

            Console.WriteLine("======================");
            Console.Write("Ingrese su usuario: ");
            usuario = Console.ReadLine();

            if (usuario != "")
            {
                string frase;
                bool huboFrase = false;
                StreamWriter escritorLog = File.AppendText(ruta);

                escritorLog.WriteLine($"Usuario: {usuario}");
                do
                {
                    Console.Write("Ingrese una frase (o no ingrese nada para finalizar " +
                                  "el proceso): ");
                    frase = Console.ReadLine();

                    if (frase != "")
                    {
                        huboFrase = true;
                        escritorLog.WriteLine($". {frase}");
                    }

                } while (frase != "");
                
                if (!huboFrase)
                {
                    escritorLog.WriteLine("* El usuario ingresó, pero no escribió ninguna " +
                                          "frase. *");
                }

                DateTime ultimaModificacion = DateTime.Now;
                escritorLog.WriteLine($"Último ingreso: {ultimaModificacion}");
                escritorLog.WriteLine("------------------------------------------------");
                escritorLog.Close();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error: usuario incorrecto.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine("======================");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Sesión finalizada. Presione 'Enter' para finalizar el programa.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
