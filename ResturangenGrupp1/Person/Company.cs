using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.GUI;
using ResturangenGrupp1.Restaurant;

namespace ResturangenGrupp1.Person
{
    internal class Company
    {
        // Properties
        private int CompanySize { get; set; }
        private int CompanyCash { get; set; }
        private List<Guest> CompanyList { get; set; }




        //Methods

        private protected static int RandomSize()
        {
            Random random = new Random();
            return random.Next(1, 5);
        }

        public static void CreateCompany()
        {
            List<List<Guest>> companies = new List<List<Guest>>(); 
            int companySize = RandomSize();

            int amountOfCompanies = 80 / companySize;

            for (int j = 0; j < 1; j++)
            {

                for (int i = 0; i < amountOfCompanies; i++)
                {
                    for (int k = 0; k < companySize; k++)
                    {
                        companies.Add(new List<Guest>() { GenerateObjects._guests[k] });
                        GenerateObjects._guests.RemoveAt(k);

                    }
                }

               


                foreach (var company in companies)
                {
                    Console.WriteLine("**********");

                    foreach (var guest in company)
                    {
                        Console.WriteLine(guest.Name);
                    }
                }

            }

        }

        // Constructor

        public Company()
        {
            CompanySize = RandomSize();

        }

    }
}
