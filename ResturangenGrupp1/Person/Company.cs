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


            for (int j = 0; j < GenerateObjects._guests.Count; j++)
            {
                int companySize = RandomSize();

                for (int i = 0; i < companySize; i++)
                {
                    companies.Add(new List<Guest>() { GenerateObjects._guests[i] });
                    GenerateObjects._guests.RemoveAt(i);
                }

                Console.WriteLine("**********");

                foreach (var company in companies)
                {
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
