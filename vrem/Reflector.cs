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
        private bool selfcrypt = false;

        public Reflector()
        {
            mirror.Initialize();
        }

        public Reflector(string key)
        {
            mirror.Initialize(key);
        }

        public byte Process(byte b)
        {
            if (selfcrypt)
            {
                selfcrypt = false;
                return b;
            }
            else
            {
                return mirror.GetMirrored(b);
                
            }
        }

        public void Rotate()
        {
            selfcrypt = true;
        }
    }
}
