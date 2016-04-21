using System;
using System.Collections.Generic;

namespace Common
{
    public class ConsolePrinter : IPrinter
    {
        public void Print<T>(IEnumerable<T> values)
        {
            foreach (var i in values)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        public void Print<T>(T value)
        {
            Console.Write(value);

            Console.WriteLine();
        }
    }
}