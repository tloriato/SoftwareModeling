using System;
using System.Threading;

namespace ModelagemSoftware
{
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

        public ItemLot(Merchandise merchandise, int quantity)
        {
            this.Id = ItemLot.counter;
            this.Quantity = quantity;
            this.Merchandise = merchandise;
            this.Category = merchandise.Category;
            Interlocked.Increment(ref counter);
        }

        ~ItemLot()
        {
            Interlocked.Decrement(ref counter);
        }

        internal void Print()
        {
            Console.WriteLine($"id: {this.Id} | codBarra: {this.Merchandise.BarCode} | quantidade: {this.Quantity} | categoria: {this.Merchandise.Category.Name}");
        }

        public double Volume()
        {
            return (double)(this.Quantity * Merchandise.Volume);
        }

        public double Weight()
        {
            return (double)(this.Quantity * Merchandise.Weight);
        }
    }
}