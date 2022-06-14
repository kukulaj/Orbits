using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class Orbit
    {
        public Dictionary<string, IntervalSet> sets;
        public int ccnt;
        public Transform polarity;

        public Orbit()
        {
            sets = new Dictionary<string, IntervalSet>();
        }

        public Orbit(TransformSet g, IntervalSet d) : this()
        {
            ccnt = 0;
            foreach(Transform t in g.transforms)
            {
                IntervalSet d2 = t.Apply(d);
                bool unique = Add(d2);
                if(unique)
                {
                    if(d.Complement(d2))
                    {
                        IntervalSet d3 = t.Apply(d2);
                        if (d2.Complement(d3))
                        {
                            ccnt++;
                            polarity = t;
                        }
                    }
                }
            }
        }

        public bool Add(IntervalSet set)
        {
            string name = set.Name();
            if (sets.ContainsKey(name)) 
            {
                return false;
            }
            sets[name] = set;
            return true;
        }
    }
}
