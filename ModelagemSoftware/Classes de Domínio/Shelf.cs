using System;
using System.Threading;

namespace ModelagemSoftware
{
    [Serializable()]
    public class Shelf
    {
        static int counter = 0;

        private int id;
        private Position[][] positions; // Passar para [][]
        private int amountStored;

        public int Id { get => id; set => id = value; }
        public Position[][] Positions { get => positions; set => positions = value; }
        public int AmountStored { get => amountStored; set => amountStored = value; }

        public Shelf()
        {

        }

        public Shelf(int size)
        {
            this.Id = Shelf.counter;

            Interlocked.Increment(ref counter);

            Positions = new Position[size][];

            for (int i = 0; i < size; i++)
            {
                Positions[i] = new Position[size];

                for (int j = 0; j < size; j++)
                {
                    Positions[i][j] = new Position(8, 8);
                }

            }
        }

        ~Shelf()
        {
            Interlocked.Decrement(ref counter);
        }

        internal Boolean CanItStore(ItemLot itemLot)
        {
            foreach(Position[] line in Positions)
            {
                foreach(Position position in line)
                {
                    if (position.CanItStore(itemLot))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal Position StoreItem(ItemLot itemLot)
        {
            return null;
        }

        internal Position ReservePosition(ItemLot itemLot)
        {
            foreach (Position[] line in Positions)
            {
                foreach (Position position in line)
                {
                    if (position.CanItStore(itemLot))
                    {
                        position.ReserveSpace(itemLot);
                        return position;
                    }
                }
            }

            return null;
        }
    }
}