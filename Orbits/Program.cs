using System;

namespace Orbits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int no2 = 3; no2 < 37; no2++)
            {
                Scale scale = new Scale(2 * no2);
                TransformSet g = new TransformSet(scale);
                IntervalSet d = new IntervalSet(scale, scale.n / 2);

                int scnt = 0;
                int dcnt = 0;
                while (d != null)
                {
                    dcnt++;
                    Orbit o = new Orbit(g, d);
                    if(o.ccnt == 1)
                    {
                        scnt++;
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
