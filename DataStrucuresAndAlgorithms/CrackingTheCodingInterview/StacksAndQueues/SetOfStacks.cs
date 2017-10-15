using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    public class SetOfStacks<T> where T : IComparable
    {
        private List<BasicStack<T>> stacks;
        private int current = -1;
        private int threshold;

        public SetOfStacks(int threshold)
        {
            stacks = new List<BasicStack<T>>();
            this.threshold = threshold;
        }

        public void Push(T val)
        {
            if (current == -1 || stacks[current].IsFull())
            {
                stacks.Add(new BasicStack<T>(threshold));
                current++;
            }
            stacks[current].Push(val);
        }
        public T Pop()
        {
            if (current < 0)
                throw new Exception("Stack is empty");
           
            if(stacks[current].IsEmpty())
                stacks.RemoveAt(current--);     

            if (current < 0)
                throw new Exception("Stack is empty");
            else
                return stacks[current].Pop();
        }
        public T PopAt(int index)
        {
            if (index > stacks.Count - 1 || index < 0)
                throw new ArgumentOutOfRangeException("Index was out of range");
            if (stacks[index].IsEmpty())
                throw new Exception("The indexed stack is empty");

            var stack = stacks[index];
            T val = stack.Pop();

            if (stack.IsEmpty())
            {
                stacks.Remove(stack);
                current--;
            }
            return val;
        }

    }
}
