using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        //constants för att kontrollera nivåerna från en veriabel
        public const int SATISFACTION = 2;
        public const int DISH_LEVEL = 80;
        
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
            //Lång metod för vad som ska skrivas ut beroende på olika nöjdheter
            if (guests[0].Satisfaction > SATISFACTION)
            {
                if(competence > SATISFACTION)
                {
                    _events[5] = guests[0].Name + "'s var nöjda med servicen, maten" + (table.Quality == true ? " samt bordet" : " men inte med bordet.");
                    _events[6] = guests[0].Name + "'s betalar " + foodCost + " kr för maten";

                    if (table.Quality)
                    {                        
                        if(checkTip > DISH_LEVEL)
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
                        if (checkTip > DISH_LEVEL)
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
                        if (checkTip > DISH_LEVEL)
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
                        if (checkTip > DISH_LEVEL)
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
                if(competence > SATISFACTION)
                {
                    _events[5] = guests[0].Name + "'s var nöjda med servicen men inte med maten" + (table.Quality == false ? " och bordet" : " men nöjd med bordet.");
                    _events[6] = guests[0].Name + "'s betalar " + foodCost + " kr för maten";

                    if (table.Quality)
                    {
                        if (checkTip > DISH_LEVEL)
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
                        if (checkTip > DISH_LEVEL)
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
                        if (checkTip > DISH_LEVEL)
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
                        if (checkTip > DISH_LEVEL)
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
            Helper.DisplayThings(_events);


        }
        
        public static void WaitersEvent()
        {
            string[] waiterActivity = new string[GenerateObjects._waiters.Count];
            for (int i = 0; i < GenerateObjects._waiters.Count; i++)
            {
                if (GenerateObjects._waiters[i].CleaningTable)
                {
                    waiterActivity[i] = GenerateObjects._waiters[i].Name + " städar bordet. [" + GenerateObjects._waiters[i].TimeActivity + "]";
                }
                else if (GenerateObjects._waiters[i].Busy)
                {
                    waiterActivity[i] = GenerateObjects._waiters[i].Name + " jobbar hårt.";
                }
                else
                {
                    waiterActivity[i] = GenerateObjects._waiters[i].Name + " latar sig.";
                }

            }
            Window.Draw("Waiters", 66, 30, waiterActivity);
        }

        public static void ChefsEvent()
        {
            string[] chefsActivity = new string[GenerateObjects._chefs.Count];
            for (int i = 0; i < GenerateObjects._chefs.Count; i++)
            {
                string first = GenerateObjects._chefs[i].Competence > 3 ? "Stjärnkocken " + GenerateObjects._chefs[i].Name : "Kocken " + GenerateObjects._chefs[i].Name;
                string second = GenerateObjects._chefs[i].Busy ? " lagar mat. [" + GenerateObjects._chefs[i].TimeActivity + "]" : " latar sig.";
                chefsActivity[i] = first + second;
            }
     
            Window.Draw("Chefs", 66, 39, chefsActivity);
        }

    }
}
