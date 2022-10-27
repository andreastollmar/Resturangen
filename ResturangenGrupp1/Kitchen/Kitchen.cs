using ResturangenGrupp1.Person;
using ResturangenGrupp1.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturangenGrupp1.Kitchen
{
    internal class Kitchen
    {
        Food food = new Food();
        public int Time { get; set; } = 10;
        public int Kock { get; set; } = 5;


        public Kitchen(int time, int kock)
        {
            Time = time;
            Kock = kock;
        }

        public void CookFood(List<Food> meny)
        {
     
        }

       


    }
}
