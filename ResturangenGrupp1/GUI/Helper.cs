using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public static void DisplayThings<T>(T value)
        {            
            if(value is string)
            {                
                Console.SetCursorPosition(66, 25);
                Console.WriteLine(value + " " + (Math.Round(Eventhandler.Tips)) + " kr");
            }
            else if (value is string[])
            {
                if((value as Array).Length < 10)
                {
                    Window.Draw("Events", 66, 13, (value as string[]));
                }
                else if((value as Array).Length >= 10)
                {
                    Window.Draw("Guests waiting", 66, 1, (value as string[]));
                }
            }
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
