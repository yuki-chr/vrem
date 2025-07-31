using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal class Rotor(string fullkey, int ckey = 0) : ICharPipeline
    {
        private const int KeySize = 256;
        private readonly byte Key = Encoding.UTF8.GetBytes(fullkey)[ckey];
        private int RotationIndex = 0;
        private readonly ICharPipeline Next = ckey<fullkey.Length - 1 ? new Rotor(fullkey, ckey+1) : new Reflector(fullkey);

        public byte Process(byte b)
        {
            byte forward = (byte)((Key+RotationIndex+b)%KeySize);
            byte backward = Next.Process(forward);
            return (byte)((backward-(Key+RotationIndex))%KeySize);
        }

        public void Rotate()
        {
            RotationIndex++;
            if(RotationIndex >= KeySize)
            {
                RotationIndex = 0;
                Next.Rotate();
            }
        }
    }
}
