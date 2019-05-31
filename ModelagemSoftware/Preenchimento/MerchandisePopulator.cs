using System;
using System.Collections.Generic;

namespace ModelagemSoftware.Preenchimento
{
    public class MerchandisePopulator
    {
        protected List<Merchandise> merchandises;

        public MerchandisePopulator(int amount)
        {
            merchandises = new List<Merchandise>();
            for(int i  = 0; i < amount; i++)
            {
                Merchandise merchandise = GenerateMerchandise();
                this.merchandises.Add(merchandise);
            }
        }

        protected Merchandise GenerateMerchandise()
        {
            string barCode = RandomCode();
            double price = RandomPrice();
            double volume = RandomVolume();
            double weight = RandomWeight();
            Category category = RandomCategory();
            return new Merchandise(barCode, price, volume, weight, category);
        }

        private double RandomWeight()
        {
            return Random(0.1, 2.0);
        }

        private double RandomVolume()   
        {
            return Random(0.03, 0.20);
        }

        private double RandomPrice()
        {
            return Random(8.50, 18.50);
        }

        private String RandomCode() 
        {
            Random random = new Random();
            DateTime now = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)now).ToUnixTimeSeconds();

            return random.Next(0, (int)unixTime).ToString();
        }

        private double Random(double min, double max)
        {
            Random random = new Random();
            return (double)Math.Truncate((random.NextDouble() * (max - min) + min) * 100) / 100;
        }

        private Category RandomCategory()
        {
            return new Category("Exemplo");
        }

        public List<Merchandise> Get ()
        {
            return merchandises;
        }

    }
}
