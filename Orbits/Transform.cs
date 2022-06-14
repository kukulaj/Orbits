using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class Transform
    {
        public int factor;
        public int term;

        public Transform(int pfactor, int pterm)
        {
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
                    result.intervals[(term + factor * i) % from.scale.n] = true;
                }
            }

            return result;
        }
    }
}
