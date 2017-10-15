using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    public class SortStack
    {
        
        public void Sort(Stack<int> stack)
        {
            
            var r = new Stack<int>();
                 
            while (!stack.IsEmpty())
            {
                var t = stack.Pop();
                while (!r.IsEmpty() && t < r.Peek())
                    stack.Push(r.Pop());
                r.Push(t);
            }

            while (!r.IsEmpty())
            {
                stack.Push(r.Pop());
            }
            
        }
    }

    public static class Ext
    {
        public static bool IsEmpty(this Stack<int> stack)
        {
            return stack.Count() == 0;
        }
    }
}
