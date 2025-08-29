using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal class Reflector(string key) : ICharPipeline
    {
        private const int KeySize = 256;
        private bool selfcrypt = false;

        public byte Process(byte b)
        {
            if (selfcrypt)
            {
                selfcrypt = false;
                return b;
            }
            else
            {
                return (byte)((b + (KeySize / 2)) % KeySize); //TODO implement mirrored transformation
            }
        }

        public void Rotate()
        {
            //testing alternative method to deal with statistical analysis
            selfcrypt = true;
        }
    }
}
