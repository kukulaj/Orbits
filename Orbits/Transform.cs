using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class Transform
    {
        public int factor;
        public int term;
        public Scale scale;

        public Transform(Scale pscale,  int pfactor, int pterm)
        {
            scale = pscale;
            factor = pfactor;
            term = pterm;
        }

        public string Name()
        {
            return string.Format(" {0} + {1}*k; ", term, factor);
        }

        public IntervalSet Apply(IntervalSet from)
        {
            IntervalSet result = new IntervalSet(from.scale);
            for (int i = 0; i < from.scale.n; i++)
            {
                if (from.intervals[i])
                {
                    result.intervals[Apply(i)] = true;
                }
            }

            return result;
        }

        public int Apply(int from)
        {
            return (term + factor * from) % scale.n;
        }
    }
}
