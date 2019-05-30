using System;
namespace ModelagemSoftware.Preenchimento
{
    public class Populator
    {
        public Populator()
        {
        }

        public void InsertPendingItems(Storage storage)
        {
            MerchandisePopulator merchandise = new MerchandisePopulator(10);
            ItemLotPopulator itemLots = new ItemLotPopulator(merchandise.Get());
            storage.InsertPendingItems(itemLots.Get());
        }
    }
}
