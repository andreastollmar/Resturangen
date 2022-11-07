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
    internal class GenerateObjects
    {
        public static List<TableForFour> _tablesForFour = new List<TableForFour>();
        public static List<TableForTwo> _tablesForTwo = new List<TableForTwo>();
        public static List<ITable> _tables = new List<ITable>();
        public static List<Guest> _guests = new List<Guest>();
        public static List<Chef> _chefs = new List<Chef>();
        public static List<Waiter> _waiters = new List<Waiter>();        
        //Metoder för att genera alla object

        private static void CreatePeople() // Metod för att hämta in gästerna
        {
            Food food = new Food();
            for (int i = 0; i < 80; i++)
            {
                Guest guest = new Guest();
                food.AddFoodToGuest(guest);
                _guests.Add(guest);
            }
        }

        private static void CreateWaiters()  // Metod för att hämta in servitörer
        {
            int fromLeft = 5;
            for (int i = 0; i < 3; i++)
            {
                Waiter waiter = new Waiter();
                waiter.SetStandby = fromLeft;
                _waiters.Add(waiter);
                fromLeft += 20;
            }
        }
        private static void CreateChefs() // Metod för att hämta in kokerna
        {
            for (int i = 0; i < 5; i++)
            {
                Chef chef = new Chef();
                _chefs.Add(new Chef());
            }            
        }
        private static void CreateTables() // Metod för att hämta in alla bord 
        {
            for (int i = 1; i < 6; i++)
            {
                TableForFour table = new TableForFour();
                table.TableNumber = i;
                _tables.Add(table);
            }
            for (int i = 6; i < 11; i++)
            {
                TableForTwo table = new TableForTwo();
                table.TableNumber = i;
                _tables.Add(table);
            }
        }
        public static void CreateObjects()
        {
            CreateChefs();
            CreatePeople();
            CreateTables();
            CreateWaiters();
        }
        

    }
}
