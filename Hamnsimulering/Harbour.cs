using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Hamnsimulering
{
    class Harbour
    {
        static Dock[] harbour = new Dock[64];
        static Random random = new Random();
        static int numberOfBoatsTurnedAway;
        public static void FillArray()
        {
            for (int i = 0; i < 64; i++)
            {
                harbour[i] = new Dock();
            }
        }
        public static void Print()
        {
            int count = 1;
            Console.WriteLine($"Plats ID\tVikt\tHastighet\tAntal platser\tUnik egenskap\t\t Antal avvisade båtar: {numberOfBoatsTurnedAway}");
            foreach (var item in harbour)
            {
                if (item.Status is Dock.IsFull.Free)
                {
                    Console.WriteLine($"{count}: tomt");
                }
                if (item.FirstBoat != null)
                {
                    Console.WriteLine($"{count} - {count + item.FirstBoat.Size -1}: {item.FirstBoat.Print()}");
                }
                if (item.SecondBoat != null)
                {
                    Console.WriteLine($"{count} : \t{item.SecondBoat.Print()}");
                }
                count++;
            }
        }
        public static void WriteToFile()
        {
            StreamWriter sw = new StreamWriter("HarbourHistory.txt", false);
            for (int i = 0; i < harbour.Length; i++)
            {
                if (harbour[i].FirstBoat != null)
                {
                    sw.WriteLine($"{i}\t{harbour[i].FirstBoat.SaveHistory()}");
                }
                if (harbour[i].SecondBoat != null)
                {
                    sw.WriteLine($"{i}\t{harbour[i].SecondBoat.SaveHistory()}");
                }
            }
            sw.Close();
        }
        public static void ImportHarbourHistory()
        {
            foreach (string line in File.ReadAllLines("HarbourHistory.txt", Encoding.UTF8))
            {
                //Läser in [0]: position, [1]:ID, [2]:Vikt, [3]:hastighet, [4]: tomt, [5]:storlek, [6]: tomt, [7]:Unik prop
                string[] props = line.Split('\t');
                
                //Kopierar över alla element som inte är tomma till q1 
                var q1 = props
                    .Where(q => q != string.Empty).ToArray();

                //Skapar båt baserat på informationen från filen sparad i q1
                //[0]: position, [1]:ID, [2]:Vikt, [3]:hastighet, [4]:storlek, [5]:Unik prop 
                for (int i = 0; i < q1.Length; i++)
                {
                    switch (q1[1].First())
                    {
                        case 'R':
                            Boat rowboat = new Rowboat(int.Parse(q1[2]), int.Parse(q1[3]), q1[1], int.Parse(q1[5]));
                            rowboat.Park(harbour, int.Parse(q1[0]));
                            break;
                        case 'M':
                            Boat motorboat = new Motorboat(int.Parse(q1[2]), int.Parse(q1[3]), q1[1], int.Parse(q1[5]));
                            motorboat.Park(harbour, int.Parse(q1[0]));
                            break;
                        case 'S':
                            Boat sailingboat = new Sailingboat(int.Parse(q1[2]), int.Parse(q1[3]), q1[1], int.Parse(q1[5]));
                            sailingboat.Park(harbour, int.Parse(q1[0]));
                            break;
                        case 'L':
                            Boat cargoship = new Cargoship(int.Parse(q1[2]), int.Parse(q1[3]), q1[1], int.Parse(q1[5]));
                            cargoship.Park(harbour, int.Parse(q1[0]));
                            break;
                        default:
                            break;
                    }
                }
            }
            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Filnamn");
        }
        public static void AddBoats()
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
            if (!boat.FindSpotAndPark(harbour))
            {
                numberOfBoatsTurnedAway++;
            }
        }
        public static void DepartureCountDown()
        {
            foreach (var item in harbour)
            {
                if (item.FirstBoat != null)
                {
                    item.FirstBoat.DaysTillDeparture--;
                }
                if (item.SecondBoat != null)
                {
                    item.SecondBoat.DaysTillDeparture--;
                }
            }
        }
        public static void Departure()
        {
            for (int i = 0; i < harbour.Length; i++)
            {
                if (harbour[i].SecondBoat != null && harbour[i].SecondBoat.DaysTillDeparture is 0)
                {
                    harbour[i].SecondBoat.Departure(harbour, i);
                }
                if (harbour[i].FirstBoat != null && harbour[i].FirstBoat.DaysTillDeparture is 0)
                {
                    harbour[i].FirstBoat.Departure(harbour, i);
                }
            }
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
            int length = random.Next(10, 60 + 1);
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
