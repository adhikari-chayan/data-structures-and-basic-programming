using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeProject
{
   public class Node
    {
        public Node lchild;
        public int info;
        public Node rchild;

        public Node(int i)
        {
            info = i;
            lchild = null;
            rchild = null;
        }
    }
}
