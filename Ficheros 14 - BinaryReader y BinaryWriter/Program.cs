using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_14___BinaryReader_y_BinaryWriter
{
    class Program
    {
        static void Main()
        {
            /*
                Este ejercicio crea o anexa resultados double a un archivo binario.
                Los resultados se pueden ver, agregar y guardar a partir de una pequeña
                terminal.
            */

            string rutaArchivoBinario = Path.Combine(Directory.GetCurrentDirectory(), 
                                                     "ejemplo14Binario.bin");
            int cantResultados = 0;
            byte opcion = 0;
            bool salida = false;
            List<double> resultados = new List<double>();

            if (!File.Exists(rutaArchivoBinario))
            {
                CrearArchivoBinario(rutaArchivoBinario);
            }
            else
            {
                Inicio(resultados, rutaArchivoBinario, ref cantResultados);

                do
                {
                    switch (opcion)
                    {
                        case 0:
                            opcion = MostrarTerminal();
                            break;

                        case 1:
                            opcion = MostrarResultados(resultados);
                            break;

                        case 2:
                            opcion = AgregarResultado(resultados);
                            break;

                        case 3:
                            salida = true;
                            GuardarResultados(resultados, rutaArchivoBinario);
                            break;
                    }
                } while (!salida);

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Sesión finalizada con éxito.");
                Console.ResetColor();
            }
        }

        private static void CrearArchivoBinario(string rutaArchivoBinario)
        {
            BinaryWriter creador = new BinaryWriter(File.Open(rutaArchivoBinario, 
                                                              FileMode.Create));
            creador.Close();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Archivo binario creado con éxito. Reinicie el programa " +
                              "para poder utilizar sus herramientas.");
            Console.ResetColor();
            Console.ReadKey();
        }

        private static void Inicio(List<double> resultados, string direccionFichero, 
                                   ref int cantResultados)
        {
            BinaryReader inicio = new BinaryReader(File.Open(direccionFichero, 
                                                             FileMode.Open));

            cantResultados = (int) inicio.BaseStream.Length / 8;
            
            for (int i = 0; i < cantResultados; i++)
            {
                resultados.Add(inicio.ReadDouble());
            }

            inicio.Close();
        }

        private static byte MostrarTerminal()
        {
            Console.Clear();

            Console.WriteLine("============ Centro de resultados ============");
            Console.WriteLine("1. Ver todos los resultados existentes.");
            Console.WriteLine("2. Agregar nuevo resultado a la base de datos.");
            Console.WriteLine("3. Guardar y salir del programa.");

            byte opcion = 0;
            do
            {
                Console.Write("\nSeleccione una opción: ");
                opcion = Convert.ToByte(Console.ReadLine());

                if (opcion < 1 || opcion > 3)
                {
                    Console.WriteLine("Error: opción no disponible.");
                }

            } while (opcion < 1 || opcion > 3);

            return opcion;
        }

        private static byte AgregarResultado(List<double> resultados)
        {
            Console.Clear();

            Console.WriteLine("============ Agregar nuevo resultado ============");
            Console.Write("Resultado (número real): ");

            double numero = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(Environment.NewLine + numero);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"¿Es correcto el resultado? (y/n):");
            Console.ResetColor();
            Console.Write(" ");
            char respuesta = Convert.ToChar(Console.ReadLine());

            if (respuesta == 'y' || respuesta == 'Y')
            {
                resultados.Add(numero);

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Resultado añadido con éxito! Presione 'Intro' para volver " +
                              "al menú principal.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Resultado descartado. Presione 'Intro' para volver al " +
                                  "menú principal.");
                Console.ResetColor();
                Console.ReadKey();
            }

            return 0;
        }
        
        private static byte MostrarResultados(List<double> resultados)
        {
            Console.Clear();

            Console.WriteLine("============ Centro de resultados ============");
            int i = 1;
            foreach (double resultado in resultados)
            {
                Console.WriteLine($"{i}) {resultado}");
                i++;
            }

            Console.Write("\nPresione 'Intro' para volver a la menú principal.");
            Console.ReadKey();

            return 0;
        }

        private static void GuardarResultados(List<double> resultados, string direccionFichero)
        {
            BinaryWriter salida = new BinaryWriter(File.Open(direccionFichero, FileMode.Create));

            foreach (double resultado in resultados)
            {
                salida.Write(resultado);
            }

            salida.Close();
        }
    }
}
