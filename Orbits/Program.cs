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

            for (int no2 = 6; no2 < 7; no2++)
            {
                Scale scale = new Scale(2 * no2);
                TransformSet g = new TransformSet(scale);
                IntervalSet d = new IntervalSet(scale, scale.n / 2);

                int scnt = 0;
                int dcnt = 0;
                while (d != null)
                {
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
                        Orbit o = new Orbit(g, d);
                        orbits.Add(o);
                        if (o.ccnt == 1)
                        {
                            Console.WriteLine("polarity of {0} is {1}",
                                d.Name(),
                                o.polarity.Name());
                            scnt++;
                        }
                    }
                    //Console.WriteLine(string.Format("orbit of {0} has size {1}",
                    //    d.Name(), o.sets.Count));
                    d = d.Step();
                }
                Console.WriteLine(string.Format("scale size {0} has {1}/{2} strong dichotomies",
                    2 * no2, scnt, dcnt)) ;
            }
            Console.WriteLine("Goodbye World!");
        }
    }
}
