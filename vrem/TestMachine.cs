using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal class TestMachine(string key)
    {
        private readonly Rotor Head = new(key);

        public string Process(string text)
        {
            List<string> bytesStr = [.. text.Split(" ")];
            List<byte> bytes = new();
            foreach (string str in bytesStr)
            {
                bytes.Add((byte)(char)Int32.Parse(str));
            }
            List<string> processed = [];
            foreach (byte b in bytes)
            {
                processed.Add((Head.Process(b)).ToString());
                Head.Rotate();
            }

            return string.Join(" ", processed);
        }
    }
}
