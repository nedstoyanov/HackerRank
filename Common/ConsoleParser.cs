using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class ConsoleParser : IParser 
    {        
        public List<T> ReadList<T>() 
        {
            var line = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(line))
            {
                return line.Split(' ').Select(x => (T)Convert.ChangeType(x, typeof(T))).ToList();
            }

            return new List<T>();
        }

        public T Read<T>()
        {
            var line = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(line))
            {
                return (T) Convert.ChangeType(line, typeof(T));
            }

            return default(T);
        }
    }
}
