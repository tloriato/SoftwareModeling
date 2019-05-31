using System;
using System.Collections.Generic;

namespace ModelagemSoftware
{
    public class Category
    {
        private string name;
        public Category parent;

        private static List<WeakReference> instances = new List<WeakReference>();

        public string Name { get => name; set => name = value; }

        public Category(string name)
        {
            this.Name = name;
            this.parent = null;
            instances.Add(new WeakReference(this));
        }

        public Category(string name, int category)
        {
            this.Name = name;
            this.parent = GetInstances()[category];
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