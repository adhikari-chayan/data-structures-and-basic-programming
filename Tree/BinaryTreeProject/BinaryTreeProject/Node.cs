using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeProject
{
   public class Node
    {
        public Node lchild;
        public char info;
        public Node rchild;

        public Node(char ch)
        {
            info = ch;
            lchild = null;
            rchild = null;
        }
    }
}
