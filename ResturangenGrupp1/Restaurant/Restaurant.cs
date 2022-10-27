using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.Person;
using ResturangenGrupp1.Restaurant;
using ResturangenGrupp1.GUI;

namespace ResturangenGrupp1.Restaurant
{
    internal class Restaurant
    {


        public bool CheckTableForFree()
        {
            bool tableFree = false;

            foreach (TableForFour table in GenerateObjects._tablesForFour)
            {
                if (table.Empty)
                {
                    tableFree = true;
                }
            }
            foreach (TableForTwo table in GenerateObjects._tablesForTwo)
            {
                if(table.Empty)
                {
                    tableFree = true;
                }
            }
            return tableFree;
        }

        public int MatchCheckTable(int guestSize)
        {
            int indexValue = 0;
            if (guestSize > 2)
            {
                indexValue = CheckTableForFour();
            }
            else
            {
                indexValue = CheckTableForTwo();
            }
            return indexValue;            
        }

        private int CheckTableForFour()
        {
            int indexValue = 0;            
            for (int i = 0; i < GenerateObjects._tablesForFour.Count; i++)
            {
                if (GenerateObjects._tablesForFour[i].Empty)
                {
                    indexValue = i;                    
                }
                else
                {
                    indexValue = 10;
                }
            }
            return indexValue;            
        }
        private int CheckTableForTwo()
        {
            int indexValue = 0;
            for (int i = 0; i < GenerateObjects._tablesForTwo.Count; i++)
            {
                if (GenerateObjects._tablesForTwo[i].Empty)
                {
                    indexValue = i;
                }
                else
                {
                    indexValue = 10;
                }
            }
            return indexValue;
        }



    }
}
