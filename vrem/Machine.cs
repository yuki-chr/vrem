using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal class Machine(string key)
    {
        private readonly string Key = key;
        private readonly Rotor Head = new(key);

        public byte[] Process(byte[] bytes)
        {
            List<byte> processed = [];
            foreach (byte b in bytes)
            {
                processed.Add(Head.Process(b));
                Head.Rotate();
            }

            return [.. processed];
        }
    }
}
