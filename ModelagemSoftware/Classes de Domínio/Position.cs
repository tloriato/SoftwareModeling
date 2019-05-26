using System.Threading;

namespace ModelagemSoftware
{
    public class Position
    {
        static int counter = 0;

        public int id;
        public float maxWeight;
        public Category category;
        public ItemLot[] storedItems;
        public float maxVolume;
        public float storingVolume;

        public Position()
        {
            Interlocked.Increment(ref counter);

        }

        ~Position()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}