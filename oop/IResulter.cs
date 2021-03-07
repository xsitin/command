using System.Collections.Generic;

namespace oop
{
    public interface IResulter
    {
        void WriteResult(IEnumerable<string> result);
    }
}