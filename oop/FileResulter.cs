using System.Collections.Generic;
using System.IO;

namespace oop
{
    public class FileResulter : IResulter
    {
        private readonly string _path;

        public FileResulter(string path)
        {
            _path = path;
        }

        public void WriteResult(IEnumerable<string> result)
        {
            var writer = new StreamWriter(File.OpenWrite(_path));
            foreach (var line in result) writer.WriteLine(line);
        }
    }
}