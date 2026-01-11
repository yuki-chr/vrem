using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal class Reflector : ICharPipeline
    {
        private const int KeySize = 256;
        private readonly Mirror mirror = new();
        private int selfcount = 0;
        private int selfcap = 1; //initialized as 1 since it will be multiplied


        public Reflector()
        {
            mirror.Initialize();
            selfcap = KeySize;
        }

        public Reflector(string key)
        {
            mirror.Initialize(key);
            foreach (byte b in Encoding.UTF8.GetBytes(key))
            {
                selfcap = (selfcap * b) % KeySize;
            }
        }

        public byte Process(byte b)
        {
            if (selfcount == selfcap)
            {
                selfcount = (selfcount + 1) % KeySize;
                return b;
            }
            else
            {
                selfcount = (selfcount + 1) % KeySize;
                return mirror.GetMirrored(b);
            }
        }

        public void Rotate()
        {
            selfcap = (selfcap*selfcap)%KeySize;
        }
    }
}

