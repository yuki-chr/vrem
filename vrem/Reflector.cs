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

        public byte Process(byte b)
        {
            return (byte)((b+(KeySize/2))%KeySize); //TODO implement mirrored transformation
            //reflector should rotate every single call on top of every time its rotate method is called
        }

        public void Rotate()
        {
            //TODO
        }
    }
}
