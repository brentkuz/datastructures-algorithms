using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    public class QueueFromStacks
    {
        private Stack<int> st;
        private Stack<int> rev;

        public QueueFromStacks()
        {
            st = new Stack<int>();
            rev = new Stack<int>();
        }

        public void Enqueue(int val)
        {
            st.Push(val);
        }
        public int Dequeue()
        {
            if (st.Count == 0)
                throw new Exception("Queue is empty");
            while (st.Count > 0)
                rev.Push(st.Pop());
            int val = rev.Pop();
            while (rev.Count > 0)
                st.Push(rev.Pop());

            return val;
        }

    }
}
