using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.Person;
using ResturangenGrupp1.Restaurant;
using ResturangenGrupp1;

namespace ResturangenGrupp1.GUI
{
    internal class GUI
    {
        public static void StartResturant()
        {

            for (int i = 0; i < Eventhandler._events.Length; i++)
            {
                Eventhandler._events[i] = "                   ";
            }
            GenerateObjects.CreateObjects(); // Skapandet av alla object
            Company.CreateCompany(); // Skapandet av companies

            while (true)
            {
                Window.DrawRestaurant(); // Ritar ut hela brädet
                
                for (int i = 0; i < GenerateObjects._waiters.Count; i++)
                {
                    if (!GenerateObjects._waiters[i].Busy)
                    {
                        GenerateObjects._waiters[i].Activity(); // Leta upp aktivitet till Slöa servitörer
                        if (!GenerateObjects._waiters[i].Busy)
                        {
                            GenerateObjects._waiters[i].GoToStandBy(); // Gå till standbyläge om inget finns att göra
                        }    
                    }                    
                    else if (GenerateObjects._waiters[i].Busy && GenerateObjects._waiters[i].AtDoor)
                    {
                        GenerateObjects._waiters[i].MatchTableWithGuests(); // Matcha company storlek med bord

                        if (GenerateObjects._waiters[i].Guests.Count > 0)
                        {
                        GenerateObjects._waiters[i].AtDoor = false; // Dörren är ledig
                        GenerateObjects._waiters[i].GoToTable();    // Gå till rätt bord
                        GenerateObjects._waiters[i].PutCompanyAtTable();        // Visa gästerna bordet och ta in matorder 
                        GenerateObjects._waiters[i].OrderTaken = true;        // Sätta bool ordertaken till true
                        }
                        else
                        {
                            GenerateObjects._waiters[i].Order.Clear();
                            GenerateObjects._waiters[i].Guests.Clear();
                            GenerateObjects._waiters[i].Busy = false;
                            GenerateObjects._waiters[i].AtDoor = false;
                        }
                    }
                    else if (GenerateObjects._waiters[i].Busy && GenerateObjects._waiters[i].AtKitchen && !GenerateObjects._waiters[i].OrderTaken && Kitchen.Kitchen.OrdersDone.Count > 0)
                    {
                        GenerateObjects._waiters[i].TakeFoodFromKitchen();        // Ta in order  // Gå till rätt bordsnummer
                        GenerateObjects._waiters[i].PutFoodOnTable(); // Lämna maten
                        GenerateObjects._waiters[i].Busy = false;
                        GenerateObjects._waiters[i].AtKitchen = false;
                    }
                    else if (GenerateObjects._waiters[i].Busy && GenerateObjects._waiters[i].OrderTaken && GenerateObjects._waiters[i].AtKitchen)
                    {
                        GenerateObjects._waiters[i].LeaveOrderToKitchen(); // Lämna order till köket
                        GenerateObjects._waiters[i].Busy = false;
                        GenerateObjects._waiters[i].OrderTaken = false;
                        GenerateObjects._waiters[i].AtDoor = false;
                        GenerateObjects._waiters[i].AtKitchen = false;
                        GenerateObjects._waiters[i].Order.Clear();  // Radera allt innehåll i ordern
                        GenerateObjects._waiters[i].GoToStandBy();  // gå till standby

                    }
                    else if (GenerateObjects._waiters[i].Busy && GenerateObjects._waiters[i].OrderTaken)
                    {
                        GenerateObjects._waiters[i].GoToTheKitchen(); // gå till köket med beställning
                        GenerateObjects._waiters[i].AtKitchen = true;
                    }
                    else if (GenerateObjects._waiters[i].Busy && GenerateObjects._waiters[i].HelpingTable)
                    {
                        GenerateObjects._waiters[i].GoToTable();
                        GenerateObjects._waiters[i].TakeCashFromCompany();
                        GenerateObjects._waiters[i].CleaningTable = true;
                        GenerateObjects._waiters[i].HelpingTable = false;
                        //Metod för att rita ut bordet utan namnen
                        int TableNumber = (int)GenerateObjects._waiters[i].Order["TableNumber"];
                        for (int j = 0; j < GenerateObjects._tables.Count; j++)
                        {
                            if (GenerateObjects._tables[i].TableNumber == TableNumber)
                            {
                                GenerateObjects._tables[i].DrawTable();
                            }

                        }                        
                        GenerateObjects._waiters[i].GoToTable(); // rita ut waiter igen för att inte hamna bakom
                    }

                    else if (GenerateObjects._waiters[i].Busy && GenerateObjects._waiters[i].CleaningTable)
                    {
                        GenerateObjects._waiters[i].TimeActivity--;
                        GenerateObjects._waiters[i].GoToTable();
                        if (GenerateObjects._waiters[i].TimeActivity == 0)
                        {
                            GenerateObjects._waiters[i].ResetTable();  // Resetta bordet, tömma allt                  
                            GenerateObjects._waiters[i].Order.Clear();  // Tömma order
                            GenerateObjects._waiters[i].Guests.Clear();   // Tömma på gäster
                            GenerateObjects._waiters[i].TimeActivity = 3;
                            GenerateObjects._waiters[i].Busy = false;
                            GenerateObjects._waiters[i].CleaningTable = false;
                        }
                    }
                }
                for(int i = 0; i < GenerateObjects._chefs.Count; i++)
                {
                    if (!GenerateObjects._chefs[i].Busy)
                    {
                        GenerateObjects._chefs[i].Activity();  // Kolla om det finns någon order att laga
                    }
                    if (GenerateObjects._chefs[i].Busy)
                    {
                        GenerateObjects._chefs[i].TimeActivity--;
                        if (GenerateObjects._chefs[i].TimeActivity == 0)
                        {
                            GenerateObjects._chefs[i].OrderDone();  // Lägg den färdiga maten för waiters att hämta
                            GenerateObjects._chefs[i].TimeActivity = 10;
                        }
                    }
                }
                // Kolla bord som fått mat och se till att gästerna äter
                for(int i = 0; i < GenerateObjects._tables.Count; i++)
                {
                    if (GenerateObjects._tables[i].DinnerServerd)
                    {
                        for(int j = 0; j < GenerateObjects._tables[i].TableSize.Length; j++)
                        {
                            if (GenerateObjects._tables[i].TableSize[j] != null)
                            {
                                GenerateObjects._tables[i].TableSize[j].TimeActivity--;
                                if (GenerateObjects._tables[i].TableSize[j].TimeActivity == 0)
                                {
                                    GenerateObjects._tables[i].FinnishedWithFood = true;
                                }
                            }                           
                        }
                    }
                }
                Thread.Sleep(500);

            }
        }
    }
    public class Window
    {
        public static void Draw(string header, int fromLeft, int fromTop, string[] graphics)
        {
            int width = 0;
            for (int i = 0; i < graphics.Length; i++)
            {
                if (graphics[i].Length > width)
                {
                    width = graphics[i].Length;
                }
            }
            if (width < header.Length + 4)
            { width = header.Length + 4; };

            Console.SetCursorPosition(fromLeft, fromTop);
            if (header != "")
            {
                Console.Write('┌' + " ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(header);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" " + new String('─', width - header.Length) + '┐');
            }
            else
            {
                Console.Write('┌' + new String('─', width + 2) + '┐');
            }
            Console.WriteLine();
            int maxRows = 0;
            for (int j = 0; j < graphics.Length; j++)
            {
                Console.SetCursorPosition(fromLeft, fromTop + j + 1);
                Console.WriteLine('│' + " " + graphics[j] + new String(' ', width - graphics[j].Length + 1) + '│');
                maxRows = j;
            }
            Console.SetCursorPosition(fromLeft, fromTop + maxRows + 2);
            Console.Write('└' + new String('─', width + 2) + '┘');
        }

        public static void DrawRestaurant()
        {
            Console.CursorVisible = false;

            string[] table = new string[4];
            table[0] = "          ";
            table[1] = "          ";
            table[2] = "          ";
            table[3] = "          ";

            string[] resturangList = new string[43];
            for (int i = 0; i < resturangList.Length; i++)
            {
                resturangList[i] = "                                                            ";

            }            
            string[] waitingGuests = new string[10];
            for (int i = 0; i < Company._companies.Count; i++)
            {
                if(i > 9)
                {
                    break;
                }
                
                else if(Company._companies.Count < 10)
                {
                    int safeFail = Company._companies.Count;
                    for(int j = safeFail; j < waitingGuests.Length; j++)
                    {
                        waitingGuests[j] = " "; 
                    }
                    for(int k = 0; k < Company._companies.Count; k++)
                    {
                        waitingGuests[k] = Company._companies[k][0].Name + " + " + (Company._companies[k].Count - 1);
                    }
                }                
                else
                {
                    waitingGuests[i] = Company._companies[i][0].Name + " + " + (Company._companies[i].Count - 1);
                    
                }                     
            }
            if (Company._companies.Count == 0)
            {
                for (int l = 0; l < waitingGuests.Length; l++)
                {
                    waitingGuests[l] = " ";
                }
            }

            string[] events = new string[31];
            for (int i = 0; i < events.Length; i++)
            {
                events[i] = " ";
            }

            string[] kitchen = new string[2];
            kitchen[0] = "          ";
            kitchen[1] = "          ";

            string[] door = new string[2];
            door[0] = "          ";
            door[1] = "          ";

            string[] sink = new string[2];
            sink[0] = "          ";
            sink[1] = "          ";


            Helper.Eraser(80, 25, 46);

            Window.Draw("Resturang", 1, 1, resturangList);
            Window.Draw("Kitchen", 25, 2, kitchen);
            Window.Draw("Door", 47, 2, door);
            Window.Draw("Sink", 5, 2, sink);

            Window.Draw("Table 1 ", 5, 10, GenerateObjects._tables[0].TableNames);
            Window.Draw("Table 2 ", 5, 17, GenerateObjects._tables[1].TableNames);
            Window.Draw("Table 3 ", 5, 24, GenerateObjects._tables[2].TableNames);
            Window.Draw("Table 4 ", 5, 31, GenerateObjects._tables[3].TableNames);
            Window.Draw("Table 5 ", 5, 38, GenerateObjects._tables[4].TableNames);

            Window.Draw("Table 6 ", 45, 10, GenerateObjects._tables[5].TableNames);
            Window.Draw("Table 7 ", 45, 17, GenerateObjects._tables[6].TableNames);
            Window.Draw("Table 8 ", 45, 24, GenerateObjects._tables[7].TableNames);
            Window.Draw("Table 9 ", 45, 31, GenerateObjects._tables[8].TableNames);
            Window.Draw("Table 10", 45, 38, GenerateObjects._tables[9].TableNames);

                        
            Helper.DisplayThings(waitingGuests);            
            Helper.DisplayThings(Eventhandler._events);
            Helper.DisplayThings("Dagens dricks =");

            Eventhandler.ChefsEvent();
            Eventhandler.WaitersEvent();

            Console.SetCursorPosition(66, 26);
            Console.WriteLine("Antal rundor: " + Helper.Rounds);
            Helper.Rounds++;

        }

    }
}
