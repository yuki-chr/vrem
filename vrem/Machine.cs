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

        public string Process(string text)
        {
            List<byte> bytes = [.. Encoding.UTF8.GetBytes(text)];
            List<byte> processed = [];
            foreach (byte b in bytes)
            {
                processed.Add(Head.Process(b));
                Head.Rotate();
            }

            return Encoding.UTF8.GetString([.. processed]);
        }
    }
}
