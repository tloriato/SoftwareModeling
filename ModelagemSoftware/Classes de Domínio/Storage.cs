using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ModelagemSoftware
{
    public class Storage
    {
        static int counter = 0;

        public int id;
        public Shelf[][] shelves;

        public List<ItemLot> pendingItems;
        public Order storageOrders;

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

        internal void PrintPending()
        {
            foreach(ItemLot item in pendingItems)
            {
               item.Print();
            }
        }
    }
}
