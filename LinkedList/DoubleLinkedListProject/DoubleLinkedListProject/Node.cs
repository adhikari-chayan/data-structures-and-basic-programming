using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedListProject
{
   public class Node
    {
        public Node prev;
        public int info;
        public Node next;

        public Node(int i)
        {
            info = i;
            prev = null;
            next = null;
        }
    }
}
