using System;
using System.Threading;

namespace Hamnsimulering
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Harbour.FillArray();
            Harbour.ImportHarbourHistory();
            while (i < 365)
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

                i++;
            }
        }
    }
}
