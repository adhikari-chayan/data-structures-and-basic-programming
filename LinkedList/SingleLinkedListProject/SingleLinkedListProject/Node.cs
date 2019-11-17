using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedListProject
{
   public class Node
    {
        public int info;
        public Node link;

        public Node(int i)
        {
            info = i;
            link = null;
        }


    }
}
