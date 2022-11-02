using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Restaurant;
using ResturangenGrupp1.Person;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.GUI;


namespace ResturangenGrupp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GUI.GUI gui = new GUI.GUI();
            //gui.StartResturant();
            GenerateObjects.CreateObjects();
            ////Company company = new Company();
            Company.CreateCompany();


            //for (int i = 0; i < Company._companies[0].Count; i++)
            //{
            //    GenerateObjects._tables[0].TableSize[i] = Company._companies[0][i];
            //}
            //GenerateObjects._tables[0].TransferNames(GenerateObjects._tables[0].TableSize);


            // Console.WriteLine(GenerateObjects._tables[0].TableNames[0]);
            //Console.WriteLine();
            //GUI.Window.Draw("Table 1", 2, 20, GenerateObjects._tables[0].TableNames);

            //gui.StartResturant();
            //GUI.Window.DrawRestaurant();



            //Console.WriteLine();
            //GUI.Window.Draw("Table 1", 2, 20, GenerateObjects._tables[0].TableNames);


            while (true)
            {
                GUI.Window.DrawRestaurant();
                GenerateObjects._waiters[0].GoToTheDoor(GenerateObjects._waiters[0]);
                Company._
                
                Console.ReadKey();
            }
       

        }
    }
}