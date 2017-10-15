//Comment tool used for comparing and benchmarking sort algs

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Comparer
    {
        private List<SortBase> sorts;
        

        public Comparer()
        {
            sorts = new List<SortBase>();
        }

        public void AddSort(SortBase sort)
        {
            sorts.Add(sort);
        }

        //Run comparison
        public void Run(IComparable[] set)
        {
            var stp = new Stopwatch();
            foreach(var s in sorts)
            {
                IComparable[] tmp = (IComparable[])set.Clone();
                stp.Start();
                s.Sort(tmp);
                stp.Stop();
                Display(s.Title, stp.ElapsedMilliseconds.ToString());
                stp.Reset();
            }

        }
        private void Display(string title, string et)
        {
            Console.WriteLine("{0}: {1}", title, et);
        }


    }
}
