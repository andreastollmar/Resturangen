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

            GenerateObjects.CreateObjects();

            foreach (TableForFour table in GenerateObjects._tablesForFour)
            {
                Console.WriteLine("Kvalité bra = " + table.Quality);
            }
            
            foreach (Guest guest in GenerateObjects._guests)
            {
                Console.WriteLine(guest.preferedFood[0].Name);
                Console.WriteLine(guest.Cash);
                Console.WriteLine(guest.NutAllergy);
            }
            


        }
    }
}