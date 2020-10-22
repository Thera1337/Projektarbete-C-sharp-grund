using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnsimulering
{
    class Sailingboat : Boat
    {
        public int Length { get; set; }
        public Sailingboat(int weight, int speed, string id, int length)
            :base(weight, speed, id)
        {
            Length = length;
        }
    }
}
