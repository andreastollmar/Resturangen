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
        public static List<Meet> _foods = new List<Meet>();
        //Metoder för att genera alla object

        public static void CreatePeople()
        {
            for (int i = 0; i < 5; i++)
            {
                Guest guest = new Guest();
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
        public static void CreateFood()
        {
            for (int i = 0; i < 20; i++)
            {
                Meet.Kebab kebab = new Meet.Kebab();
                _foods.Add(kebab);
            }
            for (int i = 0; i < 20; i++)
            {
                Meet.Steak steak = new Meet.Steak();
                _foods.Add(steak);
            }
            for (int i = 0; i < 20; i++)
            {
                Meet.Beef beef = new Meet.Beef();
                _foods.Add(beef);
            }

        }

    }
}
