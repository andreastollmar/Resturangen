using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Person;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.GUI;

namespace ResturangenGrupp1.Restaurant
{
    internal class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Constins { get; set; }

        public Food()
        {

        }
    }

    class Fich : Food
    {
        internal class Tuna : Fich
        {
            public Tuna()
            {
                Name = "Tuna";
                Price = 110;            
            }
        }

        internal class Scallop : Fich
        {    
            public Scallop()
            {
                Name = "Scallop";
                Price = 99;
               
            }
        }

        internal class Moules : Fich
        {       
             public Moules()
             {
                Name = "Moules";
                Price = 120;
             }
        }

    }

    class Meet : Food
    { 
        internal class Kebab : Meet
        {    
          public Kebab()
            {
                Name = "Kebab";
                Price = 110;
            }
        }

        internal class Steak : Meet
        {        
            public Steak()
            {
                Name = "Steak";
                Price = 160;
                
            }
        }

        internal class Beef : Meet
        {
            public Beef()
            {
                Name = "Beef";
                Price = 180;
            }
        }
    }

    class Vegetarian : Food
    {
        internal class Risotto : Vegetarian
        {  
            public Risotto()
            {
                Name = "Risotto";
                Price = 160;
            }
        }

        internal class Falafel : Vegetarian
        { 
            public Falafel()
            {
                Name = "Falafel";
                Price = 99;
            }
        }

        internal class Haloumi : Vegetarian
        {
            public Haloumi()
            {
                Name = "Haloumi";
                Price = 120;
            }
        }
    }
}
