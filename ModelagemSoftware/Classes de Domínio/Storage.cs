using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TableParser;

namespace ModelagemSoftware
{
    public class Storage
    {
        static int counter = 0;

        public int id;
        public Shelf[][] shelves;

        public List<ItemLot> pendingItems;
        public List<Order> storageOrders = new List<Order>();

        public Storage(int lines, int columns)
        {
            this.id = Storage.counter;

            Interlocked.Increment(ref counter);

            shelves = new Shelf[lines][];

            for (int i = 0; i < lines; i++)
            {
                shelves[i] = new Shelf[columns];

                for (int j = 0; j < columns; j++)
                {
                    shelves[i][j] = new Shelf(3);
                }
            }

        }

        ~Storage()
        {
            Interlocked.Decrement(ref counter);
        }

        public Boolean InsertPendingItem(ItemLot item)
        {
            if (this.pendingItems == null)
            {
                this.pendingItems = new List<ItemLot>();
            }

            this.pendingItems.Add(item);

            return true;
        }

        public Boolean InsertPendingItems(List<ItemLot> items)
        {
            foreach (ItemLot item in items)
            {
                InsertPendingItem(item);
            }

            return true;
        }

        public ItemLot ItemById(int id)
        {
            ItemLot item = this.pendingItems.Find(x => x.Id == id);
            return item;
        }

        public Order CreateStorageOrder(int[] ids, Worker worker)
        {
            Instruction[] instructions = new Instruction[ids.Length];

            for (int i = 0; i < ids.Length; i++)
            {
                ItemLot item = ItemById(ids[i]);

                if (item.Status != Status.Pending)
                {
                    return null;
                }

                Instruction maybeInstruction = FindFreeSpaceForId(item);

                if (maybeInstruction == null)
                {
                    return null;
                }

                item.Status = Status.Storing;
                instructions[i] = maybeInstruction;
            }



            this.storageOrders.Add(new Order(instructions, worker));

            return this.storageOrders[this.storageOrders.Count - 1];
        }

        private Instruction FindFreeSpaceForId(ItemLot itemLot)
        {
            foreach (Shelf[] line in shelves)
            {
                foreach (Shelf shelf in line)
                {
                    if (shelf.CanItStore(itemLot))
                    {
                        Position position = shelf.ReservePosition(itemLot);
                        Instruction instructions = new Instruction(itemLot, shelf, position);
                        return instructions;
                    }

                }
            }

            return null;
        }

        public Order GetOrderById(int id)
        {
            foreach (Order order in storageOrders)
            {
                if (order.Id == id)
                {
                    return order;
                }

            }

            return null;
        }

        internal void PrintPending()
        {
            List<ItemLot> holder = new List<ItemLot>();

            foreach (ItemLot item in pendingItems)
            {
                if (item.Status == Status.Pending)
                {
                    holder.Add(item);
                }
            }

            var table = holder.ToStringTable
                    (
                        new[] { "ItemLot ID", "Cod. Barras", "Quantidade", "Categoria" },
                        u => u.Id,
                        u => u.Merchandise.BarCode,
                        u => u.Quantity,
                        u => u.Category.Name
                    );

            Console.WriteLine(table);
        }

        internal void PrintStoringOrders()
        {
            foreach (Order order in storageOrders)
            {
                if (order.Status == Status.Storing)
                {
                    Console.WriteLine($"Order #{order.Id} with status {order.Status} by worker {order.Responsable.name}");
                }
            }
        }

        internal void PrintUnsolvedOrders()
        {
            List<Order> holder = new List<Order>();

            foreach (Order order in storageOrders)
            {
                if (order.Status == Status.StoredWithErrorsUnsolved)
                {
                    holder.Add(order);
                }
            }

            var table = holder.ToStringTable
                    (
                        new[] { "Order ID", "Status", "Worker" },
                        u => u.Id,
                        u => u.Status,
                        u => u.Responsable.name
                    );

            Console.WriteLine(table);
        }

        internal void PrintUnsolvedInstructionsFromOrderId(int id)
        {
            Order order = GetOrderById(id);

            if (order.Status != Status.StoredWithErrorsUnsolved) return;

            List<Instruction> holder = new List<Instruction>();

            foreach (Instruction instruction in order.intructions)
            {
                if (instruction.Status == Status.Error)
                {
                    holder.Add(instruction);
                }
            }

            var table = holder.ToStringTable
                (
                    new[] { "LOT ID", "SHELF ID", "POSITION ID", "CURRENT STATUS", "JUSTIFICATION" },
                    u => u.Lot.Id,
                    u => u.Shelf.Id,
                    u => u.Position.Id,
                    u => u.Status,
                    u => u.Justification
                );

            Console.WriteLine(table);
        }
    }
}
