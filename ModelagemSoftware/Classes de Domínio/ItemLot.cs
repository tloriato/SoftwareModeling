using System;
using System.Threading;

namespace ModelagemSoftware
{
    [Serializable()]
    public class ItemLot
    {
        static int counter = 0;

        private int id;
        private int quantity;
        private Merchandise merchandise;
        private Status status;
        private Order processedBy;
        private Category category;

        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public Merchandise Merchandise { get => merchandise; set => merchandise = value; }
        public Status Status { get => status; set => status = value; }
        public Order ProcessedBy { get => processedBy; set => processedBy = value; }
        public Category Category { get => category; set => category = value; }

        public ItemLot()
        {

        }
        public ItemLot(Merchandise merchandise, int quantity)
        {
            this.Id = ItemLot.counter;
            Interlocked.Increment(ref counter);
            this.Quantity = quantity;
            this.Merchandise = merchandise;
            this.Category = merchandise.Category;
            this.Status = Status.Pending;
        }

        ~ItemLot()
        {
            Interlocked.Decrement(ref counter);
        }

        internal void Print()
        {
            Console.WriteLine($"id: {this.Id} | codBarra: {this.Merchandise.BarCode} | quantidade: {this.Quantity} | categoria: {this.Merchandise.Category.Name}");
        }

        public decimal Volume()
        {
            return (decimal)(this.Quantity * Merchandise.Volume);
        }

        public decimal Weight()
        {
            return (decimal)(this.Quantity * Merchandise.Weight);
        }

    }
}