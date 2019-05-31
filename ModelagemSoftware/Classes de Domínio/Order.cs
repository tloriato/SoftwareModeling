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
        public Instructions[] intructions;

        public Order(Instructions[] instructions, Worker worker)
        {
            this.id = Order.counter;
            Interlocked.Increment(ref counter);
            this.intructions = instructions;
            this.responsable = worker;
            this.status = Status.Storing;
        }

        ~Order()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}
