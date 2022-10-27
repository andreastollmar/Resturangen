using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturangenGrupp1.Person
{
    internal class Allergies
    {
        public static bool IsAllergic()
        {
            bool allergic = false;
            Random rnd = new Random();
            int allergicCheck = rnd.Next(0, 100);
            if (allergicCheck >= 80)
            {
                allergic = true;
            }
            return allergic;
        }

    }
}
