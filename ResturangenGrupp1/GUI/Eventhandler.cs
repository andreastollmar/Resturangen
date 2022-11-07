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
        
        public static void AddEventGuest(int competence, ITable table, int companyCash, int foodCost)
        {
            for(int i = 0; i < _events.Length; i++)
            {
                _events[i] = "                                              ";
            }
            
            _events[0] = "Sällskapet " + table.TableSize[0].Name;            
            

            for(int i = 0; i < table.TableSize.Length; i++)
            {
                if (table.TableSize[i] == null)
                {
                    _events[i + 1] = " ";
                }
                else
                {
                    _events[i + 1] = table.TableSize[i].PreferedFood[0].Name + " " + table.TableSize[i].PreferedFood[0].Price; 
                }
            }
            Random rnd = new Random();
            int checkTip = rnd.Next(0, 100);            
            if (table.TableSize[0].Satisfaction > 2)
            {
                if(competence > 2)
                {
                    _events[table.TableSize.Length] = table.TableSize[0].Name + "'s var nöjda med servicen, maten" + (table.Quality == true ? " samt bordet" : " men inte med bordet.");
                    _events[6] = table.TableSize[0].Name + "'s betalar " + foodCost + " kr för maten";
                    if (table.Quality)
                    {                        
                        if(checkTip > 80)
                        {
                            _events[7] = table.TableSize[0].Name + " går till disken istället för att dricksa";
                            table.TableSize[0].GoToTheSink(table.TableSize[0]);
                        }
                        else
                        {
                            _events[7] = table.TableSize[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.15, 2)) + " kr till resturangen";
                            Tips += foodCost * 0.15;
                        }                        
                    }
                    else
                    {                        
                        if (checkTip > 80)
                        {
                            _events[7] = table.TableSize[0].Name + " går till disken istället för att dricksa";
                            table.TableSize[0].GoToTheSink(table.TableSize[0]);
                        }
                        else
                        {
                            _events[7] = table.TableSize[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.10, 2)) + " kr till resturangen";
                            Tips += foodCost * 0.10;
                        }
                    }
                }
                else
                {
                    _events[table.TableSize.Length] = table.TableSize[0].Name + "'s var inte nöjda med servicen men nöjda med maten" + (table.Quality == true ? " samt bordet" : " och inte med bordet.");
                    _events[6] = table.TableSize[0].Name + "'s betalar " + foodCost + " kr för maten"; // dom dricksar 10% av totalkostnaden
                    if (table.Quality)
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = table.TableSize[0].Name + " går till disken istället för att dricksa";
                            table.TableSize[0].GoToTheSink(table.TableSize[0]);
                        }
                        else
                        {
                            _events[7] = table.TableSize[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.10, 2)) + " kr till resturangen";
                            Tips += foodCost * 0.10;
                        }
                    }
                    else
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = table.TableSize[0].Name + " går till disken istället för att dricksa";
                            table.TableSize[0].GoToTheSink(table.TableSize[0]);
                        }
                        else
                        {
                            _events[7] = table.TableSize[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.05, 2)) + " kr till resturangen";
                            Tips += foodCost * 0.05;
                        }
                    }

                }                
            }
            else
            {
                if(competence > 2)
                {
                    _events[table.TableSize.Length] = table.TableSize[0].Name + "'s var nöjda med servicen men inte med maten" + (table.Quality == false ? " och bordet" : " men nöjd med bordet.");
                    _events[6] = table.TableSize[0].Name + "'s betalar" + foodCost + " kr för maten";
                    if (table.Quality)
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = table.TableSize[0].Name + " går till disken istället för att dricksa";
                            table.TableSize[0].GoToTheSink(table.TableSize[0]);
                        }
                        else
                        {
                            _events[7] = table.TableSize[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.10, 2)) + " kr till resturangen";
                            Tips += foodCost * 0.10;
                        }
                    }
                    else
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = table.TableSize[0].Name + " går till disken istället för att dricksa";
                            table.TableSize[0].GoToTheSink(table.TableSize[0]);
                        }
                        else
                        {
                            _events[7] = table.TableSize[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.05, 2)) + " kr till resturangen";
                            Tips += foodCost * 0.05;
                        }
                    }

                }
                else
                {
                    _events[table.TableSize.Length] = table.TableSize[0].Name + "'s var inte nöjda med servicen, maten" + (table.Quality == false ? " och bordet" : " men nöjd med bordet.");
                    _events[6] = table.TableSize[0].Name + "'s betalar" + foodCost + " kr för maten";
                    if (table.Quality)
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = table.TableSize[0].Name + " går till disken istället för att dricksa";
                            table.TableSize[0].GoToTheSink(table.TableSize[0]);
                        }
                        else
                        {
                            _events[7] = table.TableSize[0].Name + "'s dricksar " + (Math.Round(foodCost * 0.05, 2)) + " kr till resturangen";
                            Tips += foodCost * 0.05;
                        }
                    }
                    else
                    {
                        if (checkTip > 80)
                        {
                            _events[7] = table.TableSize[0].Name + " går till disken istället för att dricksa";
                            table.TableSize[0].GoToTheSink(table.TableSize[0]);
                        }
                        else
                        {
                            _events[7] = table.TableSize[0].Name + "'s dricksar inget då de var missnöjda med allt";                            
                        }
                    }
                }
            } 
        }
        
    }
}
