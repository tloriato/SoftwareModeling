using System;
using System.Collections.Generic;
using System.Threading;

namespace ModelagemSoftware
{
    [Serializable()]
    public class Category
    {
        static int counter = 0;

        private int id;
        private string name;
        private Category parent;

        private static List<WeakReference> instances = new List<WeakReference>();

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public Category Parent { get => parent; set => parent = value; }

        public Category()
        {

        }

        public Category(string name)
        {
            this.Id = Category.counter;
            Interlocked.Increment(ref counter);
            this.Name = name;
            this.Parent = null;
            instances.Add(new WeakReference(this));
        }

        // nome e id da categoria pai
        public Category(string name, int category)
        {
            this.Id = Category.counter;
            this.Name = name;

            Category parent = null;

            foreach (Category c in Category.GetInstances())
            {
                if (c.Id == category)
                {
                    parent = c;
                    break;
                }

            }

            this.Parent = parent;
            instances.Add(new WeakReference(this));
        }

        public static IList<Category> GetInstances()
        {
            List<Category> realInstances = new List<Category>();
            List<WeakReference> toDelete = new List<WeakReference>();

            foreach (WeakReference reference in instances)
            {
                if (reference.IsAlive)
                {
                    realInstances.Add((Category)reference.Target);
                }
                else
                {
                    toDelete.Add(reference);
                }
            }

            foreach (WeakReference reference in toDelete) instances.Remove(reference);

            return realInstances;
        }
    }
}