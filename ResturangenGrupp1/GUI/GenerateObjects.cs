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
        public static List<Person.Guest> _guests = new List<Guest>();
        //Metoder för att genera alla object

        public void CreatePeople()
        {
            for (int i = 0; i < 80; i++)
            {
                Guest guest = new Guest();
                _guests.Add(guest);
            }
        }


    }
}
