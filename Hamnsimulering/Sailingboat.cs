using System;
using System.Collections.Generic;
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
    }
}
