using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    public class BasicStack<T> where T : IComparable
    {
        private T[] vals;
        private int top;

        public BasicStack(int size)
        {
            vals = new T[size];
        }

        public void Push(T val)
        {
            if (IsFull())
                throw new StackOverflowException();
            vals[top++] = val;
        }
        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("Stack is empty");
            return vals[--top];
        }

        public bool IsFull()
        {
            return vals.Length <= top;
        }
        public bool IsEmpty()
        {
            return top <= 0;
        }

    }
}
