using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class TransformSet
    {
        public List<Transform> transforms;

        public Scale scale;
        public TransformSet(Scale pscale, bool full)
        {
            transforms = new List<Transform>();
            scale = pscale;

            int gcnt = 0;
            int pcnt = 0;

            for(int term = 0; term < scale.n; term++)
            {
                for(int factor = 1; factor < scale.n; factor++)
                {
                    if(GCD(factor, scale.n) == 1)
                    {
                        gcnt++;
                        // a polarity function will have p(p(k)) = k; 
                        // t + f * (t + f * k)) = (t+1)*f + f*f*k
                        // so f*f mod n = 1
                        // (f+1)*t mod n = 0
                        Transform t = new Transform(scale, factor, term);
                        if (full)
                        {
                            transforms.Add(t);
                        }
                        else
                        {
                            if ((factor * factor) % scale.n == 1
                                && ((factor + 1) * term) % scale.n == 0)
                            {

                                bool nfp = true;
                                for (int i = 0; nfp && i < scale.n; i++)
                                {
                                    if (i == t.Apply(i))
                                    {
                                        nfp = false;
                                    }
                                }

                                if (nfp)
                                {
                                    pcnt++;
                                   // Console.WriteLine(string.Format("{0} + {1} * k", term, factor));

                                    transforms.Add(t);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(string.Format("{0} transforms in set", transforms.Count));
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
