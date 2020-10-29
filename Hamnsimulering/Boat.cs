using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Hamnsimulering
{
    class Boat
    {
        public int Weight { get; set; }
        public int Speed { get; set; }
        public int Size { get; set; }
        public int DaysTillDeparture { get; set; }
        public string ID { get; set; }
        public Boat(int weight, int speed, int daysTillDeparture, string id)
        {
            Weight = weight;
            Speed = speed;
            DaysTillDeparture = daysTillDeparture;
            ID = id;
        }
        public virtual bool FindSpotAndPark(Dock[] harbour)
        {
            int emptySpots = 0;
            int i = 0;
            for (; i < harbour.Length; i++)
            {
                if (harbour[i].Status != Dock.IsFull.Free)
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

            if (i<harbour.Length)
            {
                int spot = (i + 1) - Size;
                Park(harbour, spot);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Park(Dock[] harbour, int spot)
        {
            harbour[spot].FirstBoat = this;
            for (int j = 0; j < Size; j++)
            {
                harbour[spot].Status = Dock.IsFull.Occupied;
                spot++;
            }
        }

        public virtual void Departure(Dock[] docks, int i)
        {
            docks[i].FirstBoat = null;
            for (int j = 0; j < Size; j++)
            {
                docks[i].Status = Dock.IsFull.Free;
                i++;
            }
        }
        public double GetKmH()
        {
            return Speed * 1.852;
        }
        public virtual string Print()
        {
            string printString = $"{ID}\t{Weight}kg\t{GetKmH():N2} km/h\t{Size}\t\t";

            return printString;
        }
        public virtual string SaveHistory()
        {
            string printString = $"{ID}\t{Weight}\t{Speed}\t{Size}\t";

            return printString;
        }
    }
}
