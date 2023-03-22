using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_07___StreamWriter_2
{
    class Program
    {
        static void Main()
        {
            /*
                Utilizando una instancia StreamWriter, se dibuja en un archivo de texto un
                rectángulo vacío.
            */

            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "ejemplo07.txt");

            Console.Write("Altura del rectángulo: ");
            int altura = Convert.ToInt32(Console.ReadLine());

            Console.Write("Anchura del rectángulo: ");
            int anchura = Convert.ToInt32(Console.ReadLine());

            StreamWriter dibujarRectanguloFichero = new StreamWriter(ruta);

            for (int i = 0; i < altura; i++)
            {
                if (i == 0 || i == altura - 1)
                {
                    for (int j = 0; j < anchura; j++)
                    {
                        dibujarRectanguloFichero.Write("* ");
                    }
                    dibujarRectanguloFichero.WriteLine();
                }
                else
                {
                    for (int j = 0; j < anchura; j++)
                    {
                        if (j == 0 || j == anchura - 1)
                        {
                            dibujarRectanguloFichero.Write("* ");
                        }
                        else
                        {
                            dibujarRectanguloFichero.Write("  ");
                        }
                    }
                    dibujarRectanguloFichero.WriteLine();
                }
            }

            // IMPORTANTE
            dibujarRectanguloFichero.Close();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Operación exitosa.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
