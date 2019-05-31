namespace ModelagemSoftware
{
    public class Instructions
    {
        private ItemLot lot;
        private Shelf shelf;
        private Position position;

        public ItemLot Lot { get => lot; set => lot = value; }
        public Shelf Shelf { get => shelf; set => shelf = value; }
        public Position Position { get => position; set => position = value; }

        public Instructions(ItemLot lot, Shelf shelf, Position position)
        {
            this.Lot = lot;
            this.Shelf = shelf;
            this.Position = position;
        }
    }
}