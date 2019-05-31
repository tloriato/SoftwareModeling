using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ModelagemSoftware
{
    public class Order
    {
        static int counter = 0;

        private int id;
        public Worker responsable;
        public Status status;
        public string resolution;
        public Instruction[] intructions;

        public int Id { get => id; set => id = value; }

        public Order(Instruction[] instructions, Worker worker)
        {
            this.Id = Order.counter;
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
