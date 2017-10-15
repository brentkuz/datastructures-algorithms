using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class VaildateBST
    {
        private const string ERROR = "Invalid";
        private bool isValid = true;

        public VaildateBST(BinaryNode<int> root)
        {
            try
            {
                isValid = Validate(root, null, null);
            }
            catch(Exception ex)
            {
                if (ex.Message.Equals(ERROR))
                    isValid = false;
            }
        }

        public bool IsValid() { return isValid; }

        private bool Validate(BinaryNode<int> n, int? min, int? max)
        {
            if (n == null)
                return true;

            if ((min != null && n.Key <= min) || (max != null && n.Key > max))
                return false;
            if (!Validate(n.Left, min, n.Key) || !Validate(n.Right, n.Key, max))
                return false;

            return true;
        }
    }
}
