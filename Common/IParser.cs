
using System.Collections.Generic;

namespace Common
{
    public interface IParser
    {
        List<T> ReadList<T>();

        T Read<T>();
    }
}