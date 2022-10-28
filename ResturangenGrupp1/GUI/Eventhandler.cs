﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.Person;
using ResturangenGrupp1.Restaurant;

namespace ResturangenGrupp1.GUI
{
    internal class Eventhandler
    {
        static List<string> _events = new List<string>(); 
        //Metoder med listor där vi visar x - mycket data i GUI:n
        public void ShowEvents()
        {
            for (int i = _events.Count; i >= 0; i--)
            {
                if (i > 5)
                {
                    _events.RemoveAt(0);
                    Console.WriteLine(_events[i]);
                }
                else
                {
                    Console.WriteLine(_events[i]);
                }
            }
        }

        public void AddEvent(Guest guest, string happening)
        {
            //Lista med company för att få ut maträtter? Foorloopa etc?
            string events = guest.Name + " har " + happening;
            _events.Add(events);
        }
        public void ShowGuestList()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(GenerateObjects._guests[i].Name);
                //Console.Write(" + " GenerateObjects._guests[i].);
            }
        }
    }
}
