using System;

namespace StopwatchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Watch();

            watch.OnStarted += message => Console.WriteLine(message);
            watch.OnStopped += message => Console.WriteLine(message);
            watch.OnReset += message => Console.WriteLine(message);

            Console.WriteLine("Welcome to the Stopwatch App!");

            while (true)
            {
                Console.WriteLine("\nPress S to Start, T to Stop, R to Reset, or Q to Quit.");
                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.S:
                        watch.Start();
                        break;
                    case ConsoleKey.T:
                        watch.Stop();
                        break;
                    case ConsoleKey.R:
                        watch.Reset();
                        break;
                    case ConsoleKey.Q:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;
                }
            }
        }
    }
}
