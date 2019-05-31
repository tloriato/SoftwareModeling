using System;
using System.Collections.Generic;
using System.Text;

namespace ModelagemSoftware.Casos_de_Uso
{
    class StorePackage
    {
        public StorePackage(Storage storage, Worker worker)
        {
            Console.Clear();

            Line("================ Pending Items: =================");
            Console.WriteLine();

            storage.PrintPending();

            Line("=== Type IDs of items to Store or E(xit): ===");

            string input = Console.ReadLine();


            if (input.ToUpper() == "E")
            {
                return;
            }

            Line("====== Creating order with these items: ======");

            foreach (string itemS in input.Split(','))
            {
                try
                {
                    int id = Convert.ToInt32(itemS);
                    ItemLot item = storage.ItemById(id);
                    item.Print();
                }
                catch 
                {
                    Console.WriteLine($"{itemS} não é um ID válido.");
                    return;
                }
            }

            Line("====== Press C to Confirm or other to Abort ======");

            string confirmation = Console.ReadLine();

            if (confirmation.ToUpper() == "C")
            {
                Console.WriteLine("AASDASDASDAS");

                string[] charIds = input.Split(',');
                int[] ids = new int[charIds.Length];

                for(int i = 0; i < ids.Length; i++)
                {
                    ids[i] = Convert.ToInt32(charIds[i]);
                }

                try
                {
                    Console.WriteLine("Tentando isso aqui...");
                    Order order = storage.CreateStorageOrder(ids, worker);
                }
                catch (Exception e)
                {
                    // not working right now
                }

            }

            else
            {
                Line("====== Operation Aborted ======");
                return;

            }
        }

        private void Line(string line)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine(line);
            Console.WriteLine("=================================================");
        }

        private void Line()
        {
            Console.WriteLine("=================================================");
        }

    }
}

/*
    1. Worker requests from the System list of pending items to be stored.
    2. System displays all items pending storage.
    3. Worker identifies which item(s) he would like to store at that moment.
    4. System verifies that some item(s) was/were selected and ask user to confirm.
    5. Worker confirms the creation of a storage order.
    6. System reports to user the location(s) where each item should be stored into the facility.
 */
