using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.Person;
using ResturangenGrupp1.Restaurant;

namespace ResturangenGrupp1.GUI
{
    internal class Helper
    {
        public int FindFreeWaiter(List<Waiter> waiters)
        {
            int index = 5;
            for (int i = 0; i < waiters.Count; i++)
            {
                if (!waiters[i].Busy)
                {
                    index = i;
                }
            }
            return index;
        }
        public static void Eraser(int fromPosX, int fromPosY, int toPosY)
        {
            for (int i = fromPosY; i < toPosY; i++)
            {
                Console.SetCursorPosition(fromPosX, i);
                Console.WriteLine("                                        ");
            }
        }
    }
}
