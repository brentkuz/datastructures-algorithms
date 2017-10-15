using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class CheckBalanced
    {
        private List<int> depths = new List<int>();
        private int max = 0;

        public CheckBalanced(BinaryNode<int> root)
        {
            if (root == null)
                throw new ArgumentException("Null tree");
            int[] maxArr = new int[1] { 0 };
            int d = 0;
            //idx 0 - max depth
            Check(root, d, maxArr);
            max = maxArr[0];
        }

        public bool IsBalanced()
        {
            foreach(var d in depths)
            {
                if (Math.Abs(max - d) > 1)
                    return false;
            }
            return true;
        }

        private void Check(BinaryNode<int> n, int d, int[] max)
        {
            if(n == null)
            {
                if(!depths.Contains(d))
                    depths.Add(d);
                max[0] = d > max[0] ? d : max[0];
                return;
            }
            Check(n.Left, d + 1, max);
            Check(n.Right, d + 1, max);
        }
    }
}
