using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class Orbit
    {
        public Dictionary<string, IntervalSet> sets;
        public Dictionary<string, Transform> polarities;
    

        public Orbit()
        {
            sets = new Dictionary<string, IntervalSet>();
            polarities = new Dictionary<string, Transform>();
        }

        public Orbit(TransformSet g, IntervalSet d) : this()
        {
            foreach (Transform t in g.transforms)
            {
                IntervalSet d2 = t.Apply(d);
                Add(d2);
            }

            //foreach (KeyValuePair<string, IntervalSet> kvp in sets)
            {
                IntervalSet set =
                    //kvp.Value;
                    d;
                foreach (Transform t in g.transforms)
                {
                    IntervalSet set2 = t.Apply(set);
                     
                    if (set.Complement(set2))
                    {
                        IntervalSet set3 = t.Apply(set2);
                        if (set2.Complement(set3))
                        {
                            string pName = t.Name();
                            polarities[pName] = t;
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
