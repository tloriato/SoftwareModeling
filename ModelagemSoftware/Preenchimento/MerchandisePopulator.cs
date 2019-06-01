using System;
using System.Collections.Generic;

namespace ModelagemSoftware.Preenchimento
{
    public class MerchandisePopulator
    {
        protected List<Merchandise> merchandises;
        protected List<Category> parentCategories;
        protected List<Category> childCategories;

        public MerchandisePopulator(int amount)
        {
            parentCategories = new List<Category>();
            childCategories = new List<Category>();

            parentCategories.Add(new Category("Pai 1"));
            parentCategories.Add(new Category("Pai 2"));
            parentCategories.Add(new Category("Pai 3"));
            childCategories.Add(new Category("Filho do Pai 2 #1", parentCategories[1].Id));

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
            return Random(0.1, 0.3);
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
            Random random = new Random();
            if (random.Next(0, 10) % 2 == 0)
            {
                if (random.Next(0, 10) % 2 == 0)
                {
                    Category parent = parentCategories[random.Next(0, 3)];
                    string name = $"Filho do {parent.Name} #{childCategories.Count}";

                    Category child = new Category(name, parent.Id);
                    childCategories.Add(child);
                }

                return childCategories[random.Next(0, childCategories.Count)];

            }

            return parentCategories[random.Next(0, 3)];
        }

        public List<Merchandise> Get ()
        {
            return merchandises;
        }

    }
}
