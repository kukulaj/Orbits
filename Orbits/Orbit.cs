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
           
        }

        public Orbit(TransformSet g, IntervalSet d) : this()
        {
            foreach (Transform t in g.transforms)
            {
                IntervalSet d2 = t.Apply(d);
                bool unique = Add(d2);
                if(unique)
                {
                    polarities = new Dictionary<string, Transform>();
                    foreach (Transform t2 in g.transforms)
                    {
                        IntervalSet set2 = t2.Apply(d2);

                        if (d2.Complement(set2))
                        {
                            IntervalSet set3 = t2.Apply(set2);
                            if (set2.Complement(set3))
                            {
                                string pName = t2.Name();
                                polarities[pName] = t2;
                            }
                        }

                    }

                    if (polarities.Count == 1)
                    {
                        Console.Write("polarity of {0} -> {1} is: ",
                            t.Name(), d2.Name());
                        foreach (KeyValuePair<string, Transform> kvp in polarities)
                        {
                            Console.WriteLine(kvp.Key);
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
