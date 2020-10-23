﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnsimulering
{
    class Cargoship : Boat
    {
        public int NumberOfContainers { get; set; }
        public Cargoship(int weight, int speed, string id, int numberOfContainers)
            :base(weight, speed, 6, id)
        {
            NumberOfContainers = numberOfContainers;
        }
    }
}
