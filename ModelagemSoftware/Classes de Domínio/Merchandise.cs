using System.Threading;

namespace ModelagemSoftware
{
    public class Merchandise
    {
        static int counter = 0;

        public int id;
        public string barCode;
        public double price;
        public double volume;

        public Merchandise(string barCode, double price, double volume)
        {
            this.id = Merchandise.counter;
            this.barCode = barCode;
            this.price = price;
            this.volume = volume;
            Interlocked.Increment(ref counter);
        }

        ~Merchandise()
        {
            Interlocked.Decrement(ref counter);
        }

    }
}