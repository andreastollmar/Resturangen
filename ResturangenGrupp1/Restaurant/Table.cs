using ResturangenGrupp1.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturangenGrupp1.Restaurant
{
    interface ITable
    {
        List<Food> FoodAtTable { get; set; }
        Guest[] TableSize { get; set; }
        string[] TableNames { get; set; }
        bool Quality { get; set; }
        bool Empty { get; set; }
        int TableNumber { get; set; }
        bool Cleaned { get; set; }
        bool GetsHelp { get; set; }
        bool RandomQuality();
        void TransferNames(Guest[] guests);
    }
    class TableForTwo : ITable
    {        
        public bool Quality { get; set; }
        public bool Empty { get; set; }
        public bool Cleaned { get; set; }
        public int TableNumber { get; set; }
        public string[] TableNames { get; set; }
        public bool GetsHelp { get; set; }
        public List<Food> FoodAtTable { get; set; }
        public Guest[] TableSize { get; set; }
        public bool RandomQuality()
        {
            bool goodQuality = false;
            Random rnd = new Random();
            int randomQuality = rnd.Next(0, 100);
            if (randomQuality >= 60)
            {
                goodQuality = true;
            }
            return goodQuality;
        }
        public void TransferNames(Guest[] guests)
        {
            for (int i = 0; i < guests.Length; i++)
            {
                TableNames[i] = guests[i].Name;
            }
        }
        public TableForTwo()
        {            
            Empty = true;
            Cleaned = true;
            GetsHelp = false;            
            Quality = RandomQuality();
            TableNames = new string[2];
            TableSize = new Guest[2];
            FoodAtTable = new List<Food>();
        }
    }
    class TableForFour : ITable
    {
        public string[] TableNames { get; set; }
        public List<Food> FoodAtTable { get; set; }
        public bool Quality { get; set; }
        public bool Empty { get; set; }
        public int TableNumber { get; set; }
        public bool Cleaned { get; set; }
        public bool GetsHelp { get; set; }
        public Guest[] TableSize { get; set; }
        public bool RandomQuality()
        {
            bool goodQuality = true;
            Random rnd = new Random();
            int randomQuality = rnd.Next(0, 100);
            if (randomQuality >= 60)
            {
                goodQuality = false;
            }
            return goodQuality;
        }
        public void TransferNames(Guest[] guests)
        {
            for (int i = 0; i < guests.Length; i++)
            {
                if (guests[i] == null)
                {
                    TableNames[i] = "Empty";
                }
                else 
                {
                    TableNames[i] = guests[i].Name;
                }
            }
        }
        public TableForFour()
        {            
            Empty = true;
            Cleaned = true;
            GetsHelp = false;
            Quality = RandomQuality();
            TableNames = new string[4];
            TableSize = new Guest[4];
            FoodAtTable = new List<Food>();
        }
    }



}
