using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnsimulering
{
    class Boat
    {
        public int Weight { get; set; }
        public int Speed { get; set; }
        public int DaysTillDeparture { get; set; }
        public string ID { get; set; }
        public Boat(int weight, int speed, int daysTillDeparture, string id)
        {
            Weight = weight;
            Speed = speed;
            DaysTillDeparture = daysTillDeparture;
            ID = id;
        }
    }
}
