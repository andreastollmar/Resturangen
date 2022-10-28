﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturangenGrupp1.Person;
using ResturangenGrupp1.Kitchen;
using ResturangenGrupp1.GUI;

namespace ResturangenGrupp1.Restaurant
{
    internal class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public void AddFoodToGuest(Guest guest)
        {
            Random rnd = new Random();
            bool tryAgain = true;
            while (tryAgain)
            {
                int randomDish = rnd.Next(1, 10);

                switch (randomDish)
                {
                    case 1:
                        Meat.Beef meat = new Meat.Beef();
                        if (guest.NutAllergy)
                        {
                            break;
                        }
                        else
                        {
                            guest.preferedFood.Add(meat);
                            tryAgain = false;
                            break;
                        }
                    case 2:
                        Fish.Scallop scallop = new Fish.Scallop();
                        guest.preferedFood.Add(scallop);
                        tryAgain = false;
                        break;
                    case 3:
                        Vegetarian.Haloumi haloumi = new Vegetarian.Haloumi();
                        if (guest.LactoseAllergy)
                        {
                            break;
                        }
                        else
                        {
                            guest.preferedFood.Add(haloumi);
                            tryAgain = false;
                            break;
                        }
                    case 4:
                        Meat.Kebab kebab = new Meat.Kebab();
                        guest.preferedFood.Add(kebab);
                        tryAgain = false;
                        break;
                    case 5:
                        Fish.Tuna tuna = new Fish.Tuna();
                        guest.preferedFood.Add(tuna);
                        tryAgain = false;
                        break;
                    case 6:
                        Vegetarian.Falafel falafel = new Vegetarian.Falafel();
                        if (guest.GlutenAllergy)
                        {
                            break;
                        }
                        else
                        {
                            guest.preferedFood.Add(falafel);
                            tryAgain = false;
                            break;
                        }
                    case 7:
                        Meat.Steak steak = new Meat.Steak();
                        guest.preferedFood.Add(steak);
                        tryAgain = false;
                        break;
                    case 8:
                        Fish.Moules moules = new Fish.Moules();
                        guest.preferedFood.Add(moules);
                        tryAgain = false;
                        break;
                    case 9:
                        Vegetarian.Risotto risotto = new Vegetarian.Risotto();
                        guest.preferedFood.Add(risotto);
                        tryAgain = false;
                        break;
                }
            }
            


        }

        public Food()
        {

        }
    }

    class Fish : Food
    {
        internal class Tuna : Fish
        {
            public Tuna()
            {
                Name = "Tuna";
                Price = 110;            
            }
        }

        internal class Scallop : Fish
        {    
            public Scallop()
            {
                Name = "Scallop";
                Price = 99;               
            }
        }

        internal class Moules : Fish
        {       
             public Moules()
             {
                Name = "Moules";
                Price = 120;
             }
        }

    }

    class Meat : Food
    { 
        internal class Kebab : Meat
        {    
          public Kebab()
            {
                Name = "Kebab";
                Price = 110;
            }
        }

        internal class Steak : Meat
        {        
            public Steak()
            {
                Name = "Steak";
                Price = 160;
                
            }
        }

        internal class Beef : Meat
        {
            public Beef()
            {
                Name = "Beef";
                Price = 180;
            }
        }
    }

    class Vegetarian : Food
    {
        internal class Risotto : Vegetarian
        {  
            public Risotto()
            {
                Name = "Risotto";
                Price = 160;
            }
        }

        internal class Falafel : Vegetarian
        { 
            public Falafel()
            {
                Name = "Falafel";
                Price = 99;
            }
        }

        internal class Haloumi : Vegetarian
        {
            public Haloumi()
            {
                Name = "Haloumi";
                Price = 120;
            }
        }
    }
}
