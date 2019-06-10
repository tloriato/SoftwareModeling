using System;
using System.Threading;

namespace ModelagemSoftware
{
    [Serializable()]
    public class Merchandise
    {
        static int counter = 0;

        private int id;
        private string barCode;
        private decimal price;
        private decimal volume;
        private decimal weight;
        private Category category;

        public Merchandise()
        {

        }

        public Merchandise(string barCode, decimal price, decimal volume, decimal weight, Category category)
        {
            this.Id = Merchandise.counter;
            this.BarCode = barCode;
            this.Price = price;
            this.Volume = volume;
            this.Category = category;
            this.Weight = weight;
            Interlocked.Increment(ref counter);
        }

        ~Merchandise()
        {
            Interlocked.Decrement(ref counter);
        }

        public Category Category { get => category; set => category = value; }
        public decimal Volume { get => volume; set => volume = value; }
        public decimal Price { get => price; set => price = value; }
        public string BarCode { get => barCode; set => barCode = value; }
        public int Id { get => id; set => id = value; }
        public decimal Weight { get => weight; set => weight = value; }
    }
}