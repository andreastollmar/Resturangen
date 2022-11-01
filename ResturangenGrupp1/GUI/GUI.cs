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
}
