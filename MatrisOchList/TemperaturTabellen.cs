using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace MatrisOchList
{
    internal class TemperaturTabellen
    {

        public static void Show()
        {

            //Skapa en matris med 3 rader och 3 kolumner
            int[,] temperature =
            {
                {23, 18, 12 },
                {19, 22, 11 },
                {21, 18, 10 }
            };


            //Gör en array som sparar alla städer
            string[] cities = { "Eskilstuna", "Stockholm", "Nyköping" };

            //Gör en vanlg rad för månaderna som ska vara längst upp
            Console.WriteLine("\t\tJun\tJul\tAug");


            
                
               
            //Skriv ut matrisen och lägg till cities 
            for (int i = 0; i < temperature.GetLength(0); i++) //Skapa raderna imatrisen
            {

                //Här kan du lägga till cities. Om du bara vill skriva ut matrisen tar du bort denna rad
                Console.Write(cities[i] + ":\t");



                for (int j = 0; j < temperature.GetLength(1); j++) //Skapa kolumnerna i matrisen
                {
                    Console.Write(temperature[i, j] + "\t");
                }
                Console.WriteLine(); //Hoppa ner en rad aefter att varje kolumn har loopats igenom
            }
        }

    }
}
