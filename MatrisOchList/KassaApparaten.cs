using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MatrisOchList
{
    internal class KassaApparaten
    {
        //Skapa en metod som ska visa Kassaapparaten
        public static void Show()
        {
            //Skapa en lista
            List<double> prices = new List<double>();



            //Ge användaren instruktioner på hur hen ska lägga till eller tabort från listan
            Console.WriteLine("1. LÄGG TILL |   Mata in summan du vill lägga till på listan");
            Console.WriteLine("2. TA BORT   |   Mata in summan du vill ta bort från listan. Glöm inte lägga - tecken innan");
            Console.WriteLine();

            //Använd en while loop så att användaren kan lägga till och tabort hur många produkter som helst utan att programmet avslutas efter första ggn
            while (true)
            {

                if (double.TryParse(Console.ReadLine(), out double number))
                {

                    if(number >= 0) //Om talet är större än 0 kan du lägga till den på listan
                    {
                        prices.Add(number);
                    }
                    else if(prices.Contains(-number)) //Om listan prices Inehåller(contains) -number tabort -number
                    {
                        prices.Remove(-number);
                    }
                    else
                    {
                        Console.WriteLine("Priset du vill tabort från listan finns inte med."); //Detta kommer visas om personen vill tabort 80 kr och klickar -80 men den summan inte finns på listan
                        Console.ReadKey();
                    }

                    Console.Clear(); //Rensa skärmen efter att användaren skrivit in det som ska läggas till och tasbort



                    //Eftersom att du rensar skärmen uppe skriv in denna kod igen
                    Console.WriteLine("1. LÄGG TILL |   Mata in summan du vill lägga till på listan");
                    Console.WriteLine("2. TA BORT   |   Mata in summan du vill ta bort från listan. Glöm inte lägga - tecken innan");
                    Console.WriteLine();

                    //Skriv nu ut lista 
                    for (int i = 0; i < prices.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + prices[i]);
                    }   
                    
                }

                else
                {
                    Console.WriteLine(); //För design
                    Console.Write("Fel inmatning. Skriv in ett tal. "); //Om du skriver in en string eller en char kommer detta komma upp
                    continue;  // Gå tbx i loopen längst upp
                }
               

            }
          
        }





        

    }
}
