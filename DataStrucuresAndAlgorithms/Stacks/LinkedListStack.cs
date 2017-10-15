using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagStackQueueLinkedList
{

    public class LinkedListStack<T> : IEnumerable<T> where T : struct
    {
        private Node<T> first = null;
        private int n = 0;
        public LinkedListStack()
        {
        }

        public int Count { get { return n; } }
        public void Push(T item)
        {

            if (first == null)
            {
                first = new Node<T>();
                first.Item = item;
            }
            else
            {
                var oldFirst = first;
                first = new Node<T>();
                first.Item = item;
                first.Next = oldFirst;
            }
            n++;
        }
        public T Pop()
        {
            T item = default(T);
            if (n > 0)
            {
                item = first.Item;
                first = first.Next;
                n--;
            }
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
