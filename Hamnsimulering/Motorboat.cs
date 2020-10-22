using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnsimulering
{
    class Motorboat : Boat
    {
        public int HorsePower { get; set; }
        public Motorboat(int weight, int speed, string id, int horsePower)
            :base(weight, speed, id)
        {
            HorsePower = horsePower;
        }
    }
}
