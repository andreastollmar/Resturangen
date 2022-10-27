using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturangenGrupp1.Restaurant
{
    interface ITable
    {
        
        bool Quality { get; set; }
        bool Empty { get; set; }
        bool Cleaned { get; set; }
        bool GetsHelp { get; set; }
        bool RandomQuality();
    }
    class TableForTwo : ITable
    {        
        public bool Quality { get; set; }
        public bool Empty { get; set; }
        public bool Cleaned { get; set; }
        public bool GetsHelp { get; set; }

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
        public TableForTwo()
        {
            string[] tableSize = new string[2];
            Quality = RandomQuality();
        }
    }
    class TableForFour : ITable
    {        
        public bool Quality { get; set; }
        public bool Empty { get; set; }
        public bool Cleaned { get; set; }
        public bool GetsHelp { get; set; }
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
        public TableForFour()
        {
            string[] tableSize = new string[4];
            Quality = RandomQuality();
        }
    }



}
