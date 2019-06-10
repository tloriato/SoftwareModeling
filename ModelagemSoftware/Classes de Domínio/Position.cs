using System;
using System.Collections.Generic;
using System.Threading;

namespace ModelagemSoftware
{
    [Serializable()]
    public class Position
    {
        static int counter = 0;

        private int id;

        private decimal maxWeight; // in KG
        private decimal maxVolume; // in m3

        private decimal reservedWeight = 0; // in KG
        private decimal reservedVolume = 0; // in m3

        private decimal storingVolume = 0;
        private decimal storingWeight = 0;

        private int categoryId;

        private List<ItemLot> storedItems = new List<ItemLot>();

        public decimal MaxWeight { get => maxWeight; set => maxWeight = value; }
        public decimal MaxVolume { get => maxVolume; set => maxVolume = value; }
        public decimal StoringVolume { get => storingVolume; set => storingVolume = value; }

        public decimal StoringWeight { get => storingWeight; set => storingWeight = value; }
        public int Id { get => id; set => id = value; }
        public decimal ReservedWeight { get => reservedWeight; set => reservedWeight = value; }
        public decimal ReservedVolume { get => reservedVolume; set => reservedVolume = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }

        public Position()
        {

        }

        public Position(decimal maxWeight, decimal maxVolume)
        {
            this.Id = Position.counter;

            Interlocked.Increment(ref counter);

            this.MaxVolume = maxVolume;
            this.MaxWeight = maxWeight;
            this.CategoryId = -1;
        }

        ~Position()
        {
            Interlocked.Decrement(ref counter);
        }

        internal bool CanItStore(ItemLot itemLot)
        {
            if (this.CategoryId != itemLot.Category.Id && this.CategoryId != -1)
            {
                return false;
            }
            else if (itemLot.Volume() + this.StoringVolume + this.ReservedVolume > this.MaxVolume)
            {
                return false;
            }
            else if (itemLot.Weight() + this.StoringWeight + this.ReservedWeight > this.MaxWeight)
            {
                return false;
            }
            return true;
        }

        internal bool StoreItem(ItemLot itemLot)
        {
            if (((this.reservedVolume - itemLot.Volume()) < 0) || ((this.reservedWeight - itemLot.Weight()) < 0))
            {
                return false;
            }

            if (itemLot.Category.Id != this.categoryId)
            {
                return false;
            }

            this.storedItems.Add(itemLot);
            this.ReservedVolume -= itemLot.Volume();
            this.ReservedWeight -= itemLot.Weight();
            this.StoringVolume += itemLot.Volume();
            this.StoringWeight += itemLot.Weight();

            return true;
        }

        internal bool ReserveSpace(ItemLot itemLot)
        {
            if (CanItStore(itemLot))
            {
                if (this.CategoryId == -1)
                {
                    this.CategoryId = itemLot.Category.Id;
                }

                this.reservedVolume += itemLot.Volume();
                this.reservedWeight += itemLot.Weight();

                return true;
            }

            return false;
        }
    }
}