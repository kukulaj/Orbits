using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class IntervalSet
    {
        public Scale scale;
        public bool[] intervals;
        
        public IntervalSet(Scale pscale)
        {
            scale = pscale;
            intervals = new bool[scale.n];
        }
        public IntervalSet(Scale pscale, int n) : this(pscale)
        {
           for(int i = 0; i < n; i++)
            {
                intervals[i] = true;
            }
           
        }

        public string Name()
        {
            string result = "{";
            for(int i = 0; i < scale.n; i++)
            {
                if(intervals[i])
                {
                    result = result + string.Format(" {0}", i);
                }
            }
            return result + " }" ;
        }

    }
}
