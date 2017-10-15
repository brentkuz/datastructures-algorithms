using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrucuresAndAlgorithms.CrackingTheCodingInterview.LinkedLists
{
    public static class LL
    {
        //reverse 
        public static Node<int> ReverseSingle(Node<int> n)
        {
            Node<int> curr = n,
                prev = null;
            while (curr != null)
            {
                var t = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = t;
            }
            return prev;
        }
        public static Node<int> ReverseRecurse(Node<int> n, Node<int> prev)
        {
            if (n.Next == null)
            {
                n.Next = prev;
                return n;
            }
            var t = n.Next;
            n.Next = prev;
            prev = n;
            return ReverseRecurse(t, prev);
        }
        public static Node<int> Reverse(Node<int> head)
        {
            Node<int> curr = head,
                prev = null,
                next = null;
            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }
            head = prev;
            return head;
        }

        //Remove dupes from unsorted linked list
        public static void DeDupe(LinkedList<int> ll)
        {
            var hash = new Dictionary<int, bool>();
            Node<int> n = ll.Head;
            Node<int> prev = null;
            while (n != null)
            {
                if (hash.Keys.Contains(n.Value))
                {
                    prev.Next = n.Next;
                }
                else
                {
                    hash.Add(n.Value, true);
                }
                prev = n;
                n = n.Next;
            }
        }
        //Find kth to last node
        public static string KthToLast(LinkedList<int> ll, int k)
        {
            string[] kth = new string[] { null };
            if (ll.Head == null)
                return null;
            KTL(ll.Head, k, kth);
            return kth[0];
        }
        private static int KTL(Node<int> n, int k, string[] kth)
        {
            if (n.Next != null)
                k = KTL(n.Next, k, kth);


            if (k == 1)
            {
                kth[0] = n.Value.ToString();
                return n.Value;
            }
            else
                return --k;

        }
        //Delete node from linked list when you only have access to that node;
        public static void DeleteNode(Node<int> n)
        {
            if (n.Next == null)
                throw new ArgumentException("Cannot delete tail.");
            n.Value = n.Next.Value;
            n.Next = n.Next.Next;
        }
        //Partition linked list around x node
        public static void Partition(LinkedList<int> ll, int x)
        {
            Node<int> before = null;
            Node<int> beforeEnd = null;
            Node<int> after = null;
            Node<int> afterEnd = null;
            Node<int> n = ll.Head;
            while (n != null)
            {

                var t = new Node<int>(n.Value, null);
                if (n.Value < x)
                {
                    if (before == null)
                    {

                        before = t;
                        beforeEnd = t;
                    }
                    else
                    {
                        beforeEnd.Next = t;
                        beforeEnd = t;
                    }
                }
                else
                {
                    if (after == null)
                    {
                        after = t;
                        afterEnd = t;
                    }
                    else
                    {
                        afterEnd.Next = t;
                        afterEnd = t;
                    }
                }
                n = n.Next;
            }
            beforeEnd.Next = after;
            ll.Head = before;
        }
        //Calculate the sum of two numbers stored in reverse ordered linked lists
        public static Node<int> SumLists(Node<int> n1, Node<int> n2)
        {
            Node<int> total = null;
            Node<int> totalEnd = null;
            int carry = 0;
            Node<int> i1 = n1, i2 = n2;
            while (i1 != null || i2 != null || carry != 0)
            {
                int sum = 0;
                if (i1 == null && i2 == null)
                {
                    sum = carry;
                    totalEnd.Next = new Node<int>(sum, null);
                    break;
                }
                else
                {
                    sum = i1.Value + i2.Value + carry;

                    carry = sum / 10;
                    sum = sum % 10;


                    var x = new Node<int>(sum, null);

                    if (total == null)
                        total = x;
                    else
                        totalEnd.Next = x;

                    totalEnd = x;


                    if (i1 != null)
                        i1 = i1.Next;
                    if (i2 != null)
                        i2 = i2.Next;
                }
            }
            return total;

        }
        //Check if Linked list is palindrome
        public static bool IsPalindrome(LinkedList<char> ll)
        {
            if (ll.Head == null)
                throw new ArgumentException("Linked List is null");
            var st = new Stack<char>();
            var fast = ll.Head;
            var slow = ll.Head;
            PushOnStack(ll.Head, st);
            return IsPalindrome(st, fast, slow);
        }
        private static bool IsPalindrome(Stack<char> st, Node<char> fast, Node<char> slow)
        {
            if (fast == null)
                return true;
            var x = st.Pop();
            if (x != slow.Value)
                return false;
            else
            {
                fast = fast.Next == null ? fast.Next : fast.Next.Next;
                return IsPalindrome(st, fast, slow.Next);
            }
        }
        private static void PushOnStack(Node<char> n, Stack<char> st)
        {
            if (n == null)
                return;

            while (n != null)
            {
                st.Push(n.Value);
                n = n.Next;
            }
        }
        //Given 2 singly linked lists, determine if intersect
        public static bool HasIntersect(Node<int> l1, Node<int> l2)
        {
            if (l1 == null || l2 == null)
                throw new ArgumentException("Null input");

            return Intersect(l1, l2);
        }
        private static bool Intersect(Node<int> l1, Node<int> l2)
        {
            if (l1.Next == null && l2.Next == null)
                return l1 == l2;

            return Intersect(l1.Next == null ? l1 : l1.Next, l2.Next == null ? l2 : l2.Next);
        }
        //Check for cycle in linked list
        public static int HasCycle(Node<int> ll)
        {
            var fast = ll;
            var slow = ll;
            int res = -1;
            while (fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (fast == slow)
                {
                    res = fast.Value;
                    break;
                }
            }
            return res;
        }

    }


    public class LinkedList<T> where T : IComparable
    {
        public LinkedList(Node<T> head)
        {
            Head = head;
        }

        public Node<T> Head { get; set; }

        public void AddToTail(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value, null);
                return;
            }
            var n = Head;
            while (n.Next != null)
            {
                n = n.Next;
            }
            n.Next = new Node<T>(value, null);
        }
        public Node<T> Delete(T value)
        {
            var n = Head;
            while (n.Next != null)
            {
                if (n.Next.Value.CompareTo(value) == 0)
                {
                    n.Next = n.Next.Next;
                    return Head;
                }
                n = n.Next;
            }
            return Head;
        }
        public Node<T> GetNode(T value)
        {
            var n = Head;

            while (n != null)
            {
                if (n.Value.CompareTo(value) == 0)
                    return n;
                n = n.Next;
            }
            return null;
        }
    }
    public class DLinkedList<T> where T : IComparable
    {
        public DLinkedList(Node<T> head)
        {
            Head = head;
        }

        public Node<T> Head { get; set; }

        public void AddToTail(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value, null);
                return;
            }
            var n = Head;
            while (n.Next != null)
            {
                n = n.Next;
            }
            n.Next = new Node<T>(value, null);
        }
        public Node<T> Delete(T value)
        {
            var n = Head;
            while (n.Next != null)
            {
                if (n.Next.Value.CompareTo(value) == 0)
                {
                    n.Next = n.Next.Next;
                    return Head;
                }
                n = n.Next;
            }
            return Head;
        }
        public Node<T> GetNode(T value)
        {
            var n = Head;

            while (n != null)
            {
                if (n.Value.CompareTo(value) == 0)
                    return n;
                n = n.Next;
            }
            return null;
        }

    }
    public class Node<T> where T : IComparable
    {
        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }
        public T Value { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
    }

}
}
