using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal class Reflector(string key) : ICharPipeline
    {

        public byte Process(byte b)
        {
            return b; //TODO implement mirrored transformation
            //reflector should rotate every single call on top of every time its rotate method is called
        }

        public void Rotate()
        {
            //TODO
        }
    }
}
