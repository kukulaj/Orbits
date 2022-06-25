using System;
using System.Collections.Generic;

namespace Orbits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Orbit> orbits = new List<Orbit>();

            for (int no2 = 36; no2 < 37; no2++)
            {
                Scale scale = new Scale(2 * no2);
                TransformSet g = new TransformSet(scale);
                IntervalSet d = new IntervalSet(scale, scale.n / 2);

                int scnt = 0;
                int dcnt = 0;
                int stale = 0;
                while (stale < 50 && scnt < 10)
                {
                    stale++;
                    bool fresh = true;
                    foreach(Orbit old in orbits)
                    {
                        if(old.sets.ContainsKey(d.Name()))
                        {
                            fresh = false;
                            break;
                        }
                    }

                    if (fresh)
                    {
                        stale = 0;
                        dcnt++;
                        Orbit o = new Orbit(g, d);
                        //orbits.Add(o);
                        if (o.polarities.Count == 1)
                        {
                            Console.Write("polarity of {0} is: ",
                                d.Name());
                            foreach(KeyValuePair<string, Transform> kvp in o.polarities)
                            {
                                Console.WriteLine(kvp.Key);
                            }
                            scnt++;
                        }
                    }
                    //Console.WriteLine(string.Format("orbit of {0} has size {1}",
                    //    d.Name(), o.sets.Count));
                    d = d.Randomize(scale.n / 2);
                }
                Console.WriteLine(string.Format("scale size {0} has {1}/{2} strong dichotomies",
                    2 * no2, scnt, dcnt)) ;
            }
            Console.WriteLine("Goodbye World!");
        }
    }
}
