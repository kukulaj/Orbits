using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class TransformSet
    {
        public List<Transform> transforms;

        public Scale scale;
        public TransformSet(Scale pscale)
        {
            transforms = new List<Transform>();
            scale = pscale;

            for(int term = 0; term < scale.n; term++)
            {
                for(int factor = 1; factor < scale.n; factor++)
                {
                    if(GCD(factor, scale.n) == 1)
                    {
                        Console.WriteLine(string.Format("{0} + {1} * k", term, factor));
                        Transform t = new Transform(factor, term);
                        transforms.Add(t);
                    }
                }
            }
        }

        static int GCD(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }




    }
}
