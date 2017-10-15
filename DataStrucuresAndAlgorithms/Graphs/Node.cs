using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Node<T> where T : struct
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

    }
}
