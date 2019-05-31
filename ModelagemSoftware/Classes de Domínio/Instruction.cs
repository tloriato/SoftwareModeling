namespace ModelagemSoftware
{
    public class Instruction
    {
        private ItemLot lot;
        private Shelf shelf;
        private Position position;

        public ItemLot Lot { get => lot; set => lot = value; }
        public Shelf Shelf { get => shelf; set => shelf = value; }
        public Position Position { get => position; set => position = value; }

        public Instruction(ItemLot lot, Shelf shelf, Position position)
        {
            this.Lot = lot;
            this.Shelf = shelf;
            this.Position = position;
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