using System;
using System.Threading;

namespace ModelagemSoftware
{
    public class Shelf
    {
        static int counter = 0;

        private int id;
        public Position[][] positions; // Passar para [][]
        public int amountStored;

        public int Id { get => id; set => id = value; }

        public Shelf(int size)
        {
            this.Id = Shelf.counter;

            Interlocked.Increment(ref counter);

            positions = new Position[size][];

            for (int i = 0; i < size; i++)
            {
                positions[i] = new Position[size];

                for (int j = 0; j < size; j++)
                {
                    positions[i][j] = new Position(5, 0.5);
                }

            }
        }

        ~Shelf()
        {
            Interlocked.Decrement(ref counter);
        }

        internal Position CanItStore(ItemLot itemLot)
        {
            foreach(Position[] line in positions)
            {
                foreach(Position position in line)
                {
                    if (position.CanItStore(itemLot))
                    {
                        return position;
                    }
                }
            }

            return null;
        }

        internal Position StoreItem(ItemLot itemLot)
        {
            foreach (Position[] line in positions)
            {
                foreach (Position position in line)
                {
                    if (position.CanItStore(itemLot))
                    {
                        position.StoredItem(itemLot);
                        return position;
                    }
                }
            }
            return null;
        }
    }
}