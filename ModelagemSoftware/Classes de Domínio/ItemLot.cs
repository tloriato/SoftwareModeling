using System.Threading;

namespace ModelagemSoftware
{
    public class ItemLot
    {
        static int counter = 0;

        public int id;
        public int quantity;
        public Merchandise merchandise;
        public Status status;
        public Order processedBy;

        public ItemLot()
        {
            Interlocked.Increment(ref counter);

        }

        ~ItemLot()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}