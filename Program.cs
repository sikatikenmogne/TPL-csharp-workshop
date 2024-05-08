﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main()
        {
            Parallel.For(0, 10, i =>
            {
                int square = i * i;
                Console.WriteLine($"Square of {i} is {square}");
            });
        }
    }
}