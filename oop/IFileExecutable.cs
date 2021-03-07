using System.Collections.Generic;

namespace oop
{
    public interface IFileExecutable
    {
        IEnumerable<string> Result { get; }
        void Execute(string path);
    }
}