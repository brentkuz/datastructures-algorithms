using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagStackQueueLinkedList
{
    public class ArrayStack<T> : IEnumerable<T> where T : struct
    {

        private T[] items = new T[1];
        private int n = 0;
        


        public ArrayStack()
        {            
        }

        public bool IsEmpty()
        {
            return n == 0;
        }
        public int Count { get { return n; } }
        public void Push(T item)
        {
            if (n == items.Length)
                Resize(2 * items.Length);
            items[n++] = item;
        }
        public T Pop()
        {
            T item = default(T);
            if (n > 0)
            {
                item = items[--n];
                items[n] = default(T);
                if (items.Length / 4 == n)
                    Resize(items.Length / 2);
            }
            return item;
        }


        private void Resize(int cap)
        {
            var temp = new T[cap];
            for(var i = 0; i < n; i++)
            {
                temp[i] = items[i];
            }
            items = temp;
        }

        #region IEnumerator, IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Length -1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
