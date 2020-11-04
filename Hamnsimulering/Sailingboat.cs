using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hamnsimulering
{
    class Sailingboat : Boat
    {
        public int Length { get; set; }
        public Sailingboat(int weight, int speed, string id, int length)
            :base(weight, speed, 4, id)
        {
            Size = 2;
            Length = length;
        }
        public override bool FindSpotAndPark(Dock[] harbour)
        {
            return base.FindSpotAndPark(harbour);
        }
        private double GetMeter()
        {
            return Length * 0.3048;
        }
        public override string Print()
        {
            return base.Print() + $"{GetMeter():N2} m\t\t\tDagar kvar i hamn: {DaysTillDeparture}";
        }
        public override string SaveHistory()
        {
            return base.SaveHistory() + $"{Length}\t{DaysTillDeparture}";
        }
    }
}
