using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ModelagemSoftware
{
    public class Storage : Exception
    {
        static int counter = 0;

        public int id;
        public Shelf[][] shelves;

        public List<ItemLot> pendingItems;
        public List<Order> storageOrders = new List<Order>();

        public Storage(int lines, int columns)
        {
            this.id = Storage.counter;

            Interlocked.Increment(ref counter);

            shelves = new Shelf[lines][];

            for (int i = 0; i < lines; i++)
            {
                shelves[i] = new Shelf[columns];

                for (int j = 0; j < columns; j++)
                {
                    shelves[i][j] = new Shelf(3);
                }
            }

        }

        ~Storage()
        {
            Interlocked.Decrement(ref counter);
        }

        public Boolean InsertPendingItem(ItemLot item)
        {
            if (this.pendingItems == null)
            {
                this.pendingItems = new List<ItemLot>();
            }

            this.pendingItems.Add(item);

            return true;
        }

        public Boolean InsertPendingItems(List <ItemLot> items)
        {
            foreach(ItemLot item in items)
            {
                InsertPendingItem(item);
            }

            return true;
        }

        public ItemLot ItemById(int id)
        {
            ItemLot item = this.pendingItems.Find(x => x.Id == id);
            return item;
        }

        public Order CreateStorageOrder(int[] ids, Worker worker)
        {
            Instruction[] instructions = new Instruction[ids.Length];

            for (int i = 0; i < ids.Length; i++)
            {
                Instruction maybeInstruction = FindFreeSpaceForId(ItemById(ids[i]));

                if (maybeInstruction == null)
                {
                    return null;
                }

                else
                {
                    instructions[i] = maybeInstruction;
                }
            }

            this.storageOrders.Add(new Order(instructions, worker));

            return this.storageOrders[this.storageOrders.Count - 1];
        }

        private Instruction FindFreeSpaceForId(ItemLot itemLot)
        {
            foreach(Shelf[] line in shelves)
            {
                foreach(Shelf shelf in line)
                {
                    Position position = shelf.CanItStore(itemLot);

                    if (position != null)
                    {
                        Instruction instructions = new Instruction(itemLot, shelf, position);
                        return instructions;
                    }

                }
            }

            return null;
        }

        internal void PrintPending()
        {
            foreach(ItemLot item in pendingItems)
            {
               item.Print();
            }
        }
    }
}
