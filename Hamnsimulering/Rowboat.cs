using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnsimulering
{
    class Rowboat : Boat
    {
        public int NumberOfPassengers { get; set; }
        public Rowboat(int weight, int speed, string id, int numbersOfPassengers)
            : base(weight, speed, id)
        {
            NumberOfPassengers = numbersOfPassengers;
        }
    }
}
