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
        public static List<Guest> _guests = new List<Guest>();
        public static List<Chef> _chefs = new List<Chef>();
        public static List<Waiter> _waiters = new List<Waiter>();        
        //Metoder för att genera alla object

        public static void CreatePeople()
        {
            Food food = new Food();
            for (int i = 0; i < 10; i++)
            {
                Guest guest = new Guest();
                food.AddFoodToGuest(guest);
                _guests.Add(guest);
            }
        }

        public static void CreateWaiters()
        {
            for (int i = 0; i < 3; i++)
            {
                Waiter waiter = new Waiter();
                _waiters.Add(waiter);
            }
        }
        public static void CreateChefs()
        {
            for (int i = 0; i < 5; i++)
            {
                Chef chef = new Chef();
                _chefs.Add(new Chef());
            }            
        }
        

    }
}
