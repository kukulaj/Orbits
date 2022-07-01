using System;
using System.Collections.Generic;
using System.Text;

namespace Orbits
{
    public class IntervalSet
    {
        public Scale scale;
        public bool[] intervals;

        public IntervalSet(Scale pscale)
        {
            scale = pscale;
            intervals = new bool[scale.n];
        }
        public IntervalSet(Scale pscale, int n) : this(pscale)
        {
            for (int i = 0; i < n; i++)
            {
                intervals[i] = true;
            }

        }

        public IntervalSet(Scale pscale, Transform p) : this(pscale)
        {
            Console.Write("build dichotomy with ");
            Console.WriteLine(p.Name());

            IntervalSet complement = new IntervalSet(scale);

            bool found = true;
           
            while (found)
            {
                found = false;

                int look = scale.rand.Next(scale.n);
                int looked = 0; 
                while(!found && looked < scale.n)
                {
                     
                    if(!intervals[look] && !complement.intervals[look])
                    {
                        found = true;
                    }
                    else 
                    {
                        looked++;
                        look = (look + 1) % scale.n;
                    }
                }

                if(found)
                {
                    intervals[look] = true;
                    complement.intervals[p.Apply(look)] = true;
                }
            }

            int ocnt = OnCount();
            if (ocnt != scale.n / 2)
            {
                Console.WriteLine("on count error");
            }

            IntervalSet set2 = p.Apply(this);
            if (!Complement(set2))
            {
                Console.WriteLine("oops");
            }
        }

        public int OnCount()
        {
            int cnt = 0;
            for (int i = 0; i < scale.n; i++)
            {
                if (intervals[i])
                {
                    cnt++;
                }
            }
            return cnt;
        }
        public string Name()
        {
            string result = "{";
            for (int i = 0; i < scale.n; i++)
            {
                if (intervals[i])
                {
                    result = result + string.Format(" {0}", i);
                }
            }
            return result + " }";
        }

        public IntervalSet Randomize(int n)
        {
            IntervalSet result = new IntervalSet(scale);

            for (int i = 0; i < n; i++)
            {
                int t = scale.rand.Next(scale.n);
                while (result.intervals[t])
                {
                    t = (t + 1) % scale.n;
                }
                result.intervals[t] = true;
            }
            return result; 
        }
        public IntervalSet Step()
        {
            IntervalSet result = new IntervalSet(scale);

            int i = scale.n - 1;
            int ones = 0;

            while(intervals[i] && i >=0)
            {
                ones++;
                i--;
            }

            if(i < 1)
            {
                return null;
            }

            while((i >= 1 && !intervals[i]))
            {
                i--;
            }

            if (i < 1)
            {
                return null;
            }

            int move = i;
            i--;

            while (i >= 0)
            {
                result.intervals[i] = intervals[i];
                i--;
            }

            i = move + 1;
            result.intervals[i] = true;
            i++;

            while(ones > 0)
            {
                result.intervals[i] = true;
                i++;
                ones--;
            }
            return result;
        }

        public bool Complement(IntervalSet other)
        {
            bool result = true;
            for (int i = 0; i < scale.n; i++)
            {
                if(intervals[i] == other.intervals[i])
                {
                    result =  false;
                }

            }

            return result;
        }
        public Transform Strong(TransformSet g)
        {
            Transform result = null;
            int pcnt = 0;
            
            foreach (Transform t2 in g.transforms)
            {
                        IntervalSet set2 = t2.Apply(this);

                if (Complement(set2))
                {
                    pcnt++;
                    result = t2;
                }
            }
            Console.WriteLine(string.Format("{0} polarity functions", pcnt));

            if (pcnt == 1)
            {
                Console.WriteLine(string.Format("polarity of {0}: {1}",
                    Name(),
                    result.Name()));
                return result;
            }

            return null;
        }

 
            
    

    }
}
