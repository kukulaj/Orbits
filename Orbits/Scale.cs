using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class Scale
    {
        public int n;
        public Random rand;
        public Scale(int pn)
        {
            n = pn;
            rand = new Random(22);
        }
    }
}
