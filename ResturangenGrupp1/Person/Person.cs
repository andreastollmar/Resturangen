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
        

        internal List<Food> PreferedFood = new List<Food>();        

        // Methods
        public int RandomCash()
        {
            Random random = new Random();
            int cash = random.Next(200, 1000);
            return cash;
        }
        public void GoToTheSink(Guest guest)
        {
            Console.SetCursorPosition(5, 5);
            Console.Write(guest.Name);
        }

        public void ShowFood(Guest guest)
        {
            Console.WriteLine(guest.PreferedFood[0].Name);
        }

        // Constructor
        public Guest(): base()
        {            
            Name = Names.NameGenerator();
            TimeActivity = 20;
            Cash = RandomCash();            
            PreferedFood = new List<Food>();
        }


    }

    internal class Waiter : Person
    {
        // Properties
        public bool Busy { get; set; }
        public bool AtDoor { get; set; }
        public bool CleaningTable { get; set; }
        public bool AtKitchen { get; set; }
        public bool HelpingTable { get; set; }
        public int SetStandby { get; set; }

        public bool OrderTaken { get; set; }

        public Hashtable Order = new Hashtable();

        public List<Guest> guests = new List<Guest>();

        // Methods
        
        public void TakeFoodFromKitchen(Waiter waiter)
        {
            //Om kön är tom va ska vi göra då?
            waiter.Order.Add(1, (Hashtable)Kitchen.Kitchen.OrdersDone.Dequeue());            
            waiter.Order.Add("TableNumber", Kitchen.Kitchen.TableNumbersDone.Dequeue());
            TakeCompanyToTheTable(waiter);
        }

        public void PutFoodOnTable(Waiter waiter)
        {
            int TableNumber = (int)waiter.Order["TableNumber"];
            for (int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if (GenerateObjects._tables[i].TableNumber == TableNumber)
                {
                    GenerateObjects._tables[i].DinnerServerd = true;

                    waiter.Order.Clear();
                }
            }
        }

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
                if (table.TableSize[j] != null)
                {
                    table.FoodAtTable.AddRange(table.TableSize[j].PreferedFood);
                }
            }   

            for(int i = 0; i < table.FoodAtTable.Count; i++)
            {
                Order.Add(i , table.FoodAtTable[i]);
            }
            Kitchen.Kitchen.TableNumbersDone.Enqueue(table.TableNumber);
            
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
        private bool CheckFinnishedWithFood(Waiter waiter)
        {
            bool finnishedWithFood = false;
            for(int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if (GenerateObjects._tables[i].FinnishedWithFood && !GenerateObjects._tables[i].GetsHelp)
                {                    
                    finnishedWithFood = true;
                    waiter.Order.Add("TableNumber", GenerateObjects._tables[i].TableNumber);
                    GenerateObjects._tables[i].GetsHelp = true;
                }
            }
            return finnishedWithFood;
        }
        public void Activity(Waiter waiter)
        {            
            bool finnishedGuests = CheckFinnishedWithFood(waiter);
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
                waiter.GoToTheKitchen(waiter);
                Busy = true;
                AtKitchen = true;

            }
            else if (finnishedGuests) 
            {
                TakeCompanyToTheTable(waiter);
                waiter.HelpingTable = true;
                waiter.Busy = true;
                //Table to clean or guests finnished with food stå vid bordet och cleana tills inte busy

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
                    if (Company._companies[i].Count > 2 && Company._companies[i].Count < 5)
                    {
                        indexCompany = i;
                        break;
                    }
                }
                if(indexCompany > 85)
                {
                    for(int i = 0; i < Company._companies.Count; i++)
                    {
                        if (Company._companies[i].Count < 2)
                        {
                            indexCompany = i;
                            break;
                        }
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
                        break;
                    }
                }
                waiter.guests.AddRange(Company._companies[indexCompany]);
                Company._companies.RemoveAt(indexCompany);
            }
        }

        public void LeaveOrderToKitchen(Waiter waiter) 
        {
            Kitchen.Kitchen.OrdersToCook.Enqueue(waiter.Order);
            waiter.Busy = false;
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
        public void GoToStandBy(Waiter waiter)
        {
            Console.SetCursorPosition(waiter.SetStandby, 7);
            Console.WriteLine(waiter.Name);
        }
        public void ResetTable(Waiter waiter)
        {
            int TableNumber = (int)waiter.Order["TableNumber"];
            for (int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if (GenerateObjects._tables[i].TableNumber == TableNumber)
                {
                    GenerateObjects._tables[i].Cleaned = true;
                    GenerateObjects._tables[i].Empty = true;
                    GenerateObjects._tables[i].DinnerServerd = false;
                    GenerateObjects._tables[i].FinnishedWithFood = false;
                    GenerateObjects._tables[i].GetsHelp = false;
                    GenerateObjects._tables[i].FoodAtTable.Clear();                    
                    
                }
            }

        }
        public void TakeCashFromCompany(Waiter waiter) // Metoden till gästen för att kunna betala sin mat
        {     
            int companyCash = 0;
            int foodCost = 0;
            int TableNumber = (int)waiter.Order["TableNumber"];
            for(int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if(GenerateObjects._tables[i].TableNumber == TableNumber)
                {
                    foreach (Guest guest in GenerateObjects._tables[i].TableSize)
                    {
                        companyCash += guest.Cash;
                        foodCost += guest.PreferedFood[0].Price;

                        Eventhandler.AddEventGuest(waiter, GenerateObjects._tables[i], companyCash, foodCost);
                        
                        for (int j = 0; j < GenerateObjects._tables[i].TableSize.Length; j++)
                        {
                            GenerateObjects._tables[i].TableSize[j] = null;
                            GenerateObjects._tables[i].TableNames[j] = " ";
                        }
                    }
                }                  
            }
        }

        public void PutCompanyAtTable(Waiter waiter)
        {
            int TableNumber = (int)waiter.Order["TableNumber"];
            for (int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if(GenerateObjects._tables[i].TableNumber == TableNumber)
                {
                    for(int j = 0; j < waiter.guests.Count; j++)
                    {
                        GenerateObjects._tables[i].TableSize[j] = waiter.guests[j];
                        GenerateObjects._tables[i].TableSize[j].Satisfaction += waiter.Competence;
                    }
                    waiter.guests.Clear();
                    GenerateObjects._tables[i].Empty = false;
                    GenerateObjects._tables[i].TransferNames(GenerateObjects._tables[i].TableSize);
                    waiter.Order.Clear();
                    waiter.TakeOrderFromTable(GenerateObjects._tables[i]);
                }
            }
        }
              

        public void TakeCompanyToTheTable(Waiter waiter) // Metod för att lägga in waiter position vid alla bord
        {
            if (waiter.Order.Contains("TableNumber"))
            {
                switch (waiter.Order["TableNumber"])
                {
                    case 1:
                        Console.SetCursorPosition(20, 12);    // bord 1 
                        Console.Write(waiter.Name);
                        break;

                    case 2:
                        Console.SetCursorPosition(20, 20);    // bord 2 
                        Console.Write(waiter.Name);
                        break;

                    case 3:
                        Console.SetCursorPosition(20, 26);    // bord 3 
                        Console.Write(waiter.Name);
                        break; ;

                    case 4:
                        Console.SetCursorPosition(20, 33);    // bord 4 
                        Console.Write(waiter.Name);
                        break;

                    case 5:
                        Console.SetCursorPosition(20, 40);    // bord 5
                        Console.Write(waiter.Name);
                        break;

                    case 6:
                        Console.SetCursorPosition(40, 12);     // bord 6
                        Console.Write(waiter.Name);
                        break;

                    case 7:
                        Console.SetCursorPosition(40, 20);   // bord 7
                        Console.Write(waiter.Name);
                        break;


                    case 8:
                        Console.SetCursorPosition(40, 26);   // bord 8
                        Console.Write(waiter.Name);
                        break;

                    case 9:
                        Console.SetCursorPosition(40, 33);   // bord 9 
                        Console.Write(waiter.Name);
                        break;

                    case 10:
                        Console.SetCursorPosition(40, 40);   // bord 10
                        Console.Write(waiter.Name);
                        break;
                }
            }
            else 
            {
                int TableNumber = (int)((Hashtable)waiter.Order[1])["TableNumber"];

                switch (TableNumber)
                {
                    case 1:
                        Console.SetCursorPosition(20, 12);    // bord 1 
                        Console.Write(waiter.Name);
                        break;

                    case 2:
                        Console.SetCursorPosition(20, 20);    // bord 2 
                        Console.Write(waiter.Name);
                        break;

                    case 3:
                        Console.SetCursorPosition(20, 26);    // bord 3 
                        Console.Write(waiter.Name);
                        break; ;

                    case 4:
                        Console.SetCursorPosition(20, 33);    // bord 4 
                        Console.Write(waiter.Name);
                        break;

                    case 5:
                        Console.SetCursorPosition(20, 40);    // bord 5
                        Console.Write(waiter.Name);
                        break;

                    case 6:
                        Console.SetCursorPosition(40, 12);     // bord 6
                        Console.Write(waiter.Name);
                        break;

                    case 7:
                        Console.SetCursorPosition(40, 20);   // bord 7
                        Console.Write(waiter.Name);
                        break;

                    case 8:
                        Console.SetCursorPosition(40, 26);   // bord 8
                        Console.Write(waiter.Name);
                        break;

                    case 9:
                        Console.SetCursorPosition(40, 33);   // bord 9 
                        Console.Write(waiter.Name);
                        break;

                    case 10:
                        Console.SetCursorPosition(40, 40);   // bord 10
                        Console.Write(waiter.Name);
                        break;
                }
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
            HelpingTable = false;            
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
            CookOrders = new Hashtable();
        }

     
    }

}