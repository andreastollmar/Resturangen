using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Restaurant;
using ResturangenGrupp1.Person;



namespace ResturangenGrupp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guest guest = new Guest();
            Console.WriteLine($"En gäst som heter {guest.Name}, har {guest.Cash} kronor i plånboken");
        }
    }
}