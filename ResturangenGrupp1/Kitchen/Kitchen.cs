using ResturangenGrupp1.Person;
using ResturangenGrupp1.Restaurant;
using System;
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
        public void CookFood(List<Food> meny, int Time)
        {
            for (int i = 0; i <= Time; i++)
            {

                foreach (Food food in meny)
                {
                    if(food is Meat)
                    {
                        if (food is Kebab)
                        {
                            Console.WriteLine($"Koken lagar {((Kebab)food).Name} ");
                        }
                        if (food is Steak)
                        {
                            Console.WriteLine($"Koken lagar {((Steak)food).Name} ");
                        }
                        else if (food is Beef)
                        {
                            Console.WriteLine($"Koken lagar {((Beef)food).Name} ");
                        }
                    }

                
                    if (food is Fish)
                    {
                        if(food is Scallop)
                        {
                            Console.WriteLine($"Koken lagar {((Scallop)food).Name} ");
                        }
                        if(food is Tuna)
                        {
                            Console.WriteLine($"Koken lagar {((Tuna)food).Name} ");
                        }
                        else if(food is Moules)
                        {
                            Console.WriteLine($"Koken lagar {((Moules)food).Name} ");
                        }
                    }

                    if (food is Vegetarian)
                    {
                        if(food is Risotto)
                        {
                            Console.WriteLine($"Koken lagar {((Risotto)food).Name} ");
                        }
                        if(food is Falafel)
                        {
                            Console.WriteLine($"Koken lagar {((Falafel)food).Name} ");
                        }
                        else if(food is Haloumi)
                        {
                            Console.WriteLine($"Koken lagar {((Haloumi)food).Name} ");
                        }
                    }
                }
            
              
            }  
     
        }

    }
}
