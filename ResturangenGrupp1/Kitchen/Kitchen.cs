using ResturangenGrupp1.Person;
using ResturangenGrupp1.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ResturangenGrupp1.Restaurant.Fich;
using static ResturangenGrupp1.Restaurant.Meet;
using static ResturangenGrupp1.Restaurant.Vegetarian;

namespace ResturangenGrupp1.Kitchen
{
    internal class Kitchen
    {
        public void CookFood(List<Food> meny, int Time)
        {
            for (int i = 0; i <= Time; i++)
            {

                foreach (Food food in meny)
                {
                    if(food is Meet)
                    {
                        if (food is Kebab)
                        {
                            Console.WriteLine($"Koken lagar {((Kebab)food).Name} som kostar {((Kebab)food).Price} i {i} secounder");
                        }
                        if (food is Steak)
                        {
                            Console.WriteLine($"Koken lagar {((Steak)food).Name} som kostar {((Steak)food).Price} i {i}  secounder");
                        }
                        else if (food is Beef)
                        {
                            Console.WriteLine($"Koken lagar {((Beef)food).Name} som kostar {((Beef)food).Price} i {i} secounder");
                        }
                    }

                
                    if (food is Fich)
                    {
                        if(food is Scallop)
                        {
                            Console.WriteLine($"Koken lagar {((Scallop)food).Name} som kostar {((Scallop)food).Price} i {i} secounder");
                        }
                        if(food is Tuna)
                        {
                            Console.WriteLine($"Koken lagar {((Tuna)food).Name} som kostar {((Tuna)food).Price} i {i} secounder");
                        }
                        else if(food is Moules)
                        {
                            Console.WriteLine($"Koken lagar {((Moules)food).Name} som kostar {((Moules)food).Price} i {i} secounder");
                        }
                    }

                    if (food is Vegetarian)
                    {
                        if(food is Risotto)
                        {
                            Console.WriteLine($"Koken lagar {((Risotto)food).Name} som kostar {((Risotto)food).Price} i {i} secounder");
                        }
                        if(food is Falafel)
                        {
                            Console.WriteLine($"Koken lagar {((Falafel)food).Name} som kostar {((Falafel)food).Price} i {i} secounder");
                        }
                        else if(food is Haloumi)
                        {
                            Console.WriteLine($"Koken lagar {((Haloumi)food).Name} som kostar {((Haloumi)food).Price} i {i} secounder");
                        }
                    }
                }
            
              
            }  
     
        }

    }
}
