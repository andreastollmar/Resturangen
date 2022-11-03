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
        internal bool Eating { get; set; }
        internal List<Food> preferedFood = new List<Food>();        

        // Methods
        private int RandomCash()
        {
            Random random = new Random();
            int cash = random.Next(100, 500);
            return cash;
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
        public bool CleaningTable { get; set; }
        public bool AtKitchen { get; set; }

        public bool OrderTaken { get; set; }
        public Hashtable Order = new Hashtable();

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
                    break;
                }
            }
            return freeTable;
        }
        public void TakeOrderFromTable(ITable table)
        {
            for (int j = 0; j < table.TableSize.Length; j++)
            {
                table.FoodAtTable.AddRange(table.TableSize[j].preferedFood);
            }   

            for(int i = 0; i < table.FoodAtTable.Count; i++)
            {
                Order.Add(i , table.FoodAtTable[i].Name);
            }
            Order.Add("TableNumber",  table.TableNumber);
            
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
            else if (true) //Table to clean or guests finnished with food stå vid bordet och cleana tills inte busy
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
                    waiter.Order.Add("TableNumber", GenerateObjects._tables[i].TableNumber);
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

        public void GoToTheDoor(Waiter waiter) // Metod för flytta waiter position vid dörren 
        {
            Console.SetCursorPosition(47,5);
            Console.Write(waiter.Name);
        }

        public void GoToTheKitchen(Waiter waiter) // Metod för att flytta waiter postion vid köket
        {
            Console.SetCursorPosition(25, 5);
            Console.Write(waiter.Name);
        }

        public void PutCompanyAtTable(Waiter waiter)
        {
            int TableNumber = (int)waiter.Order["TableNumber"];
            for (int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if(GenerateObjects._tables[i].TableNumber == TableNumber)
                {
                    for(int j =0; j < waiter.guests.Count; i++)
                    {
                        GenerateObjects._tables[i].TableSize[j] = waiter.guests[j];
                    }
                    waiter.guests.Clear();
                    GenerateObjects._tables[i].TransferNames(GenerateObjects._tables[i].TableSize);
                    waiter.TakeOrderFromTable(GenerateObjects._tables[i]);
                }
            }
        }
              

        public void TakeCompanyToTheTable(Waiter waiter) // Metod för att lägga in waiter position vid alla bord
        {
            switch (waiter.Order["TableNumber"])
            {
                case 1: 
                    Console.SetCursorPosition(7, 12);    // bord 1 
                    Console.Write(waiter.Name);
                    break;

                case 2:
                    Console.SetCursorPosition(7, 20);    // bord 2 
                    Console.Write(waiter.Name);
                    break ;

                case 3:
                    Console.SetCursorPosition(7, 26);    // bord 3 
                    Console.Write(waiter.Name);
                    break;;

                case 4:
                    Console.SetCursorPosition(7, 33);    // bord 4 
                    Console.Write(waiter.Name);
                    break;

                case 5:
                    Console.SetCursorPosition(7, 40);    // bord 5
                    Console.Write(waiter.Name);
                    break;

                case 6:
                    Console.SetCursorPosition(7, 8);     // bord 6
                    Console.Write(waiter.Name);
                    break;

                case 7:
                    Console.SetCursorPosition(42, 15);   // bord 7
                    Console.Write(waiter.Name);
                    break;

                case 8:
                    Console.SetCursorPosition(42, 22);   // bord 8
                    Console.Write(waiter.Name);
                    break;

                case 9:
                    Console.SetCursorPosition(42, 28);   // bord 9 
                    Console.Write(waiter.Name);
                    break;

                case 10:
                    Console.SetCursorPosition(42, 35);   // bord 10
                    Console.Write(waiter.Name);
                    break;

            }
        }
           
     
        // Constructor
        public Waiter(): base()
        {
            Name = Names.NameGenerator();
            TimeActivity = 3;
            Busy = false;
            AtDoor = false;
            OrderTaken = false;
            AtKitchen = false;
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