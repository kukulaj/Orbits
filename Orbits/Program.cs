using System;

namespace Orbits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Scale scale = new Scale(12);
            TransformSet g = new TransformSet(scale);
            IntervalSet d = new IntervalSet(scale, scale.n / 2);
            Orbit o = new Orbit(g, d);
            Console.WriteLine(string.Format("orbit of {0} has size {1}",
                d.Name(), o.sets.Count));

            Console.WriteLine("Goodbye World!");
        }
    }
}
