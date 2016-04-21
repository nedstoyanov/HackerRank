using System.Collections.Generic;

namespace Common
{
    public interface IPrinter
    {
        void Print<T>(IEnumerable<T> values);
    }
}