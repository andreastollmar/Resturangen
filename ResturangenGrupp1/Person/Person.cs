using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.GUI;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.Restaurant;

namespace ResturangenGrupp1.Person
{
    internal class Person
    {
        internal string Name { get; set; }
        internal int Competence { get; set; }
        internal int TimeActivity { get; set; }

        private protected int RandomCompetence()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }

        public Person()
        {
            Name = "";
            TimeActivity = 0;
            Competence = 0;
        }
    }

    internal class Guest : Person
    {
        // Properties
        internal int Satisfaction { get; set; }
        internal int Cash { get; set; }
        internal bool AtTable { get; set; }
        internal List<Food> preferedFood = new List<Food>();
        internal bool NutAllergy { get; set; }
        internal bool LactoseAllergy { get; set; }
        internal bool GlutenAllergy { get; set; }

        // Methods
        private int RandomCash()
        {
            Random random = new Random();
            int cash = random.Next(100, 500);
            return cash;
        }
        private void Eating()
        {
            for (int i = TimeActivity; i < 1; i--)
            {
                AtTable = true;
            }
        }
        
        public void ShowFood(Guest guest)
        {
            Console.WriteLine(guest.preferedFood[0].Name);
        }

        // Constructor
        public Guest(): base()
        {            
            Name = Names.NameGenerator();
            TimeActivity = 20;
            Cash = RandomCash();
            NutAllergy = Allergies.IsAllergic();
            LactoseAllergy = Allergies.IsAllergic();
            GlutenAllergy = Allergies.IsAllergic();
        }
    }

    internal class Waiter : Person
    {
        // Properties
        private bool Busy { get; set; }
        public List<string> Order { get; set; }

        // Methods
        private void Cleaning()
        {
            for (int i = TimeActivity; i < 1; i--)
            {
                Busy = true;
            }
            Busy = false;
        }

        // Constructor
        public Waiter(): base()
        {
            Name = Names.NameGenerator();
            TimeActivity = 3;
            Busy = false;
            Competence = RandomCompetence();
            //Order = ; Hämta lista från bordet och ta till köket. Ta lista från köket till bordet
        }

    }

    internal class Chef : Person
    {
        // Properties
        private bool Busy { get; set; }

        // Methods
        private void Cooking()
        {
            for (int i = TimeActivity; i < 1; i--)
            {
                Busy = true;
            }
            Busy = false;
        }
        
        // Constructor
        public Chef(): base()
        {
            Name = Names.NameGenerator();
            TimeActivity = 10;
            Busy = false;
            Competence = RandomCompetence();
        }
    }

}