using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TableParser;

namespace ModelagemSoftware
{
    public class Order
    {
        static int counter = 0;

        private int id;
        public Worker responsable;
        private Status status;
        public string resolution;
        public Instruction[] intructions;

        public int Id { get => id; set => id = value; }
        public Status Status { get => status; set => status = value; }

        public Order(Instruction[] instructions, Worker worker)
        {
            this.Id = Order.counter;
            Interlocked.Increment(ref counter);
            this.intructions = instructions;
            this.responsable = worker;
            this.Status = Status.Storing;
        }

        ~Order()
        {
            Interlocked.Decrement(ref counter);
        }

        public void WriteInstructionsToConsole()
        {
            List<Instruction> holder = new List<Instruction>();

            foreach (Instruction instruction in this.intructions)
            {
                holder.Add(instruction);
            }

            var table = holder.ToStringTable
                (
                    new[] { "LOT ID", "SHELF ID", "POSITION ID", "CURRENT STATUS" },
                    u => u.Lot.Id,
                    u => u.Shelf.Id,
                    u => u.Position.Id,
                    u => u.Status
                );

            Console.WriteLine(table);
        }

    }
}
