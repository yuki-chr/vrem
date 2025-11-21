using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal class Mirror
    {
        private List<MirrorPair> Pairs = [];

        public void AddPair(byte x, byte y)
        {
            Pairs.Add(new MirrorPair(x, y));
        }

        public byte GetMirrored(byte b)
        {
            foreach (MirrorPair pair in Pairs)
            {
                byte? result = pair.GetOrNull(b);
                if (result != null)
                {
                    return (byte)result;
                }
            }
            return b;
        }
    }
}
