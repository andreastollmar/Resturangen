using System;
using System.Collections;
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
    }

    internal class Waiter : Person
    {
        // Properties
        public bool Busy { get; set; }
        public bool AtDoor { get; set; }
        public bool CleaningTable { get; set; }
        public bool AtKitchen { get; set; }
        public Hashtable Order { get; set; }
        public List<Guest> guests = new List<Guest>();

        // Methods
        
        private bool FindFreeTable()
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
            for(int i = 0; i < table.FoodAtTable.Count; i++)
            {
                Order.Add("Food" + i, table.FoodAtTable[i].Name);
            }
            Order.Add("TableNr", table.TableNumber);
            
        }
        private bool CheckFoodToServe()
        {
            bool orderDone = false;
            if(Kitchen.Kitchen.OrdersDone.Count > 0)
            {
                orderDone = true;
            }
            return orderDone;
        }
        public void Activity(Waiter waiter)
        {
            bool tableToClean;
            bool finnishedGuests;
            bool foodToServe = CheckFoodToServe();
            bool tableFree = FindFreeTable();
            if (tableFree)
            {
                AtDoor = true;
                Busy = true;
                GoToTheDoor(waiter);
            }
            else if (foodToServe) 
            {
                //move to kitchen
                Busy = true;
                AtKitchen = true;

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
                if(indexCompany > 85)
                {
                    for(int i = 0; i < Company._companies.Count; i++)
                    {
                        if (Company._companies[i].Count < 2)
                            indexCompany = i;
                    }
                }
                waiter.guests.AddRange(Company._companies[indexCompany]);
                Company._companies.RemoveAt(indexCompany);
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
                waiter.guests.AddRange(Company._companies[indexCompany]);
                Company._companies.RemoveAt(indexCompany);
            }

            

        }

        public void GoToTheDoor(Waiter waiter)
        {
            Console.SetCursorPosition(47,5);
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
        public bool Busy { get; set; }
        public Hashtable CookOrders { get; set; }
        // Methods
        public void Activity(Chef chef)
        {            
            bool ordersToCook = CheckOrders();
            if(ordersToCook)
            {
                chef.CookOrders.Add("Order", Kitchen.Kitchen.OrdersToCook.Dequeue());
                chef.Busy = true;
            }
        }
        public void OrderDone(Chef chef)
        {
            Kitchen.Kitchen.OrdersDone.Enqueue(chef.CookOrders);
            chef.CookOrders.Clear();
            chef.Busy = false;
        }
        private bool CheckOrders()
        {
            bool ordersToCook = false;
            if (Kitchen.Kitchen.OrdersToCook.Count > 0)
            {
                ordersToCook = true;
            }
            return ordersToCook;
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