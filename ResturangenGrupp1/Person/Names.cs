using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturangenGrupp1.Person
{
    internal class Names
    {


        public static string NameGenerator()
        {
            string[] names = {"Andersson", "Larsson", "Svensson", "Pettersson",
                "Stark", "Soldat", "Bernadotte", "Trump", "Karlsson", "Fridolin", "Löfven", "Eriksson", "Isak", "Ibrahimovic", "Forsberg",
                "Olsson", "Mosby", "Simpson", "Griffin", "Baggins", "Johanson", "Frid", "Granath", "Grumpycat", "Karen", "C/o Segemyr",
                "Glans", "Gustafsson", "Tengil", "Lönngren", "Berggren", "Josefsson", "Tollmar", "Aadelen", "Stranden", "Stancic", "Stainaté",
                "Stamström", "Stömberg", "Stamp", "Stampe", "Stammis", "Stalebäck", "Rasulzada", "Rastgar", "Putin", "Rangu", "Rangenstål",
                "Rangbo", "Ranemyr", "Ranebo", "Nelleros", "Nellhans", "Nelbäck", "Nekmal", "Nejadi", "Nesse", "Nedrup", "Nedbal", "Nattsjö",
                "Nathaniel", "Nastrovji", "Bly", "Blum", "Bloom", "Gardell", "Ahlm", "Grenqvist", "Krön", "Stålberg", "Danielsson", "Ekberg",
                "Fridolin", "Gran", "Hökqvist", "Ivarsson", "Jansson", "Knutsdottrí", "Lavin", "Mjolnir", "Nedved", "Oscarsdottrí", "Pistvakt",
                "Qrench", "Zeon", "Xerxes", "Yves", "Ålström", "Ängmark", "Östman", "Wang", "Smith", "Devi", "Ivanov", "Kim", "Ali", "García", "Müller",
                "Da Silva", "Mohamed", "Tesfaye", "Nguyen", "Ilunga", "González", "Deng", "Rodríguez", "Moyo", "Hansen", "Ardensten", "Alzuabi"};

            Random rnd = new Random();
            int randomName = rnd.Next(0, names.Length);
            return names[randomName];
        }


    }
}
