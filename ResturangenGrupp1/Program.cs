using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Restaurant;
using ResturangenGrupp1.Person;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.GUI;


namespace ResturangenGrupp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            GenerateObjects.CreatePeople();
            GenerateObjects.CreateChefs();
            GenerateObjects.CreateWaiters();
            Meat.Kebab kebab = new Meat.Kebab();

            
            foreach (Guest guest in GenerateObjects._guests)
            {
                Console.WriteLine(guest.preferedFood[0].Name);
            }
            


        }
    }
}