using System;
using System.Threading;

namespace Hamnsimulering
{
    class Program
    {
        static void Main(string[] args)
        {
            Harbour.FillArray();
            Harbour.ImportHarbourHistory();
            Harbour.SetNumberOfBoatsPerDay();

            while (Harbour.GetCurrentDay() < 365)
            {
                //Console.SetCursorPosition(0, 0);
                Console.Clear();
                Harbour.Departure();
                Harbour.AddBoats();
                Harbour.Print();
                Harbour.DepartureCountDown();
                Harbour.WriteToFile();
                //Console.ReadLine();
                Thread.Sleep(5000);

                Harbour.SetNewDate();
            }
        }
    }
}
