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
                Transform p = g.transforms[scale.rand.Next(g.transforms.Count)];
                IntervalSet d = new IntervalSet(scale, p);

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
                        //Console.WriteLine(string.Format("check {0}", d.Name()));
                        //Orbit o = new Orbit(g, d);
                        //orbits.Add(o);

                        if(d.Strong(g) != null)
                        {
                            scnt++;
                        }
                       
                    }
                    //Console.WriteLine(string.Format("orbit of {0} has size {1}",
                    //    d.Name(), o.sets.Count));
                    p = g.transforms[scale.rand.Next(g.transforms.Count)];
                    d = new IntervalSet(scale, p);
                }
                Console.WriteLine(string.Format("scale size {0} has {1}/{2} strong dichotomies",
                    2 * no2, scnt, dcnt)) ;
            }
            Console.WriteLine("Goodbye World!");
        }
    }
}
