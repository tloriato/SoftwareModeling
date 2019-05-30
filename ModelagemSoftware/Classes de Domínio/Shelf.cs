using System.Threading;

namespace ModelagemSoftware
{
    public class Shelf
    {
        static int counter = 0;

        public int id;
        public Position[] positions;
        public int amountStored;

        public Shelf(int size)
        {
            Interlocked.Increment(ref counter);

            positions = new Position[size];

            for (int i = 0; i < size; i++)
            {
                positions[i] = new Position(5, 0.5);
            }
        }

        ~Shelf()
        {
            Interlocked.Decrement(ref counter);
        }
    }
}