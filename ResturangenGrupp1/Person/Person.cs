using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturangenGrupp1.Person
{
    internal class Person
    {
        internal string Name { get; set; }
        internal int Competence { get; set; }
        internal int TimeActivity { get; set; }

        public int RandomCompetence()
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
        private int Satisfaction { get; set; }
        private bool Eating { get; set; }

        private bool NutAllergy { get; set; }
        private bool LactoseAllergy { get; set; }
        private bool GlutenAllergy { get; set; }

        private void AtTable()
        {

        }

        public Guest(): base()
        {
            Name = Names.NameGenerator();
            TimeActivity = 20;
            NutAllergy = Allergies.IsAllergic();
            LactoseAllergy = Allergies.IsAllergic();
            GlutenAllergy = Allergies.IsAllergic();
        }
    }

    internal class Waiter : Person
    {
        private bool Busy { get; set; }

        private void Cleaning()
        {

        }

        public Waiter(): base()
        {
            Name = Names.NameGenerator();
            TimeActivity = 3;
            Busy = false;
            Competence = RandomCompetence();
        }

    }

    internal class Chef : Person
    {
        private bool Busy { get; set; }

        private void Cooking()
        {

        }

        public Chef(): base()
        {
            Name = Names.NameGenerator();
            TimeActivity = 10;
            Busy = false;
            Competence = RandomCompetence();
        }
    }

}