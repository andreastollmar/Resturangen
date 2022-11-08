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
        // Properties
        internal string Name { get; set; }
        internal int Competence { get; set; }
        internal int TimeActivity { get; set; }
        
        // Methods
        private protected int RandomCompetence()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }

        // Constructor
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
            Name = Names.NameGenerator(109);
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

        public List<Guest> Guests = new List<Guest>();

        // Methods
        public void TakeFoodFromKitchen()
        {
            Order.Clear();
            
            Order.Add(1, (Hashtable)Kitchen.Kitchen.OrdersDone.Dequeue());            
            Order.Add("TableNumber", Kitchen.Kitchen.TableNumbersDone.Dequeue());
            GoToTable();
        }
        public void PutFoodOnTable()
        {
            int TableNumber = (int)Order["TableNumber"];
            for (int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if (GenerateObjects._tables[i].TableNumber == TableNumber)
                {
                    GenerateObjects._tables[i].DinnerServerd = true;

                    Order.Clear();
                }
            }
        }
        private bool FindFreeTable()
        {
            bool freeTable = false;
            if(Company._companies.Count > 0)
            {
                for (int i = 0; i < GenerateObjects._tables.Count; i++)
                {
                    if (GenerateObjects._tables[i].Empty)
                    {
                        freeTable = true;
                        break;
                    }
                }
                for (int i = 0; i < GenerateObjects._waiters.Count; i++)
                {
                    if (GenerateObjects._waiters[i].AtDoor)
                    {
                        freeTable = false;
                    }
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
            for (int i = 0; i < GenerateObjects._waiters.Count; i++)
            {
                if (GenerateObjects._waiters[i].AtKitchen)
                {
                    orderDone = false;
                }
            }
            return orderDone;
        }
        private bool CheckFinnishedWithFood()
        {
            
            bool finnishedWithFood = false;
            for(int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if (GenerateObjects._tables[i].FinnishedWithFood && !GenerateObjects._tables[i].GetsHelp)
                {                    
                    finnishedWithFood = true;
                    Order.Add("TableNumber", GenerateObjects._tables[i].TableNumber);
                    GenerateObjects._tables[i].GetsHelp = true;
                    break;
                }
            }
            return finnishedWithFood;
        }
        public void Activity()
        {            
            bool finnishedGuests = CheckFinnishedWithFood();
            bool foodToServe = CheckFoodToServe();
            bool tableFree = FindFreeTable();
            if (finnishedGuests)
            {
                GoToTable();
                HelpingTable = true;
                Busy = true;
            }
            else if (tableFree)
            {
                AtDoor = true;
                Busy = true;
                GoToTheDoor();
            }
            else if (foodToServe) 
            {
                GoToTheKitchen();
                Busy = true;
                AtKitchen = true;

            }
        }
        
        public void MatchTableWithGuests()
        {
            Order.Clear();
            int indexTable = 10;
            int indexCompany = 90;
            for (int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if (GenerateObjects._tables[i].Empty)
                {
                    indexTable = i;
                    Order.Add("TableNumber", GenerateObjects._tables[i].TableNumber);
                    break;
                }
            }
            
            if (GenerateObjects._tables[indexTable] is TableForFour && indexTable < 10)
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
                if(indexCompany < 85)
                {
                    Guests.AddRange(Company._companies[indexCompany]);
                    Company._companies.RemoveAt(indexCompany);
                }
                
            }
            if (GenerateObjects._tables[indexTable] is TableForTwo && indexTable < 10)
            {
                for (int i = 0; i < Company._companies.Count; i++)
                {
                    if (Company._companies[i].Count <= 2)
                    {
                        indexCompany = i;
                        break;
                    }
                }
                if(indexCompany < 80)
                {
                    Guests.AddRange(Company._companies[indexCompany]);
                    Company._companies.RemoveAt(indexCompany);
                }
            }
        }

        public void LeaveOrderToKitchen() 
        {
            Kitchen.Kitchen.OrdersToCook.Enqueue(Order);
            Busy = false;
        }

        public void GoToTheDoor() // Metod för flytta waiter position vid dörren 
        {
            Console.SetCursorPosition(47,5);
            Console.Write(Name);
        }

        public void GoToTheKitchen() // Metod för att flytta waiter postion vid köket
        {
            Console.SetCursorPosition(25, 5);
            Console.Write(Name);
        }
        public void GoToStandBy()
        {
            Console.SetCursorPosition(SetStandby, 7);
            Console.WriteLine(Name);
        }
        public void ResetTable()
        {
            int TableNumber = (int)Order["TableNumber"];
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
        public void TakeCashFromCompany() // Metoden till gästen för att kunna betala sin mat
        {     
            int companyCash = 0;
            int foodCost = 0;            
            int TableNumber = (int)Order["TableNumber"];            
            for(int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if(GenerateObjects._tables[i].TableNumber == TableNumber)
                {
                    Guests.AddRange(GenerateObjects._tables[i].TableSize);
                    for (int j = 0; j < GenerateObjects._tables[i].TableSize.Length; j++)
                    {
                        GenerateObjects._tables[i].TableSize[j] = null;
                        GenerateObjects._tables[i].TableNames[j] = " ";
                    }                    
                    for (int k = 0; k < Guests.Count; k++)
                    {
                        if (Guests[k] != null)
                        {
                            companyCash += Guests[k].Cash;
                            foodCost += Guests[k].PreferedFood[0].Price;
                        }
                        
                    }                    
                    Eventhandler.AddEventGuest(Guests, Competence, GenerateObjects._tables[i], companyCash, foodCost);
                    
                    



                }
            }
        }

        public void PutCompanyAtTable()
        {
            int TableNumber = (int)Order["TableNumber"];
            for (int i = 0; i < GenerateObjects._tables.Count; i++)
            {
                if(GenerateObjects._tables[i].TableNumber == TableNumber)
                {
                    for(int j = 0; j < Guests.Count; j++)
                    {
                        GenerateObjects._tables[i].TableSize[j] = Guests[j];
                        GenerateObjects._tables[i].TableSize[j].Satisfaction += Competence;
                    }
                    Guests.Clear();
                    GenerateObjects._tables[i].Empty = false;
                    GenerateObjects._tables[i].TransferNames(GenerateObjects._tables[i].TableSize);
                    Order.Clear();
                    TakeOrderFromTable(GenerateObjects._tables[i]);
                }
            }
        }
              

        public void GoToTable() // Metod för att lägga in waiter position vid alla bord
        {
            if (Order.Contains("TableNumber"))
            {
                switch (Order["TableNumber"])
                {
                    case 1:
                        Console.SetCursorPosition(20, 12);    // bord 1 
                        Console.Write(Name);
                        break;

                    case 2:
                        Console.SetCursorPosition(20, 19);    // bord 2 
                        Console.Write(Name);
                        break;

                    case 3:
                        Console.SetCursorPosition(20, 26);    // bord 3 
                        Console.Write(Name);
                        break; ;

                    case 4:
                        Console.SetCursorPosition(20, 33);    // bord 4 
                        Console.Write(Name);
                        break;

                    case 5:
                        Console.SetCursorPosition(20, 40);    // bord 5
                        Console.Write(Name);
                        break;

                    case 6:
                        Console.SetCursorPosition((46 - Name.Length), 12);     // bord 6
                        Console.Write(Name);
                        break;

                    case 7:
                        Console.SetCursorPosition((46 - Name.Length), 19);   // bord 7
                        Console.Write(Name);
                        break;


                    case 8:
                        Console.SetCursorPosition((46 - Name.Length), 26);   // bord 8
                        Console.Write(Name);
                        break;

                    case 9:
                        Console.SetCursorPosition((46 - Name.Length), 33);   // bord 9 
                        Console.Write(Name);
                        break;

                    case 10:
                        Console.SetCursorPosition((46 - Name.Length), 40);   // bord 10
                        Console.Write(Name);
                        break;
                }
            }
        }
           
        // Constructor
        public Waiter(): base()
        {
            Random rnd = new Random();
            bool condition = rnd.NextDouble() > 0.5;
            Name = condition ? "Servitör " + Names.NameGenerator(20) : "Servitris " + Names.NameGenerator(20);
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
        public void Activity()
        {            
            bool ordersToCook = CheckOrders();
            if(ordersToCook)
            {
                CookOrders.Add("Order", Kitchen.Kitchen.OrdersToCook.Dequeue());
                Busy = true;
            }
        }
        public void OrderDone()
        {
            Kitchen.Kitchen.OrdersDone.Enqueue(CookOrders);
            CookOrders.Clear();
            Busy = false;
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
            Name = Names.NameGenerator(109);
            TimeActivity = 10;
            Busy = false;
            Competence = RandomCompetence();
            CookOrders = new Hashtable();
        }
    }
}