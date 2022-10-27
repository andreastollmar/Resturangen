using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturangenGrupp1.Restaurant
{
    internal class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }


    }

    class Fich : Food
    {
        //public string nameFood1 = "Tuna";
        //public string nameFood2 = "Scallop";
        //public string nameFood3 = "Moules frites";

        internal class Tuna : Fich
        {
             bool consitns;
        }

        internal class Scallop : Fich
        {
             bool consitns;
        }

        internal class Moules : Fich
        {
             bool consitns;
        }

    }

    class Meet : Food
    {

        //public string nameFood1 = "Kebab";
        //public string nameFood2 = "Sirloin steak";
        //public string nameFood3 = "Beef plank";
        internal class Kebab : Meet
        {
             bool consitns;
        }

        internal class Steak : Meet
        {
             bool consitns;
        }

        internal class Beef : Meet
        {
             bool consitns;
        }


    }

    class Vegetarian : Food
    {
  
        //public string nameFood1 = "Risotto";
        //public string nameFood2 = "Falafel";
        //public string nameFood3 = "Haloumi ";


        internal class Risotto : Vegetarian
        {
             bool consitns;
        }

        internal class Falafel : Vegetarian
        {
             bool consitns;
        }

        internal class Haloumi : Vegetarian
        {
             bool consitns;
        }
    }
}
