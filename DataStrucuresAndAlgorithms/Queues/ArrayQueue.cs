using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagStackQueueLinkedList
{
    public class ArrayQueue<T> : IEnumerable<T> where T : struct
    {
        private T[] items = new T[1];
        private int n = 0;

        public bool IsEmpty()
        {
            return n == 0;
        }
        public int Count { get { return n; } }
        public void Enqueue(T item)
        {
            if (n == items.Length)
                Resize(2 * items.Length);
            items[n++] = item;
        }
        public T Dequeue()
        {
            T item = default(T);
            if (n > 0)
            {
                item = items[0];
                items[0] = default(T);
                Shift();
                if (items.Length / 4 == n)
                    Resize(items.Length / 2);
                n--;
            }
            return item;
        }

        private void Shift()
        {
            var temp = new T[n];
            for (var i = 0; i < n; i++)
            {
                temp[i] = items[i + 1];
            }
            items = temp;
        }
        private void Resize(int cap)
        {
            var temp = new T[cap];
            for (var i = 0; i < n; i++)
            {
                temp[i] = items[i];
            }
            items = temp;
        }

        #region IEnumerator, IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < n; i++)
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
