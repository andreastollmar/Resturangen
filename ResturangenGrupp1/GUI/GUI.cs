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
            while (true)
            {
                foreach (ITable tables in GenerateObjects._tables)
                {
                    switch (tables.TableNumber)
                    {
                        case 0:
                            if (tables.TableSize == null)
                            {
                                (tables.TableSize[0]).Name = "Empty";
                            }
                            else if (tables.TableSize[1] == null)
                            {
                                
                            }
                            tables.TableSize
                    }
                }
                for (int i = 0; i < GenerateObjects._waiters.Count; i++)
                {
                    if (!GenerateObjects._waiters[i].Busy)
                    {
                        for (int j = 0; j < GenerateObjects._tables.Count; j++)
                        {
                            if (GenerateObjects._tables[j].Empty)
                            {
                                if (GenerateObjects._tables[j] is TableForFour)
                                {
                                    GenerateObjects._tables[j].Empty = false;
                                    Random rnd = new Random();
                                    int companySize = rnd.Next(3, 5);
                                    //Gå till dörren writeout
                                    for (int k = 0; k < companySize; k++)
                                    {
                                        GenerateObjects._waiters[i].guests.Add(GenerateObjects._guests[k]);
                                        GenerateObjects._guests.RemoveAt(k);
                                    }
                                }
                                else if (GenerateObjects._tables[j] is TableForTwo)
                                {
                                    GenerateObjects._tables[j].Empty = false;
                                    Random rnd = new Random();
                                    int companySize = rnd.Next(1, 3);
                                    for (int k = 0; k < companySize; k++)
                                    {
                                        GenerateObjects._waiters[i].guests.Add(GenerateObjects._guests[k]);
                                        GenerateObjects._guests.RemoveAt(k);
                                    }
                                }
                                //gå till bord index[j] i _tables

                            }
                        }
                    }
                }
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
    }
    public static void DrawRestaurant()
    {
        Console.CursorVisible = false;

        //string[] table = new string[4];
        //table[0] = "          ";
        //table[1] = "          ";
        //table[2] = "          ";
        //table[3] = "          ";

        foreach (ITable table in GenerateObjects._tables)
        {

        }

        string[] resturangList = new string[50];

        for (int i = 0; i < resturangList.Length; i++)
        {
            resturangList[i] = "                                                                    ";

        }




        Window.Draw("Resturang", 1, 1, resturangList);

        Window.Draw("Table 1", 5, 2, table);
        Window.Draw("Table 2", 35, 2, table);
        Window.Draw("Table 3", 5, 10, table);
        Window.Draw("Table 4", 35, 10, table);
        Console.ReadKey();
    }
}
