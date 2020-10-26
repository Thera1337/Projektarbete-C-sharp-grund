namespace Hamnsimulering
{
    class Rowboat : Boat
    {
        public int NumberOfPassengers { get; set; }
        public Rowboat(int weight, int speed, string id, int numbersOfPassengers)
            : base(weight, speed, 1, id)
        {
            Size = 1;
            NumberOfPassengers = numbersOfPassengers;
        }
        public override bool FindSpotAndPark(Dock[] harbour)
        {

            int emptySpots = 0;
            int i = 0;
            for (; i < harbour.Length; i++)
            {
                if (harbour[i].Status is Dock.IsFull.Occupied)
                {
                    emptySpots = 0;
                    continue;
                }

                emptySpots++;

                if (emptySpots >= Size)
                {
                    break;
                }
            }

            if (i < harbour.Length)
            {
                int spot = (i + 1) - Size;
                for (int j = 0; j < Size; j++)
                {
                    if (harbour[spot].Status is Dock.IsFull.OneRowboat)
                    {
                        harbour[spot].SecondBoat = this;
                        harbour[spot].Status = Dock.IsFull.Occupied;
                    }
                    else
                    {
                        harbour[spot].FirstBoat = this;
                        harbour[spot].Status = Dock.IsFull.OneRowboat;
                    }
                    spot++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Departure(Dock[] docks, int i)
        {
            if (docks[i].FirstBoat == this)
            {
                base.Departure(docks, i);
            }
            else
            {
                docks[i].SecondBoat = null;
                docks[i].Status = Dock.IsFull.OneRowboat;
            }
        }
    }
}
