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
            //Guest guest = new Guest();
            //Console.WriteLine($"En gäst som heter {guest.Name}, har {guest.Cash} kronor i plånboken.");
            //Chef chef = new Chef();
            //Console.WriteLine($"Kocken {chef.Name} har {chef.Competence} i kompetens");
            //Waiter waiter = new Waiter();
            //Console.WriteLine($"Servitöeren {waiter.Name} har {waiter.Competence} i ServiceNivå");
            //TableForFour table = new TableForFour();
            //Console.WriteLine($"bordets kvalité {table.Quality}");
            GenerateObjects.CreateFood();
            GenerateObjects.CreatePeople();
            GenerateObjects.CreateChefs();
            GenerateObjects.CreateWaiters();
            foreach (Guest guest in GenerateObjects._guests)
            {
                Console.WriteLine($"Gästen {guest.Name} med maten ");
            }
            foreach (Chef chef in GenerateObjects._chefs)
            {
                Console.WriteLine($"kocken {chef.Name} med {chef.Competence} kompetens");
            }
            foreach (Waiter waiter in GenerateObjects._waiters)
            {
                Console.WriteLine($"Servitör/Servitrice {waiter.Name} med {waiter.Competence} servicenivå");
            }


        }
    }
}