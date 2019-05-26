using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ModelagemSoftware
{
    public class Order
    {
        static int counter = 0;

        public int id;
        public Worker responsable;
        public Status status;
        public string resolution;
        public Intructions[] intructions;

        public Order()
        {
            Interlocked.Increment(ref counter);

        }

        ~Order()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}
