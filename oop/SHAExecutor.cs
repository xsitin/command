using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using NetBox.Extensions;

namespace oop
{
    public class SHAExecutor : IFileExecutable
    {
        private readonly SHA512CryptoServiceProvider _sha = new();
        private readonly byte[] buffer = new byte[4096];

        public IEnumerable<string> Result
        {
            get
            {
                _sha.TransformFinalBlock(buffer, 0, 0);
                return _sha.Hash.ToHexString().AsEnumerable().ToList();
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
                _sha.TransformBlock(buffer, 0, length, buffer, 0);
            } while (length > 0);
        }
    }
}