using System.Threading;

namespace ModelagemSoftware
{
    public class Merchandise
    {
        static int counter = 0;

        public int id;
        public string barCode;
        public float price;
        public float volume;

        public Merchandise()
        {
            Interlocked.Increment(ref counter);

        }

        ~Merchandise()
        {
            Interlocked.Decrement(ref counter);
        }

    }
}