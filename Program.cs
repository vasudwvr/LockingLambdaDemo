using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {

        static bool done;
        static readonly object locker = new object();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(Go).Start();
            }

            for (int i = 0; i < 10; i++)
            {
                int temp = i;
                new Thread(() => Console.WriteLine(temp)).Start();
            }
        }

        static void Go()
        {
           lock (locker)
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            }
        }

    }

}
