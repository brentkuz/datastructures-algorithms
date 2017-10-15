using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    public class MinStack
    {
        private Node[] st;
        private int top;

        public MinStack(int size)
        {
            st = new Node[size];
        }

        public void Push(int val)
        {
            if (top == 0)
            {
                st[top++] = new Node(val, val);
            }
            else
            {
                int m;
                if (val < Min())
                    m = val;
                else
                    m = Min();
                st[top++] = new Node(val, m);
            }
        }
        public int Pop()
        {
            if (top <= 0)
                throw new Exception("Stack is empty");
            var val = st[--top].Value;           
            return val;
        }
        public int Min()
        {
            if (top <= 0)
                throw new Exception("Stack is empty");
            return st[top-1].Min;
        }


        private class Node
        {
            public Node(int value, int min)
            {
                Value = value;
                Min = min;
            }
            public int Value { get; set; }
            public int Min { get; set; }
        }
    }
    
}
