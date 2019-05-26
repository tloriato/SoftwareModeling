using System;
using System.Collections.Generic;
using System.Text;

namespace ModelagemSoftware
{
    public class Order
    {
        public int id;
        public Worker responsable;
        public Status status;
        public string resolution;
        public Intructions[] intructions;
    }
}
