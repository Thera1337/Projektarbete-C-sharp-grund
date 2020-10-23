using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnsimulering
{
    class DummyBoat : Boat
    {
        public DummyBoat(int weight, int speed, string id)
            :base(weight, speed, 0, id)
        {

        }
    }
}
