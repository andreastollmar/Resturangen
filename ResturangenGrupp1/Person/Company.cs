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
            List<Guest> companies = new List<Guest>();
            GenerateObjects.CreatePeople();


                int companySize = RandomSize();

                for (int i = 0; i < companySize; i++)
                {
                    companies.Add(GenerateObjects._guests[i]);
                }

                foreach (Guest company in companies)
                {
                    Console.WriteLine(company.Name);
                }

 
        }

        // Constructor

        public Company()
        {
            CompanySize = RandomSize();

        }

    }
}
