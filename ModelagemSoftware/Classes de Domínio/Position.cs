using System.Threading;

namespace ModelagemSoftware
{
    public class Position
    {
        static int counter = 0;

        public int id;

        public double maxWeight; // in KG
        public double maxVolume; // in m3

        public double storingVolume;
        public Category category;
        public ItemLot[] storedItems;

        public Position(double maxWeight, double maxVolume)
        {
            Interlocked.Increment(ref counter);

            this.maxVolume = maxVolume;
            this.maxWeight = maxWeight;
        }

        ~Position()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}