using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrem
{
    internal interface ICharPipeline
    {
        public byte Process(byte c);
        public void Rotate();
    }
}
