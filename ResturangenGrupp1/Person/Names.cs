using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturangenGrupp1.Person
{
    internal class Names
    {
        public static string NameGenerator(int stop)
        {
            string[] names = {"Blum", "Bloom", "Stamp", "Yves", "Bly", "Rangu", "Frid", "Isak", "Kim", "Moyo", "Ali", "Löfven", "Zeon",
                "Stark", "Soldat", "Ahlm", "Trump", "Gran", "Wang", "Karlsson", "Fridolin",  "Eriksson", "Ibrahimovic", "Forsberg", "Pettersson",
                "Olsson", "Mosby", "Simpson", "Griffin", "Baggins", "Johanson",  "Granath", "Grumpycat", "Karen", "C/o Segemyr",
                "Glans", "Gustafsson", "Tengil", "Lönngren", "Berggren", "Josefsson", "Tollmar", "Aadelen", "Stranden", "Stancic", "Stainaté",
                "Stamström", "Stömberg",  "Stampe", "Stammis", "Stalebäck", "Rasulzada", "Rastgar",  "Rangenstål", "Larsson", "Svensson",
                "Rangbo", "Ranemyr", "Ranebo", "Nelleros", "Nellhans", "Nelbäck", "Nekmal", "Nejadi", "Nesse", "Nedrup", "Nedbal", "Nattsjö",
                "Nathaniel", "Nastrovji", "Andersson", "Gardell", "Bernadotte",  "Grenqvist", "Krön", "Stålberg", "Danielsson", "Ekberg",
                "Fridolin", "Hökqvist", "Ivarsson", "Jansson", "Knutsdottrí", "Lavin", "Mjolnir", "Nedved", "Oscarsdottrí", "Pistvakt",
                "Qrench",  "Xerxes",  "Ålström", "Ängmark", "Östman",  "Smith", "Devi", "Ivanov", "García", "Müller",
                "Da Silva", "Mohamed", "Tesfaye", "Nguyen", "Ilunga", "González", "Deng", "Rodríguez",  "Hansen", "Ardensten", "Alzuabi"};

            Random rnd = new Random();
            int randomName = rnd.Next(0, stop);
            return names[randomName];
        }
    }
}
