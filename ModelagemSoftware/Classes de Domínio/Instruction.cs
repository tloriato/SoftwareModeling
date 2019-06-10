using System;

namespace ModelagemSoftware
{
    [Serializable()]
    public class Instruction
    {
        private ItemLot lot;
        private Shelf shelf;
        private Position position;
        private Status status;
        private string justification;

        public ItemLot Lot { get => lot; set => lot = value; }
        public Shelf Shelf { get => shelf; set => shelf = value; }
        public Position Position { get => position; set => position = value; }
        public Status Status { get => status; set => status = value; }
        public string Justification { get => justification; set => justification = value; }

        public Instruction()
        {

        }
        public Instruction(ItemLot lot, Shelf shelf, Position position)
        {
            this.Lot = lot;
            this.Shelf = shelf;
            this.Position = position;
            this.Status = Status.Storing;
        }

        public int GetLotId()
        {
            return this.Lot.Id;
        }

        public int GetShelfId()
        {
            return this.Shelf.Id;
        }

        public int GetPositionId()
        {
            return this.Position.Id;
        }
    }
}