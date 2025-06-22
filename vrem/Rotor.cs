using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal class Rotor(string fullkey, int ckey) : ICharPipeline
    {
        private List<byte> Key = []; //TODO implement method to create subst map
        private int RotationIndex = 0;
        private readonly ICharPipeline Next = ckey<fullkey.Length - 1 ? new Rotor(fullkey, ckey++) : new Reflector(fullkey);

        public byte Process(byte b)
        {
            byte forward = Key[(b+RotationIndex)%Key.Count];
            byte backward = Next.Process(forward);
            return (byte)((Key.IndexOf(backward)-RotationIndex)%Key.Count);
        }

        public void Rotate()
        {
            RotationIndex++;
            if(RotationIndex >= Key.Count)
            {
                RotationIndex = 0;
                Next.Rotate();
            }
        }
    }
}
