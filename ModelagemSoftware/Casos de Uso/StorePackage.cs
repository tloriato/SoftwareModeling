using ModelagemSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TableParser;

namespace ModelagemSoftware.CasosdeUso
{
    class StorePackage
    {
        public StorePackage(Storage storage, Worker worker)
        {
            Console.Clear();


            Line("=========== Store Packages Procedure ============");
            Console.WriteLine();

            Line("================ Pending Items: =================");
            Console.WriteLine();

            storage.PrintPending();

            Line("===== Type IDs of items to Store or E(xit): =====");
            Console.Write("== IDs to Store: ");
            string input = Console.ReadLine();
            Line();

            if (input.ToUpper() == "E")
            {
                return;
            }

            Console.WriteLine();

            if(input.Split(',').Length == 0)
            {
                Console.WriteLine($"================ Ordem Vazia ===================");
                return;

            }

            Line("======== Creating order with these items: =======");

            Console.WriteLine();

            List<ItemLot> items = new List<ItemLot>();

            foreach (string itemS in input.Split(','))
            {
                try
                {
                    int id = Convert.ToInt32(itemS);
                    ItemLot item = storage.ItemById(id);
                    items.Add(item);
                }
                catch 
                {
                    Console.WriteLine($"========= {itemS} não é um ID válido ===========");
                    return;
                }
            }

            var table = items.ToStringTable
                    (
                        new[] { "ItemLot ID", "Cod. Barras", "Quantidade", "Categoria" },
                        u => u.Id,
                        u => u.Merchandise.BarCode,
                        u => u.Quantity,
                        u => u.Category.Name
                    );

            Console.WriteLine(table);

            Line("====== Press C to Confirm or other to Abort =====");

            string confirmation = Console.ReadLine();

            if (confirmation.ToUpper() == "C")
            {
                string[] charIds = input.Split(',');
                int[] ids = new int[charIds.Length];

                for(int i = 0; i < ids.Length; i++)
                {
                    ids[i] = Convert.ToInt32(charIds[i]);
                }

                Order order = storage.CreateStorageOrder(ids, worker);

                if (order == null)
                {
                    Line("=========== NÃO FOI POSSÍVEL ARMAZENAR ==========");
                }

                else
                {
                    Line($"=========== Instruções p/ Ordem {order.Id} ===============");
                    Console.WriteLine();
                    order.WriteInstructionsToConsole();
                }

                // Save State
                JSON.WriteToJsonFile("../../../data.json", storage);
            }

            else
            {
                Line("=============== Operation Aborted ===============");
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
