using System;
using System.Collections.Generic;

namespace oop
{
    public class ConsoleResulter : IResulter
    {
        public void WriteResult(IEnumerable<string> result)
        {
            foreach (var line in result) Console.WriteLine(line);
        }
    }
}