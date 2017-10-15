using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{

    //Implementation of common methods
    public abstract class SortBase
    {
        public string Title { get; set; }
        public abstract void Sort(IComparable[] items);        

        protected bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }
        protected void Exch(IComparable[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }

    //O(n^2)
    public class SelectionSort : SortBase
    {
        public SelectionSort()
        {
            Title = "Selection Sort";
        }
        public override void Sort(IComparable[] items)
        {
            int n = items.Length;
            for (var i = 0; i < n; i++)
            {
                int min = i;
                for (var j = i + 1; j < n; j++)
                {
                    if (Less(items[j], items[min]))
                        min = j;
                }
                Exch(items, i, min);
            }
        } 

    }

    //O(n^2)
    public class InsertionSort : SortBase
    {
        public InsertionSort()
        {
            Title = "Insertion Sort";
        }
        public override void Sort(IComparable[] items)
        {
            int n = items.Length;
            for(var i = 1; i < n; i++)
            {
                for (var j = i; j > 0 && Less(items[j], items[j - 1]); j--)
                    Exch(items, j, j-1);
            }

        }
    }

    //O(n^2)
    public class ShellSort : SortBase
    {
        public ShellSort()
        {
            Title = "Shell Sort";
        }
        public override void Sort(IComparable[] items)
        {
            int n = items.Length;
            int h = n / 2;

            while (h >= 1)
            {
                for (var i = h; i < n; i++)
                {
                    for (var j = i; j >= h && Less(items[j], items[j - h]); j -= h)
                        Exch(items, j, j - h);
                }
                h = h / 2;
            }
        }
    }

    //O(nlog(n))
    public class TopDownMergeSort : SortBase
    {
        private IComparable[] aux;
        public TopDownMergeSort()
        {
            Title = "Top-Down Merge Sort";
        }
        public override void Sort(IComparable[] items)
        {
            aux = new IComparable[items.Length];
            Sort(items, 0, items.Length - 1);
        }
        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo)
                return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, lo, mid);
            Sort(a, mid + 1, hi);
            Merge(a, lo, mid, hi);
        }
        private void Merge(IComparable[] a, int lo, int mid, int hi)
        {
            int i = lo;
            int j = mid + 1;
            //copy to aux 
            for(int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }
            //merge back to a
            for(var k = lo; k <= hi; k++)
            {
                //left half exhausted,
                if (i > mid)
                    //take from right
                    a[k] = aux[j++];
                //right half exhausted, 
                else if (j > hi)
                    //take from left
                    a[k] = aux[i++];
                //current key on right < current key on left, 
                else if (Less(aux[j], aux[i]))
                    //take from right 
                    a[k] = aux[j++];
                //current key on right >= current key on left, 
                else
                    //take from left;
                    a[k] = aux[i++];
            }
        }
    }

    //O(nlog(n))
    public class BottomUpMergeSort : SortBase
    {
        private IComparable[] aux;
        public BottomUpMergeSort()
        {
            Title = "Bottom-Up Merge Sort";
        }
        public override void Sort(IComparable[] a)
        {
            int n = a.Length;
            aux = new IComparable[n];
            for (int sz = 1; sz < n; sz = sz+sz)
            {
                for (int lo = 0; lo < n-sz; lo += sz+sz)
                {
                    Merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, n - 1));
                }
            }
        }

        private void Merge(IComparable[] a, int lo, int mid, int hi)
        {
            int i = lo;
            int j = mid + 1;
            //copy to aux 
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }
            //merge back to a
            for (var k = lo; k <= hi; k++)
            {
                //left half exhausted,
                if (i > mid)
                    //take from right
                    a[k] = aux[j++];
                //right half exhausted, 
                else if (j > hi)
                    //take from left
                    a[k] = aux[i++];
                //current key on right < current key on left, 
                else if (Less(aux[j], aux[i]))
                    //take from right 
                    a[k] = aux[j++];
                //current key on right >= current key on left, 
                else
                    //take from left;
                    a[k] = aux[i++];
            }
        }
    }

    //O(n^2) - Average is O(nlog(n)), but when set is already sorted it's slow
    public class QuickSort : SortBase
    {
        public QuickSort()
        {
            Title = "Quick Sort";
        }
        public override void Sort(IComparable[] items)
        {
            //randomize
            Shuffle(items);
            Sort(items, 0, items.Length - 1);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }

        private int Partition(IComparable[] a, int lo, int hi)
        {
            //left/right scan indices
            int i = lo, 
                j = hi + 1;
            //pivot
            var v = a[lo];
            while(true)
            {
                //Scan right, scan left, check for scan complete, and exchange
                while (Less(a[++i], v))
                    if (i == hi) break;
                while (Less(v, a[--j]))
                    if (j == lo) break;
                if (i >= j) break;
                Exch(a, i, j);
            }
            Exch(a, lo, j);

            return j;
        }
        private void Shuffle(IComparable[] a)
        {
            var rnd = new Random();
            var res = a.OrderBy(i => rnd.Next()).ToArray();
            a = res;
        }
    }
}
