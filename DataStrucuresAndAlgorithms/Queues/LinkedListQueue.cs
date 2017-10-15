using BagStackQueueLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagStackQueueLinkedList
{
    public class LinkedListQueue<T> : IEnumerable<T> where T : struct
    {
        private Node<T> first = null;
        private Node<T> last = null;
        private int n = 0;
      
        public int Count { get { return n; } }
        public bool IsEmpty() { return first == null; }
        public void Enqueue(T item)
        {            
            var oldLast = last;
            last = new Node<T>();
            last.Item = item;
            last.Next = null;
            if (IsEmpty())
                first = last;
            else
                oldLast.Next = last;           
            n++;
        }
        public T Dequeue()
        {
            T item = first.Item;
            first = first.Next;
            n--;
            if (IsEmpty())
                last = null;

            return item;
        }


        public IEnumerator<T> GetEnumerator()
        {
            var item = first;

            while (item != null)
            {
                yield return item.Item;
                item = item.Next;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public class Node<t> where t : struct
        {
            public t Item { get; set; }
            public Node<t> Next { get; set; }

        }
    }
}
