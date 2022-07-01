using System;
using System.Collections.Generic;

namespace Orbits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            

            for (int no2 = 4; no2 < 37; no2++)
            {
                List<Orbit> orbits = new List<Orbit>();
                Scale scale = new Scale(2 * no2);
                TransformSet gf = new TransformSet(scale, true);
                TransformSet gp = new TransformSet(scale, false);
                Transform p = gp.transforms[scale.rand.Next(gp.transforms.Count)];
                IntervalSet d = new IntervalSet(scale, p);

                int scnt = 0;
                int dcnt = 0;
                int stale = 0;
                while (stale < 5000 && orbits.Count < 50000)
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
                       
                        dcnt++;
                        //Console.WriteLine(string.Format("check {0}", d.Name()));
                        

                        if(d.Strong(gp) != null)
                        {
                            stale = 0;
                            Orbit o = new Orbit(gf, d);
                            orbits.Add(o);
                            scnt++;
                        }
                       
                    }
                    //Console.WriteLine(string.Format("orbit of {0} has size {1}",
                    //    d.Name(), o.sets.Count));
                    p = gp.transforms[scale.rand.Next(gp.transforms.Count)];
                    d = new IntervalSet(scale, p);
                }
                Console.WriteLine(string.Format("scale size {0} has {1} strong dichotomy classes",
                    2 * no2, orbits.Count)) ;
            }
            Console.WriteLine("Goodbye World!");
        }
    }
}
