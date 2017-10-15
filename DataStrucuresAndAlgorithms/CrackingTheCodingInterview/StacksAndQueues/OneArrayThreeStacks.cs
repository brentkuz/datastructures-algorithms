using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    public class TrippleStack<T> where T : IComparable
    {
        private const int SHIM = 3;
        private T[] q;
        private int[] tops;

        public TrippleStack(int size)
        {
            q = new T[size * 3];
            tops = new int[3];
            tops[0] = -3;
            tops[1] = -2;
            tops[2] = -1;
        }

        public void Push(int stackKey, T value)
        {
            if (stackKey < 0 || stackKey >= tops.Length)
                throw new ArgumentException("Invalid stack key");

            tops[stackKey] += SHIM;
            var idx = tops[stackKey];
            q[idx] = value;            
        }
        public T Pop(int stackKey)
        {
            if (stackKey < 0 || stackKey >= tops.Length)
                throw new ArgumentException("Invalid stack key");
            if (tops[stackKey] < 0)
                throw new Exception("Empty stack");

            var idx = tops[stackKey];
            var val = q[idx];
            q[idx] = default(T);
            tops[stackKey] -= SHIM;
            return val;
        }

        
    }
}
