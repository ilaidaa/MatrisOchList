using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MatrisOchList
{
    internal class HotellBokningen
    {
        public static void Show()
        {
            //Skapa matris för själva hotellet som är tom och bara deklarerar 3 rader(våningar) och 4 kolumner (rum)
            string[,] rooms = new string[3, 4];

            //Fyll rummet med tomma strängar
            for(int i = 0; i < rooms.GetLength(0); i++)
            {
                for(int j = 0; j < rooms.GetLength(1); j++)
                {
                    rooms[i, j] = ""; //Du skriver inte Console.WriteLine för att du fyller bara rummen inte skriver ut de 
                }
            }








            //Gör en bool continueBooking-variabel som styr om while-loopen ska fortsätta eller inte. 
            //Såfort du skriver continueBooking == false så kommer du gå ut ur while-loopen
            //Vi har en bool för det är många olika ifsatser som kommer finnas md i programmet
            bool continueBooking = true;

            //För att programmet ska köra förevigt
            while (continueBooking)
            {
                Console.Clear();


                HotellStatus(rooms);
                


                //Frågor som ställs till användaren
                Console.Write("Välkommen till hotellet! Hur var ditt namn?: ");
                string name = Console.ReadLine();

                Console.WriteLine(); //Design purposeeeeessssss
               
                Console.Write("Välkommen " + name + "! Vänligen skriv in våningen du vill boka?: ");
                int floor = int.Parse(Console.ReadLine());

                Console.Write("Vänligen skriv in rummet du vill boka: ");
                int room = int.Parse(Console.ReadLine());







                //Hantera det som händer när information från användaren är inmatad
                if (rooms[floor, room] == "") //Här lägger du in villkoret. Om de tomma raden och kolumnen (rooms arrayen) är tom, så ska det i blocket gälla
                {
                    rooms[floor, room] = name; //Då ska den rutan framöver innehålla name (vilket är kunden)
                    Console.WriteLine("Rum " + (room) + " på våning " + (floor) + " är bookad av " + name); //du lägger + 1 för att en array börjar alltid från 0
                }
                else if (rooms[floor, room] != "") 
                {
                    Console.WriteLine("Rummet är redan bokat tyvärr.");
                }
                else
                {
                    Console.WriteLine("Fel inmatning. Tryck för att avsluta.");
                }



                
                Console.WriteLine(); //Design. Mellanrum mellan rumsbokning och ny bokning.




                //Glöm inte fråga användaren om hen vill göra n ny bokning
                Console.WriteLine("Vill du göra en ny bokning? tryck j eller n");
                string answer = Console.ReadLine().ToLower(); //ToLower() används för att göra all inmatad data från användaren till mindre bokstäver

                if(answer == "j")
                {
                    Console.Clear(); //Rensa skärmen och allt som skrivits hitills
                    continue; //När du skriver continue i en while-loop, hoppar programmet direkt tillbaka till början av loopen och kör om alla instruktioner inuti loopen från toppen.
                              //d.v.s till rumsbokningen
                }
                else if(answer == "n")
                {
                    Console.WriteLine("Tack för att du använde bokningsprogrammet! Ha en trevlig dag . . .");
                    Thread.Sleep(1000); //Tar några sekunder innan programmet avslutas
                    continueBooking = false; //Avslutar while-loopen för att den fick bara köras om continueBooking är true
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Program avslutas . . . ");
                    Thread.Sleep(1000);
                    continueBooking = false;
                }
            }
        }










        //En ny metod för att visa översikt av alla rum i hotellet
        public static void HotellStatus(string[,] rooms)
        {
            Console.WriteLine("Hotellets lediga rum:");


            // Skriv ut rumsnummer horisontellt överst
            Console.Write("\t\t"); // Inledande tom yta för namnen där det ska stå våning 1, våning 2 osv. Gör 2 eller mer om d behövs
                                   //  Skriver två tabbar för att skapa utrymme längst till vänster, vilket justerar rumsnumren så att de hamnar rätt under rubriken.

            for (int i = 0; i < rooms.GetLength(1); i++) //1 står för columner (uppifrån ner). Loopa igenom alla columner
            {
                Console.Write("Rum: " + (i) + "\t\t"); //skriv ex rum 1 på första kolumnen uppifrån ner hoppa över 2 ggr (\t) och skriv nästa rum
            }
            Console.WriteLine();




            //
            for (int i = 0; i < rooms.GetLength(0); i++)
            {
                //Skriv ut rumsnumret först
                Console.Write("Våning " + (i) + "\t");

                for(int j = 0; j < rooms.GetLength(1); j++)
                {
                    string status = rooms[i, j] == "" ? "Ledigt \t\t" : "Bokat av " + rooms[i, j] + "\t\t"; //Sparar status för att visa vilka rum som är lediga och vilka som är bokade

                    Console.Write(status);  
                }

                Console.WriteLine();
            }

            Console.WriteLine();
                                                                  
        }

    }
}
