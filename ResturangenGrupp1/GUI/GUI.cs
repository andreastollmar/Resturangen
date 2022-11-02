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
    internal class GUI
    {
        public void StartResturant()
        {
            GenerateObjects.CreateObjects();
            Company.CreateCompany();
            while (true)
            {
                Window.DrawRestaurant();

                for (int i = 0; i < GenerateObjects._waiters.Count; i++)
                {
                    if (!GenerateObjects._waiters[i].Busy)
                    {
                        GenerateObjects._waiters[i].Activity();
                        //break forloop;
                    }
                    else if (GenerateObjects._waiters[i].Busy && GenerateObjects._waiters[i].AtDoor)
                    {
                        GenerateObjects._waiters[i].MatchTableWithGuests(GenerateObjects._waiters[i]);
                    }
                }
                Console.ReadKey();

                
            }
        }
    }
    public class Window
    {
        public static void Draw(string header, int fromLeft, int fromTop, string[] graphics)
        {

            int width = 0;
            for (int i = 0; i < graphics.Length; i++)
            {
                if (graphics[i].Length > width)
                {
                    width = graphics[i].Length;
                }
            }
            if (width < header.Length + 4)
            { width = header.Length + 4; };

            Console.SetCursorPosition(fromLeft, fromTop);
            if (header != "")
            {
                Console.Write('┌' + " ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(header);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" " + new String('─', width - header.Length) + '┐');
            }
            else
            {
                Console.Write('┌' + new String('─', width + 2) + '┐');
            }
            Console.WriteLine();
            int maxRows = 0;
            for (int j = 0; j < graphics.Length; j++)
            {
                Console.SetCursorPosition(fromLeft, fromTop + j + 1);
                Console.WriteLine('│' + " " + graphics[j] + new String(' ', width - graphics[j].Length + 1) + '│');
                maxRows = j;
            }
            Console.SetCursorPosition(fromLeft, fromTop + maxRows + 2);
            Console.Write('└' + new String('─', width + 2) + '┘');

        }


        public static void DrawRestaurant()
        {
            Console.CursorVisible = false;

            string[] table = new string[4];
            table[0] = "          ";
            table[1] = "          ";
            table[2] = "          ";
            table[3] = "          ";


            string[] resturangList = new string[43];
            for (int i = 0; i < resturangList.Length; i++)
            {
                resturangList[i] = "                                                            ";

            }            
            string[] waitingGuests = new string[10];
            for (int i = 0; i < waitingGuests.Length; i++)
            {
                waitingGuests[i] = "                    ";
            }

            string[] events = new string[31];
            for (int i = 0; i < events.Length; i++)
            {
                events[i] = "                    ";
            }

            string[] kitchen = new string[2];
            kitchen[0] = "          ";
            kitchen[1] = "          ";

            string[] door = new string[2];
            door[0] = "          ";
            door[1] = "          ";

            string[] sink = new string[2];
            sink[0] = "          ";
            sink[1] = "          ";



            Window.Draw("Resturang", 1, 1, resturangList);
            Window.Draw("Kitchen", 25, 2, kitchen);
            Window.Draw("Door", 47, 2, door);
            Window.Draw("Sink", 5, 2, sink);

            Window.Draw("Table 1 ", 5, 10, table);
            Window.Draw("Table 2 ", 5, 17, table);
            Window.Draw("Table 3 ", 5, 24, table);
            Window.Draw("Table 4 ", 5, 31, table);
            Window.Draw("Table 5 ", 5, 38, table);

            Window.Draw("Table 6 ", 45, 10, table);
            Window.Draw("Table 7 ", 45, 17, table);
            Window.Draw("Table 8 ", 45, 24, table);
            Window.Draw("Table 9 ", 45, 31, table);
            Window.Draw("Table 10", 45, 38, table);

            Window.Draw("Guests waiting", 66, 1, waitingGuests);
            Window.Draw("Events", 66, 13, events);




        }
    }

}
