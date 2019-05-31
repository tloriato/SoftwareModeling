using System;
using System.Collections.Generic;
using System.Threading;

namespace ModelagemSoftware
{
    public class Position
    {
        static int counter = 0;

        private int id;

        private double maxWeight; // in KG
        private double maxVolume; // in m3

        private double storingVolume = 0;
        private double storingWeight = 0;
        private Category category;
        private List<ItemLot> storedItems = new List<ItemLot>();

        public double MaxWeight { get => maxWeight; set => maxWeight = value; }
        public double MaxVolume { get => maxVolume; set => maxVolume = value; }
        public double StoringVolume { get => storingVolume; set => storingVolume = value; }
        public Category Category { get => category; set => category = value; }
        public double StoringWeight { get => storingWeight; set => storingWeight = value; }
        public int Id { get => id; set => id = value; }

        public Position(double maxWeight, double maxVolume)
        {
            this.Id = Position.counter;

            Interlocked.Increment(ref counter);

            this.MaxVolume = maxVolume;
            this.MaxWeight = maxWeight;
            this.Category = null;
        }

        ~Position()
        {
            Interlocked.Decrement(ref counter);
        }

        internal bool CanItStore(ItemLot itemLot)
        {
            if (this.Category != itemLot.Category && this.Category != null)
            {
                return false;
            }
            else if (itemLot.Volume() + this.StoringVolume > this.MaxVolume)
            {
                return false;
            }
            else if (itemLot.Weight() + this.StoringWeight > this.MaxWeight)
            {
                return false;
            }
            return true;
        }

        internal bool StoredItem(ItemLot itemLot)
        {
            if (CanItStore(itemLot))
            {
                storedItems.Add(itemLot);
                this.StoringVolume += itemLot.Volume();
                this.StoringWeight += itemLot.Weight();
                return true;
            }
            return false;
        }
    }
}