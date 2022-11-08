using ResturangenGrupp1.GUI;
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
        bool FinnishedWithFood { get; set; }
        bool DinnerServerd { get; set; }
        int TableNumber { get; set; }
        bool Cleaned { get; set; }
        bool GetsHelp { get; set; }
        bool RandomQuality();
        void TransferNames(Guest[] guests);
        void DrawTable();


    }
    class TableForTwo : ITable
    {        
        public bool Quality { get; set; }
        public bool Empty { get; set; }
        public bool DinnerServerd { get; set; }
        public bool FinnishedWithFood { get; set; }
        public bool Cleaned { get; set; }
        public int TableNumber { get; set; }
        public string[] TableNames { get; set; }
        public bool GetsHelp { get; set; }
        public List<Food> FoodAtTable { get; set; }
        public Guest[] TableSize { get; set; }
        public void DrawTable()
        {
            switch (TableNumber)
            {
                case 1:
                    Window.Draw("Table 1 ", 5, 10, GenerateObjects._tables[0].TableNames);
                    break;
                case 2:
                    Window.Draw("Table 2 ", 5, 17, GenerateObjects._tables[1].TableNames);
                    break;
                case 3:
                    Window.Draw("Table 3 ", 5, 24, GenerateObjects._tables[2].TableNames);
                    break;
                case 4:
                    Window.Draw("Table 4 ", 5, 31, GenerateObjects._tables[3].TableNames);
                    break;
                case 5:
                    Window.Draw("Table 5 ", 5, 38, GenerateObjects._tables[4].TableNames);
                    break;
                case 6:
                    Window.Draw("Table 6 ", 45, 10, GenerateObjects._tables[5].TableNames);
                    break;
                case 7:
                    Window.Draw("Table 7 ", 45, 17, GenerateObjects._tables[6].TableNames);
                    break;
                case 8:
                    Window.Draw("Table 8 ", 45, 24, GenerateObjects._tables[7].TableNames);
                    break;
                case 9:
                    Window.Draw("Table 9 ", 45, 31, GenerateObjects._tables[8].TableNames);
                    break;
                case 10:
                    Window.Draw("Table 10", 45, 38, GenerateObjects._tables[9].TableNames);
                    break;
            }
        }
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
                if (guests[i] == null)
                {
                    TableNames[i] = " ";
                }
                else
                {
                    TableNames[i] = guests[i].Name;
                }
            }
        }
        public TableForTwo()
        {            
            Empty = true;
            Cleaned = true;
            GetsHelp = false;            
            Quality = RandomQuality();
            TableNames = new string[2];
            TableNames[0] = " ";
            TableNames[1] = " ";
            TableSize = new Guest[2];
            FoodAtTable = new List<Food>();
            FinnishedWithFood = false;
            DinnerServerd = false;

        }
    }
    class TableForFour : ITable
    {
        public List<Food> FoodAtTable { get; set; }
        public string[] TableNames { get; set; }
        public bool FinnishedWithFood { get; set; }
        public bool Quality { get; set; }
        public bool DinnerServerd { get; set; }
        public bool Empty { get; set; }
        public int TableNumber { get; set; }
        public bool Cleaned { get; set; }
        public bool GetsHelp { get; set; }
        public Guest[] TableSize { get; set; }
        public void DrawTable()
        {
            switch(TableNumber)
            {
                case 1:
                    Window.Draw("Table 1 ", 5, 10, GenerateObjects._tables[0].TableNames);
                    break;
                case 2:
                    Window.Draw("Table 2 ", 5, 17, GenerateObjects._tables[1].TableNames);
                    break;
                case 3:
                    Window.Draw("Table 3 ", 5, 24, GenerateObjects._tables[2].TableNames);
                    break;
                case 4:
                    Window.Draw("Table 4 ", 5, 31, GenerateObjects._tables[3].TableNames);
                    break;
                case 5:
                    Window.Draw("Table 5 ", 5, 38, GenerateObjects._tables[4].TableNames);
                    break;
                case 6:
                    Window.Draw("Table 6 ", 45, 10, GenerateObjects._tables[5].TableNames);
                    break;
                case 7:
                    Window.Draw("Table 7 ", 45, 17, GenerateObjects._tables[6].TableNames);
                    break;
                case 8:
                    Window.Draw("Table 8 ", 45, 24, GenerateObjects._tables[7].TableNames);
                    break;
                case 9:
                    Window.Draw("Table 9 ", 45, 31, GenerateObjects._tables[8].TableNames);
                    break;
                case 10:
                    Window.Draw("Table 10", 45, 38, GenerateObjects._tables[9].TableNames);
                    break;
            }

        }
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
                    TableNames[i] = " ";
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
            TableNames[0] = " ";
            TableNames[1] = " ";
            TableNames[2] = " ";
            TableNames[3] = " ";
            TableSize = new Guest[4];
            FoodAtTable = new List<Food>();
            FinnishedWithFood = false;
            DinnerServerd = false;
        }
    }



}
