﻿using System;
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
            //GUI.GUI gui = new GUI.GUI();
            //gui.StartResturant();
            GenerateObjects.CreateObjects();
            Company company = new Company();
            Company.CreateCompany();

            Console.WriteLine(Company._companies[0][0].Name);
                       
            
            


        }
    }
}