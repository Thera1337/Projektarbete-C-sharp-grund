using System;
using System.Threading;

namespace Hamnsimulering
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = Harbour.GetCurrentDay();
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
                //Harbour.SaveDate(i);
                //Console.ReadLine();
                Thread.Sleep(5000);

                Harbour.SetNewDate();
            }
        }
    }
}
