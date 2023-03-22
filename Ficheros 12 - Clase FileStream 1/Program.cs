using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheros_12___Clase_FileStream_1
{
    class Program
    {
        static void Main()
        {
            /*
                Acercamiento a los archivos binarios. En este ejercicio, se analiza si un
                archivo .gif es un archivo gif válido y, si lo es, en qué versión se codificó.
            */

            string direccionGIF = "Acá iría la ruta del archivo .gif que se quiere analizar";

            if ( !File.Exists(direccionGIF) )
            {
                Console.WriteLine("Error: el archivo no se encontró en la ruta especificada");
                return;
            }
            
            // Tamaño de la información que quiero leer
            int tamanio = 6; 
            
            // Vector que guardará la cantidad de bytes especificada.
            byte[] headerGIF = new byte[tamanio]; 
            
            // El índice desde dónde contar los bytes.
            int indice = 0; 

            // Lo que se espera leer.
            int cantidadALeer = tamanio; 

            FileStream gif = File.OpenRead(direccionGIF);
            int cantidadLeida = gif.Read(headerGIF, indice, cantidadALeer);
            gif.Close();

            if (cantidadLeida < cantidadALeer)
            {
                Console.WriteLine("La cabecera del archivo está incompleta.");
            }
            else
            {
                if (headerGIF[0] == 'G' && headerGIF[1] == 'I' && headerGIF[2] == 'F')
                {
                    Console.WriteLine("Es un GIF válido!");

                    if (headerGIF[3] == '8' && headerGIF[4] == '7' && headerGIF[5] == 'a')
                    {
                        Console.WriteLine("Este GIF se codificó en la versión: GIF87a");
                    }
                    else if (headerGIF[3] == '8' && headerGIF[4] == '9' && headerGIF[5] == 'a')
                    {
                        Console.WriteLine("Este GIF se codificó en la versión: GIF89a");
                    }
                }
                else
                {
                    Console.WriteLine("Este archivo no es un un GIF válido.");
                }
            }
        }
    }
}
