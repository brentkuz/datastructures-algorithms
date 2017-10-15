using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class CheckStubtree
    {
        private bool isSubtree = false;

        //t1 is always larger than t2
        public CheckStubtree(BinaryNode<int> t1, BinaryNode<int> t2)
        {
            if (t1 == null || t2 == null)
                throw new ArgumentNullException();

            var q1 = new List<string>();
            var q2 = new List<string>();

            PreOrder(t1, q1);
            PreOrder(t2, q2);
            int idx = 0;
            foreach(var i in q1)
            {
                
                if(i == q2[idx])
                {
                    idx++;

                    if (idx == q2.Count)
                        break;
                    
                }
                else
                {
                    idx = 0;
                }
            }
            isSubtree = idx == q2.Count;

        }

        public bool IsSubtree { get { return isSubtree; } }

        private void PreOrder(BinaryNode<int> n, List<string> q)
        {
            if (n == null)
            {
                q.Add("X");
                return;
            }
            q.Add(n.Key.ToString());
            PreOrder(n.Left, q);
            PreOrder(n.Right, q);
        }

        

    }
}
