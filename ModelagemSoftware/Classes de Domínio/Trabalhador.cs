using System;
using System.Threading;

namespace ModelagemSoftware
{
    [Serializable()]
    public class Worker
    {
        static int counter = 0;

        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Worker()
        {

        }

        public Worker(string name)
        {
            Interlocked.Increment(ref counter);
            this.Name = name;
        }

        ~Worker()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}