using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal class MirrorPair(byte x, byte y)
    {
        private byte X = x;
        private byte Y = y;

        public byte? GetOrNull(byte b)
        {
            if (b == X)
            {
                return Y;
            }
            else if (b == Y)
            {
                return X;
            }
            else
            {
                return null;
            }
        }
    }
}
