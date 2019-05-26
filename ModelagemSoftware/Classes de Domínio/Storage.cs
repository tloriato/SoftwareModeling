using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ModelagemSoftware
{
    class Storage
    {
        static int counter = 0;

        public int id;
        public Shelf[][] shelves;
        public ItemLot pendingItems;
        public Order storageOrders;

        public Storage(int lines, int columns)
        {
            Interlocked.Increment(ref counter);
            
            for(int i = 0; i < lines; i++)
            {
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
    }
}
