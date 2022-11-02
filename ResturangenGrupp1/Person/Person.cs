using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.GUI;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.Restaurant;

namespace ResturangenGrupp1.Person
{
    internal class Person
    {
        internal string Name { get; set; }
        internal int Competence { get; set; }
        internal int TimeActivity { get; set; }

        private protected int RandomCompetence()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }

        public Person()
        {
            Name = "";
            TimeActivity = 0;
            Competence = 0;
        }
    }

    internal class Guest : Person
    {
        // Properties
        internal int Satisfaction { get; set; }
        internal int Cash { get; set; }
        internal bool AtTable { get; set; }
        internal List<Food> preferedFood = new List<Food>();        

        // Methods
        private int RandomCash()
        {
            Random random = new Random();
            int cash = random.Next(100, 500);
            return cash;
        }
        private void Eating()
        {
            for (int i = TimeActivity; i < 1; i--)
            {
                AtTable = true;
            }
        }
        
        public void ShowFood(Guest guest)
        {
            Console.WriteLine(guest.preferedFood[0].Name);
        }

        // Constructor
        public Guest(): base()
        {            
            Name = Names.NameGenerator();
            TimeActivity = 20;
            Cash = RandomCash();          
        }

        public void GoToTheSink(Guest guest)
        {
            Console.SetCursorPosition(5, 5);
            Console.Write(guest.Name);
        }
    }

    internal class Waiter : Person
    {
        // Properties
        public bool Busy { get; set; }
        public bool AtDoor { get; set; }
        public List<string> Order { get; set; }
        public List<Guest> guests = new List<Guest>();

        // Methods
        private void Cleaning()
        {
            for (int i = TimeActivity; i < 1; i--)
            {
                Busy = true;
            }
            Busy = false;
        }
        public bool FindFreeTable()
        {
            bool freeTable = false;
            for (int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if (GenerateObjects._tables[i].Empty)
                { 
                    freeTable = true;
                }
            }
            return freeTable;
        }
        public void TakeOrderFromTable(ITable table)
        {
            foreach (Food food in table.FoodAtTable)
            {
                Order.Add(food.Name);
            }
        }
        public void Activity()
        {
            bool tableToClean;
            bool finnishedGuests;
            bool tableFree = FindFreeTable();
            if (tableFree)
            {
                AtDoor = true;
                Busy = true;
                //Go to door method
            }
            else if (true) //food to serve
            {
                
            }
            else if (true) //Table to clean or guests finnished with food
            {


            }

        }
        public void MatchTableWithGuests(Waiter waiter)
        {
            int indexTable = 10;
            int indexCompany = 90;
            for (int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if (GenerateObjects._tables[i].Empty)
                {
                    indexTable = i;
                    break;
                }
            }
            if (GenerateObjects._tables[indexTable] is TableForFour)
            {
                for (int i = 0; i < Company._companies.Count; i++)
                {
                    if (Company._companies[i].Count > 2)
                    {
                        indexCompany = i;
                    }
                }
            }
            if (GenerateObjects._tables[indexTable] is TableForTwo)
            {
                for (int i = 0; i < Company._companies.Count; i++)
                {
                    if (Company._companies[i].Count <= 2)
                    {
                        indexCompany = i;
                    }
                }
            }

            waiter.guests.AddRange(Company._companies[indexCompany]);
            Company._companies.RemoveAt(indexCompany);

        }

        public void GoToTheDoor(Waiter waiter)
        {
            Console.SetCursorPosition(47,5);
            Console.Write(waiter.Name);
        }

        public void GoToTheKitchen(Waiter waiter)
        {
            Console.SetCursorPosition(25, 5);
            Console.Write(waiter.Name);
        }
     

        // Constructor
        public Waiter(): base()
        {
            Name = Names.NameGenerator();
            TimeActivity = 3;
            Busy = false;
            AtDoor = false;
            Competence = RandomCompetence();            
            //Order = ; Hämta lista från bordet och ta till köket. Ta lista från köket till bordet
        }

    }

    internal class Chef : Person
    {
        // Properties
        private bool Busy { get; set; }

        // Methods
        private void Cooking()
        {
            for (int i = TimeActivity; i < 1; i--)
            {
                Busy = true;
            }
            Busy = false;
        }
        
        // Constructor
        public Chef(): base()
        {
            Name = Names.NameGenerator();
            TimeActivity = 10;
            Busy = false;
            Competence = RandomCompetence();
        }

     
    }

}