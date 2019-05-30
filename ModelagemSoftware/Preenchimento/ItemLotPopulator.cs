using System;
using System.Collections.Generic;

namespace ModelagemSoftware.Preenchimento
{
    public class ItemLotPopulator
    {
        protected List<ItemLot> itemLots;

        public ItemLotPopulator(List<Merchandise> merchandises)
        {
            itemLots = new List<ItemLot>();

            foreach(Merchandise merchadise in merchandises)
            {
                ItemLot lot = GenerateRandomLot(merchadise);
                itemLots.Add(lot);
            }
        }

        public List<ItemLot> Get ()
        {
            return itemLots;
        }

        private ItemLot GenerateRandomLot(Merchandise merchadise)
        {
            Random random = new Random();
            int quantity = random.Next(2, 8);
            return new ItemLot(merchadise, quantity);
        }
    }
}
