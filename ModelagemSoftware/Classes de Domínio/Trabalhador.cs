using System.Threading;

namespace ModelagemSoftware
{
    public class Worker
    {
        static int counter = 0;

        public int id;
        public string name;

        public Worker(string name)
        {
            Interlocked.Increment(ref counter);
            this.name = name;
        }

        ~Worker()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}