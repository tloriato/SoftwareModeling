using System.Threading;

namespace ModelagemSoftware
{
    public class Worker
    {
        static int counter = 0;

        public int id;
        public string name;

        public Worker()
        {
            Interlocked.Increment(ref counter);

        }

        ~Worker()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}