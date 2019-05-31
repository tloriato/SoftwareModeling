using System.Threading;

namespace ModelagemSoftware
{
    public class Merchandise
    {
        static int counter = 0;

        private int id;
        private string barCode;
        private double price;
        private double volume;
        private double weight;
        private Category category;

        public Merchandise(string barCode, double price, double volume, double weight, Category category)
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
        public double Volume { get => volume; set => volume = value; }
        public double Price { get => price; set => price = value; }
        public string BarCode { get => barCode; set => barCode = value; }
        public int Id { get => id; set => id = value; }
        public double Weight { get => weight; set => weight = value; }
    }
}