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
            return new Merchandise(barCode, price, volume);
        }

        private double RandomVolume()   
        {
            double maximum = 0.20;
            double minimum = 0.03;
            return Random(minimum, maximum);
        }

        private double RandomPrice()
        {
            double maximum = 18.50;
            double minimum = 8.50;
            return Random(minimum, maximum);
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

        public List<Merchandise> Get ()
        {
            return merchandises;
        }

    }
}
