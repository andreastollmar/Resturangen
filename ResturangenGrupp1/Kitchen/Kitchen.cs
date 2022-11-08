using ResturangenGrupp1.Person;
using ResturangenGrupp1.Restaurant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ResturangenGrupp1.Restaurant.Fish;
using static ResturangenGrupp1.Restaurant.Meat;
using static ResturangenGrupp1.Restaurant.Vegetarian;

namespace ResturangenGrupp1.Kitchen
{
    internal class Kitchen
    {
        public static Queue<Hashtable> OrdersToCook = new Queue<Hashtable>();
        public static Queue<Hashtable> OrdersDone = new Queue<Hashtable>();
        public static Queue TableNumbersDone = new Queue();
    }
}
