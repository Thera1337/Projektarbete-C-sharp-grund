using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Hamnsimulering
{
    class Dock
    {
        public Boat FirstBoat { get; set; }
        public Rowboat SecondBoat { get; set; }
        public IsFull Status { get; set; }
        public Dock()
        {
            Status = IsFull.Free;
        }
        public enum IsFull
        {
            Free,
            OneRowboat,
            Occupied
        }
    }
}
