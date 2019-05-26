using System.Threading;

namespace ModelagemSoftware
{
    public class Shelf
    {
        static int counter = 0;

        public int id;
        public Position[] positions;
        public int amountStored;

        public Shelf()
        {
            Interlocked.Increment(ref counter);

        }

        ~Shelf()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}