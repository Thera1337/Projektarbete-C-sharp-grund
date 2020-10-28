using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnsimulering
{
    class Motorboat : Boat
    {
        public int HorsePower { get; set; }
        public Motorboat(int weight, int speed, string id, int horsePower)
            :base(weight, speed, 3, id)
        {
            Size = 1;
            HorsePower = horsePower;
        }
        public override bool FindSpotAndPark(Dock[] harbour)
        {
            return base.FindSpotAndPark(harbour);
        }
        public override string Print()
        {
            return base.Print() + $"{HorsePower} hp\t\tDagar kvar i hamn: {DaysTillDeparture}";
        }
        public override string SaveHistory()
        {
            return base.SaveHistory() + $"{HorsePower}";
        }
    }
}
