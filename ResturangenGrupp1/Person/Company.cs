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
        public static List<Guest> CompanyList = new List<Guest>();
        public static List<List<Guest>> _companies = new List<List<Guest>>();


        //Methods
        private protected static int RandomSize()
        {
            Random random = new Random();
            return random.Next(1, 5);
        }

        public static void CreateCompany()
        {            
            for (int j = 0; j < GenerateObjects._guests.Count; j++)
            {
                int companySize = RandomSize();
                if (companySize > GenerateObjects._guests.Count)
                {
                    companySize = GenerateObjects._guests.Count;
                    for (int k = 0; k < companySize; k++)
                    {
                        CompanyList.Add(GenerateObjects._guests[k]);
                    }
                    GenerateObjects._guests.Clear();
                }
                else 
                {                    
                    for (int i = 0; i < companySize; i++)
                    {
                        if (i >= GenerateObjects._guests.Count)
                        {
                            companySize = GenerateObjects._guests.Count;
                            i = 0;
                        }
                        CompanyList.Add(GenerateObjects._guests[i]);
                        GenerateObjects._guests.RemoveAt(i);
                    }
                }                
                _companies.Add(new List<Guest> (CompanyList) );
                CompanyList.Clear();
                j = 0;
            }
        }

        // Constructor
        public Company()
        {
            CompanySize = RandomSize();
        }
    }
}
