using System;

namespace Hamnsimulering
{
    class Program
    {
        static void Main(string[] args)
        {
            Harbour.FillArray();
            while (true)
            {
                //Console.SetCursorPosition(0, 0);
                Console.Clear();
                Harbour.Departure();
                Harbour.AddBoats();
                Harbour.DepartureCountDown();
                Harbour.Print();
                Console.ReadLine();
            }
        }
    }
}
