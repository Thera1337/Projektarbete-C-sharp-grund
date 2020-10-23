using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnsimulering
{
    class Harbour
    {
        static Dock[] harbour = new Dock[64];
        static Random random = new Random();
        static void FillArray()
        {
            for (int i = 0; i < 64; i++)
            {
                harbour[i] = new Dock();
            }
        }
        static void AddBoats()
        {
            for (int i = 0; i < 5; i++)
            {
                int boatType = random.Next(0, 3 + 1);
                switch (boatType)
                {
                    case 0:
                        AddToHarbour(CreateRowboat());
                        break;

                    case 1:
                        AddToHarbour(CreateMotorboat());
                        break;

                    case 2:
                        AddToHarbour(CreateSailingboat());
                        break;

                    case 3:
                        AddToHarbour(CreateCargoship());
                        break;

                    default:
                        break;
                }
            }
        }
        static void AddToHarbour(Boat boat)
        {
            
        }
        static Boat CreateCargoship()
        {
            int weight = random.Next(3000, 20000 + 1);
            int speed = random.Next(1, 20 + 1);
            int containers = random.Next(0, 500 + 1);
            string id = String.Empty;
            id += (char)random.Next('A', 'Z');
            id += (char)random.Next('A', 'Z');
            id += (char)random.Next('A', 'Z');
            Boat cargoship = new Cargoship(weight, speed, $"L-{id}", containers);
            return cargoship;
        }
        static Boat CreateMotorboat()
        {
            int weight = random.Next(200, 3000 + 1);
            int speed = random.Next(1, 60 + 1);
            int horsepower = random.Next(10, 1000 + 1);
            string id = String.Empty;
            id += (char)random.Next('A', 'Z');
            id += (char)random.Next('A', 'Z');
            id += (char)random.Next('A', 'Z');
            Boat motorboat = new Motorboat(weight, speed, $"M-{id}", horsepower);
            return motorboat;
        }
        static Boat CreateSailingboat()
        {
            int weight = random.Next(800, 6000 + 1);
            int speed = random.Next(1, 12 + 1);
            int length = random.Next(10,60+1);
            string id = String.Empty;
            id += (char)random.Next('A', 'Z');
            id += (char)random.Next('A', 'Z');
            id += (char)random.Next('A', 'Z');
            Boat sailingboat = new Sailingboat(weight, speed, $"S-{id}", length);
            return sailingboat;
        }
        static Boat CreateRowboat()
        {
            int weight = random.Next(100, 300 + 1);
            int speed = random.Next(1, 3 + 1);
            int passengers = random.Next(1, 6 + 1);
            string id = String.Empty;
            id += (char)random.Next('A', 'Z');
            id += (char)random.Next('A', 'Z');
            id += (char)random.Next('A', 'Z');
            Boat rowboat = new Rowboat(weight, speed, $"R-{id}", passengers);
            return rowboat;
        }
    }
}
