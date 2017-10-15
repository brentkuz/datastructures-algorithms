using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class MinHeap
    {
        private Nullable<int>[] heap;
        private int n;

        public MinHeap(int size)
        {
            heap = new Nullable<int>[size];
        }

        public void Insert(int? val)
        {
            heap[++n] = val;

            Swim(n);
        }
        public int? RemoveMin()
        {
            var val = heap[1];
            heap[1] = null;
            Exchange(1, n);

            Sink(1);

            return val;
        }

        private void Swim(int idx)
        {
            var j = idx / 2;
            while(heap[idx] < heap[j])
            {
                Exchange(idx, j);
                idx = j;
                j = idx / 2;
            }
        }
        private void Sink(int idx)
        {
            var j = idx * 2;
            while(heap[idx] > heap[j])
            {
                if (heap[j] > heap[j + 1])
                    j++;
                Exchange(idx, j);

                idx = j;
                j = idx * 2;
            }
        }
        private void Exchange(int i1, int i2)
        {
            var t = heap[i1];
            heap[i1] = heap[i2];
            heap[i2] = t;
        }

    }
}
