using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueProject
{
   public class Node
    {
        public int priority;
        public int info;
        public Node link;

        public Node(int i, int pr)
        {
            info = i;
            priority = pr;
            link = null;
        }
    }
}
