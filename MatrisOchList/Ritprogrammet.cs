using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MatrisOchList
{
    internal class Ritprogrammet
    {



        public static void Show()
        {
            //Skapa en matris där du kan lägga in tecken (därav char)
            //Den ska vara 10X10
            char[,] board = new char[10, 10];


            //Fyll matrisen med tomma rutor 
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = ' ';
                    //Console.Write(board[i, j]); Detta hade du haft med om du borsätt rån att fylla också ville SKRIVA UT matrisen i konsolen.
                }
                //Console.WriteLine(); Detta hade du haft med om du bortsätt från att fylla också ville SKRIVA UT matrisen i konsolen. 
                //Just denna rad hade varit för design så att efter varje 10 gånger som loopen körs horsontellt hoppar den ner
            }


            //Anropa metoden move för att låta användaren röra på sig.
            int x = 0; //Du byggde metoden så att du manuellt ska skicka in ett X och Y värde därav deklareras variablerna här
            int y = 0;
            
            Move(x, y, board);




            
        }








        //Skapa en metod för att hantera rörelser ASWD
        public static void Move(int x, int y, char[,] board) //Du måste ta in personernas x eller y axel
        {
           
            //Skapa en while loop så att användaren kan trycka på tangenterna hur många gånger som helst
            while (true)
            {
              
                Console.Clear();

                //Skriv ut instruktioner längst upp i vyn
                Console.WriteLine("AWSD: Flytta | E: Lägg till tecken");
                Console.WriteLine();







                //Skriv ut matrisen och lägg till en markör för att göra det tydligt
                for (int i = 0; i < board.GetLength(0); i++) //Denna rad skriver ut raden (horisontellt)
                {
                    for(int j = 0; j < board.GetLength(1); j++) //Denna rad skriver ut kolumnen (diagonalt)
                    {


                        //Nu när du skrivit ut själva matrisen lägg till en markör så när användaren är på en viss ruta ska följande tecken synas --> []
                        //Detta för att göra det tydligt vart i matrisen användaren befinner sig på
                        if(x == j && y == i)  //x och y är positionerna som användaren kommer genom att trycka AWSD
                                              // i och j är själva matrisens positioner som du precis loopa
                        {
                            if (board[i, j] != ' ')
                            {
                                Console.Write("[" + board[i, j] + "]"); //Om det inte är tomt i matrisen där markören är (om det redan finns ett tecken) ska du omringa tecknet med []
                            }
                            else
                            {
                                Console.Write("[ ]"); //Visa symbolen [] som ska flytta i den tomma matrisen när användaren använder tangenterna AWSD
                            }




                           
                        }
                        else
                        {
                            Console.Write(" " + board[i, j] + " "); //Om den aktuella platsen (i, j) ÄR markörens position, skrivs board[i, j] ut och den markeras inte med något                                                                                                           
                        }
                    }

                    Console.WriteLine(); //Detta finns för att efter varje rad som skrivs ut alltså varje Get.Length(0) ska programmet hoppa ner


                }
            







                //Spara användarens tangenttryckning i variabeln chosenKey
                ConsoleKeyInfo chosenkey = Console.ReadKey(true);  //Om du skriver true så syns inte tangenttryckningen


                //Med hjälp av en if sats förklara vad som händer när man använder tangenterna AWSD och E
                if (chosenkey.Key == ConsoleKey.W && y > 0)
                {
                    y--; //Här flyttas du UPPÅT i matrisen
                         //Börja med upp och ner vilket alltid är på y axeln för att det är kolumner inte rader. 
                         //Om y axelns 0 punkt är längst upp så blir det - för att när vi trycker upp blir rutorna färre 
                }
                else if (chosenkey.Key == ConsoleKey.S && y < board.GetLength(0) - 1)
                {
                    y++; //Här flyttas du NERÅT
                         //Om y axelns 0 punkt är längst upp så blir det + för att när vi trycker ner blir rutorna mer
                }
                else if (chosenkey.Key == ConsoleKey.A && x > 0)
                {
                    x--; //Här flyttas du till VÄNSTER
                         //Om x axelns 0 punkt är lägst till höger på ex 1 raden så blir det - för att det blir färre rutor vi        
                }
                else if (chosenkey.Key == ConsoleKey.D && x < board.GetLength(1) - 1)
                {
                    x++; //Här flyttas du till HÖGER
                         //Om x axelns 0 punkt är längst till höger och du flyttar till höger så blir det fler rutor därav +
                }
                else if(chosenkey.Key == ConsoleKey.E)
                {
                    Console.WriteLine();//design
                    Console.Write("Skriv in ett tecken: ");
                    char inputE = Console.ReadKey(true).KeyChar; //Sparar användarens input
                                                             //KeyChar är en egenskap på ConsoleKeyInfo som returnerar det aktuella tecknet (char) som användaren tryckte på.

                    board[y, x] = inputE; //Spara i och j till y och x axeln
                    Console.WriteLine("Tecken sparat!");
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning tryck på knapparna AWSD eller E");
                    continue; //Detta gör så att du går tillbaka till toppen av while-loopen
                }


                //LOGIKEN:
                //Detta kan verka lite konstigt eftersom att vanligt fall brukar x vara rad och y kolumn:

                //y styr radpositionen(upp / ner). y är alltså rad eftersom y ändras när vi går uppåt eller nedåt i matrisen.
                //x styr kolumnpositionen(vänster / höger). är kolumn eftersom x ändras när vi går vänster eller höger i matrisen.

                //W (upp) och S (ner) påverkar y.
                //A (vänster) och D(höger) påverkar x.

            }
        }







    }
}
