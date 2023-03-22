using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_11___Practica_2
{
    class Program
    {
        static void Main()
        {
            /*
                En este ejercicio, se crea un prototipo de convertir de HTML a texto; 
                es decir, un programa que quita las etiquetas HTML y solo deja el texto.
            */

            string rutaHTMLEntrada = "Acá va la ruta del archivo html que se quiere" +
                                     "convertir en texto.";

            string rutaTextoSalida = "Acá va la ruta del archivo de texto de salida.";
            string linea;
            bool parrafo = false;

            if (!File.Exists(rutaHTMLEntrada))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error en la lectura del archivo HTML. Verifique la ruta " +
                                  "del archivo.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            StreamReader entrada = File.OpenText(rutaHTMLEntrada);
            StreamWriter salida = File.CreateText(rutaTextoSalida);

            try
            {
                do
                {
                    linea = entrada.ReadLine();

                    if (linea != null)
                    {
                        if (linea != "")
                        {   
                            if (linea.Contains("<p>") && linea.Contains("</p>"))
                            {
                                EscrituraFichero(salida, linea);
                            }
                            else if (linea.Contains("<p>"))
                            {
                                parrafo = true;

                                EscrituraFichero(salida, linea);
                            }
                            else if (linea.Contains("</p>"))
                            {
                                EscrituraFichero(salida, linea);

                                parrafo = false;
                            }
                            else if (parrafo)
                            {
                                EscrituraFichero(salida, linea);
                            }
                        }
                    }

                } while (linea != null);

                salida.Close();
                entrada.Close();

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("En teoría, todo salió bien.");
                Console.ResetColor();

            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Error: la ruta del fichero es demasiado larga.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: el fichero no ha sido encontrado.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error en la lectura y escritura del fichero.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        static string HTMLaTXT(string linea)
        {
            string frase = "";
            string[] palabras = linea.Split(' ');

            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i] != "<p>" && palabras[i] != "</p>" && palabras[i] != "</p><p>")
                {
                    frase += palabras[i] + " ";
                }
            }

            return frase.Trim();
        }

        static void EscrituraFichero(StreamWriter salida, string linea)
        {
            string frase = HTMLaTXT(linea);

            if (frase != "")
            {
                salida.WriteLine(frase);
            }
        }
    }
}
