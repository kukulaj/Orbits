using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class Orbit
    {
        public Dictionary<string, IntervalSet> sets;
    
        public Orbit()
        {
            sets = new Dictionary<string, IntervalSet>();
        }

        public Orbit(TransformSet g, IntervalSet d) : this()
        {
            foreach (Transform t in g.transforms)
            {
                IntervalSet d2 = t.Apply(d);
                bool unique = Add(d2);
            }
            //Console.WriteLine(string.Format("{0} interval sets in orbit", sets.Count));
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
