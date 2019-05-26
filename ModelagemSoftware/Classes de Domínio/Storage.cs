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

        public Storage()
        {
            Interlocked.Increment(ref counter);

        }

        ~Storage()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}
