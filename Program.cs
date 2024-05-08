﻿using System;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = new Task[10];
            const int UPPER = 10;

            for (int i = 0; i < UPPER; i++)
            {
                int val = i;
                tasks[i] = Task.Factory.StartNew(() => {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Task number started {0}",val);
                    
                    System.Threading.Thread.Sleep(val*500);

                    // Simulate some work by sleeping for 2 seconds
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task number {0} completed.", val);
                    Console.ResetColor();
                } );
            }
            Task.WaitAll(tasks);
        }
    }
}