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
        public static string[] _events = new string[8]; 
        //Metoder med listor där vi visar x - mycket data i GUI:n
       

        public static void AddEventGuest(Waiter waiter, ITable table, int companyCash, int foodCost)
        {
            //använda companycash på något vis igen
            _events[0] = table.TableSize[0].Name + " + " + (table.TableSize.Length - 1);            
            
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
            if(table.TableSize[0].Satisfaction > 3)
            {
                if(waiter.Competence > 3)
                {
                    _events[table.TableSize.Length] = "Sällskapet " + table.TableSize[0].Name + " var nöjda med servicen, maten" + (table.Quality == true ? " samt bordet" : " men inte med bordet.");

                    if (table.Quality)
                    {
                        _events[6] = "Sällskapet " + table.TableSize[0].Name + " betalar" + (foodCost < companyCash ? " " + foodCost + " kr för maten" : " så mycket dom har tillgängligt i sin gemensamma kassa"); // dom dricksar 10% av totalkostnaden
                    }
                    else
                    {
                        _events[6] = "Sällskapet " + table.TableSize[0].Name + " betalar" + (foodCost < companyCash ? " " + foodCost + " kr för maten" : " så mycket dom har tillgängligt i sin gemensamma kassa"); // dom dricksar mindre eller inget
                    }
                }
                else
                {
                    _events[table.TableSize.Length] = "Sällskapet " + table.TableSize[0].Name + " var inte nöjda med servicen men nöjda med maten" + (table.Quality == true ? " samt bordet" : " och inte med bordet.");

                    if (table.Quality)
                    {
                        _events[6] = "Sällskapet " + table.TableSize[0].Name + " betalar" + (foodCost < companyCash ? " " + foodCost + " kr för maten" : " så mycket dom har tillgängligt i sin gemensamma kassa"); // dom dricksar 10% av totalkostnaden
                    }
                    else
                    {
                        _events[6] = "Sällskapet " + table.TableSize[0].Name + " betalar" + (foodCost < companyCash ? " " + foodCost + " kr för maten" : " så mycket dom har tillgängligt i sin gemensamma kassa"); // dom dricksar mindre eller inget
                    }
                }                
            }
            else
            {
                if(waiter.Competence > 3)
                {
                    _events[table.TableSize.Length] = "Sällskapet " + table.TableSize[0].Name + " var nöjda med servicen men inte med maten" + (table.Quality == false ? " och bordet" : " men nöjd med bordet.");
                    if (table.Quality)
                    {
                        _events[6] = "Sällskapet " + table.TableSize[0].Name + " betalar" + (foodCost < companyCash ? " " + foodCost + " kr för maten" : " så mycket dom har tillgängligt i sin gemensamma kassa"); // dom dricksar 10% av totalkostnaden
                    }
                    else
                    {
                        _events[6] = "Sällskapet " + table.TableSize[0].Name + " betalar" + (foodCost < companyCash ? " " + foodCost + " kr för maten" : " så mycket dom har tillgängligt i sin gemensamma kassa"); // dom dricksar mindre eller inget
                    }
                }
                else
                {
                    _events[table.TableSize.Length] = "Sällskapet " + table.TableSize[0].Name + " var inte nöjda med servicen, maten" + (table.Quality == false ? " och bordet" : " men nöjd med bordet.");
                    _events[6] = "Sällskapet " + table.TableSize[0].Name + " betalar" + (foodCost < companyCash ? " " + foodCost + " kr för maten" : " så mycket dom har tillgängligt i sin gemensamma kassa"); // dom dricksar 10% av totalkostnaden
                   
                }
                Random rnd = new Random();
                int checkTip = rnd.Next(0, 100);
                if(checkTip > 80)
                {
                    _events[7] = table.TableSize[0].Name + " går till disken istället för att dricksa";
                    table.TableSize[0].GoToTheSink(table.TableSize[0]);
                }
                else
                {
                    if(waiter.Competence > 3 && table.TableSize[0].Satisfaction > 3 && table.Quality)
                    {
                        _events[7] = "Sällskapet " + table.TableSize[0].Name + " dricksar " + (foodCost * 0.1) + " kr till resturangen";
                    }
                    else if((waiter.Competence > 3 && table.TableSize[0].Satisfaction > 3) || (waiter.Competence > 3 && table.Quality) || (table.TableSize[0].Satisfaction > 3 && table.Quality))
                    {
                        _events[7] = "Sällskapet " + table.TableSize[0].Name + " dricksar " + (foodCost * 0.05) + " kr till resturangen";
                    }
                    else if(waiter.Competence > 3 || table.TableSize[0].Satisfaction > 3 || table.Quality)
                    {
                        _events[7] = "Sällskapet " + table.TableSize[0].Name + " dricksar " + (foodCost * 0.01) + " kr till resturangen";
                    }
                    else
                    {
                        _events[7] = "Sällskapet " + table.TableSize[0].Name + " dricksar inget då de var missnöjda med allt";
                    }
                }

            } 
        }
        public void ShowGuestList()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(GenerateObjects._guests[i].Name);
                //Console.Write(" + " GenerateObjects._guests[i].);
            }
        }
    }
}
