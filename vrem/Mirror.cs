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

        public void Initialize()
        {
            for (byte i = 0; i < 128; i++)
            {
                AddPair(i, (byte)(255 - i));
            }
        }

        public void Initialize(string key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(key);
            byte startc = 0;
            foreach (byte b in bytes)
            {
                startc += b;
            }
            startc %= 128;
            for (byte i = 0; i < 128; i++)
            {
                AddPair((byte)((startc + i) % 128), (byte)(255 - i));
            }
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
