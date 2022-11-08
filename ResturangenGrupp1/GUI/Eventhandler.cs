using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.Person;
using ResturangenGrupp1.Restaurant;

namespace ResturangenGrupp1.GUI
{
    internal class Eventhandler
    {
        public static string[] _events = new string[9];
        public static double Tips { get; set; }
        
        public static void AddEventGuest(List<Guest> guests, int competence, ITable table, int companyCash, int foodCost)
        {
            for(int i = 0; i < _events.Length; i++)
            {
                _events[i] = "                                                                                       ";
            }
            
            _events[0] = "Sällskapet " + guests[0].Name;         
            

            for(int i = 0; i < guests.Count; i++)
            {
                if (guests[i] != null)
                {
                    _events[i + 1] = guests[i].PreferedFood[0].Name + " " + guests[i].PreferedFood[0].Price;
                }
            }

            Random rnd = new Random();
            int checkTip = rnd.Next(0, 100);   
            
            if (guests[0].Satisfaction > 2)
            {
                if(competence > 2)
                {
                    _events[5] = guests[0].Name + "'s var nöjda med servicen, maten" + (table.Quality == true ? " samt bordet" : " men inte med bordet.");
                    _events[6] = guests[0].Name + "'s betalar " + foodCost + " kr för maten";

                    if (table.Quality)
                    {                        
                        if(checkTip > 80)
                        {
                            _events[7] = guests[0].Name + " går till disken istället för att dricksa";
                            table.DrawTable();
                            guests[0].GoToTheSink(guests[0]);
                        }
                        else
                        {
                            _events[7] = guests[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.15, 2)) + " kr till resturangen";

                            Tips += foodCost * 0.15;
                        }                        
                    }
                    else
                    {                        
                        if (checkTip > 80)
                        {
                            _events[7] = guests[0].Name + " går till disken istället för att dricksa";
                            table.DrawTable();
                            guests[0].GoToTheSink(guests[0]);
                        }
                        else
                        {
                            _events[7] = guests[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.10, 2)) + " kr till resturangen";

                            Tips += foodCost * 0.10;
                        }
                    }
                }
                else
                {
                    _events[5] = guests[0].Name + "'s var inte nöjda med servicen men nöjda med maten" + (table.Quality == true ? " samt bordet" : " och inte med bordet.");
                    _events[6] = guests[0].Name + "'s betalar " + foodCost + " kr för maten"; // dom dricksar 10% av totalkostnaden

                    if (table.Quality)
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = guests[0].Name + " går till disken istället för att dricksa";
                            table.DrawTable();
                            guests[0].GoToTheSink(guests[0]);
                        }
                        else
                        {
                            _events[7] = guests[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.10, 2)) + " kr till resturangen";

                            Tips += foodCost * 0.10;
                        }
                    }
                    else
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = guests[0].Name + " går till disken istället för att dricksa";
                            table.DrawTable();
                            guests[0].GoToTheSink(guests[0]);
                        }
                        else
                        {
                            _events[7] = guests[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.05, 2)) + " kr till resturangen";

                            Tips += foodCost * 0.05;
                        }
                    }
                }                
            }
            else
            {
                if(competence > 2)
                {
                    _events[5] = guests[0].Name + "'s var nöjda med servicen men inte med maten" + (table.Quality == false ? " och bordet" : " men nöjd med bordet.");
                    _events[6] = guests[0].Name + "'s betalar " + foodCost + " kr för maten";

                    if (table.Quality)
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = guests[0].Name + " går till disken istället för att dricksa";
                            table.DrawTable();
                            guests[0].GoToTheSink(guests[0]);
                        }
                        else
                        {
                            _events[7] = guests[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.10, 2)) + " kr till resturangen";

                            Tips += foodCost * 0.10;
                        }
                    }
                    else
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = guests[0].Name + " går till disken istället för att dricksa";
                            table.DrawTable();
                            guests[0].GoToTheSink(guests[0]);
                        }
                        else
                        {
                            _events[7] = guests[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.05, 2)) + " kr till resturangen";

                            Tips += foodCost * 0.05;
                        }
                    }
                }
                else
                {

                    _events[5] = guests[0].Name + "'s var inte nöjda med servicen, maten" + (table.Quality == false ? " och bordet" : " men nöjd med bordet.");
                    _events[6] = guests[0].Name + "'s betalar " + foodCost + " kr för maten";

                    if (table.Quality)
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = guests[0].Name + " går till disken istället för att dricksa";
                            table.DrawTable();
                            guests[0].GoToTheSink(guests[0]);
                        }
                        else
                        {
                            _events[7] = guests[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.05, 2)) + " kr till resturangen";

                            Tips += foodCost * 0.05;
                        }
                    }
                    else
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = guests[0].Name + " går till disken istället för att dricksa";
                            table.DrawTable();
                            guests[0].GoToTheSink(guests[0]);
                        }
                        else
                        {
                            _events[7] = guests[0].Name + "'s dricksar inget då de var missnöjda med allt";                            
                        }
                    }
                }
            }            
            table.DrawTable();
            Window.Draw("Events", 66, 13, Eventhandler._events);
            Console.SetCursorPosition(66, 25);
            Console.WriteLine("Dagens dricks = " + Math.Round(Tips), 2);

        }
        

    }
}
