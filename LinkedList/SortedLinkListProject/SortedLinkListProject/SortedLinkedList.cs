using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedLinkListProject
{
   public class SortedLinkedList
    {
        private Node start;

        public SortedLinkedList()
        {
            start = null;
        }

        public void InsertInOrder(int data)
        {
            Node temp = new Node(data);
            
            //No nodes in list or data needed to be inserted is less that info value of 1st node
            if(start==null||data < start.info)
            {
                temp.link = start;
                start = temp;
                return;
            }

            Node p = start;
            while (p.link != null && p.link.info <= data)
                p = p.link;

            temp.link = p.link;
            p.link = temp;
        }

        public void CreateList()
        {
            int i, n, data;
            Console.Write("Enter the number of nodes: ");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;

            for(i=1;i<=n;i++)
            {
                Console.Write("Enter the element to be inserted: ");
                data = Convert.ToInt32(Console.ReadLine());
                InsertInOrder(data);
            }
        }

        public void Search(int x)
        {
            if(start==null)
            {
                Console.WriteLine("List is empty");
                return;

            }

            Node p = start;
            int position = 1;
            while(p!=null && p.info==x)
            {
                if (p.info == x)
                    break;

                position++;
                p = p.link;
            }

            if(p==null||p.info!=x)
                Console.WriteLine($"{x} not found in list");
            else
                Console.WriteLine($"{x} is present in position {position}");
        }
    }
}
