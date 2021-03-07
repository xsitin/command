using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using NetBox.Extensions;

namespace oop
{
    public class Md5Executor : IFileExecutable
    {
        private readonly MD5CryptoServiceProvider _md5 = new();
        private readonly byte[] buffer = new byte[4096];

        public IEnumerable<string> Result
        {
            get
            {
                _md5.TransformFinalBlock(buffer, 0, 0);
                return _md5.Hash.ToHexString().AsEnumerable().ToList();
            }
        }


        public void Execute(string path)
        {
            int length;
            if (!File.Exists(path))
                return;
            using var fs = File.OpenRead(path);
            do
            {
                length = fs.Read(buffer, 0, buffer.Length);
                _md5.TransformBlock(buffer, 0, length, buffer, 0);
            } while (length > 0);
        }
    }
}