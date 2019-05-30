using System;
using System.Threading;

namespace ModelagemSoftware
{
    public class ItemLot
    {
        static int counter = 0;

        public int id;
        public int quantity;
        public Merchandise merchandise;
        public Status status;
        public Order processedBy;

        public ItemLot(Merchandise merchandise, int quantity)
        {
            this.id = ItemLot.counter;
            this.quantity = quantity;
            this.merchandise = merchandise;
            Interlocked.Increment(ref counter);
        }

        ~ItemLot()
        {
            Interlocked.Decrement(ref counter);
        }

        internal void Print()
        {
            Console.WriteLine($"id: {this.id} | codBarra: {this.merchandise.barCode} | quantidade: {this.quantity}");
        }
    }
}