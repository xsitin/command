using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace oop
{
    public class FileWorker : IWorker
    {
        private readonly Queue<IFileExecutable> _commands = new();
        private readonly Queue<IFileExecutable> _executed = new();
        private readonly string _path;
        private readonly bool _recursive;

        public FileWorker(string path, bool isRecursive)
        {
            _path = path;
            _recursive = isRecursive;
        }

        public void Add(IFileExecutable command)
        {
            _commands.Enqueue(command);
        }

        public void Run()
        {
            if (!Directory.Exists(_path))
                throw new Exception("invalid path: " + _path);

            while (_commands.Any())
            {
                var command = _commands.Dequeue();
                foreach (var file in Directory.EnumerateFileSystemEntries(_path, "",
                    _recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                    command.Execute(file);
                _executed.Enqueue(command);
            }
        }

        public void Dump(IResulter resulter)
        {
            resulter.WriteResult(_executed.SelectMany(x => x.Result));
        }
    }
}