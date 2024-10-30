using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MatrisOchList
{
    internal class RäknaDiagonalen
    {
        public static void Show()
        {
            //Skapa matris för spelbrickan
            int[,] gameBoard =
            {
                {20, 50, 11, 2, 49},
                {92, 63, 12, 64, 37},
                {75, 23, 64, 12, 99},
                {21, 25, 71, 69, 39},
                {19, 39, 58, 28, 83}
            };


            //Skriv ut matrisen
            for(int i = 0; i < gameBoard.GetLength(0); i++) //Loopa igenom raden
            {
                for(int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Console.Write(gameBoard[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine(); //MEllanslag mellan matrisen och summan som ska visas.



            //Räkna ut diagonal
            int diagonalSum = 0;

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                diagonalSum += gameBoard[i, i]; // Lägg till värdena från huvuddiagonalen
            }

            // Skriv ut summan av diagonalen
            Console.WriteLine("Summan av diagonalen: " + diagonalSum);




            //Logik du beöver bara skriva gameBoard[i, i] för att ge programmet rätt index på siffrorna i diagonalen. Detta pga hur index hamnar i en vanlig kvadrat. Se nedan:
            //22 på position (0,0)
            //63 på position(1,1)
            //64 på position(2,2)
            //69 på position(3,3)
            //83 på position(4,4)
        }

    }


}
