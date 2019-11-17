using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueProject
{
   public class PriorityQueueL
    {
        private Node front;

        public PriorityQueueL()
        {
            front = null;
        }

        public bool IsEmpty()
        {
            return front == null;
        }

        public void Insert(int element,int elementPriority)
        {
            Node temp = new Node(element, elementPriority);

            if(IsEmpty() || elementPriority < front.priority)
            {
                temp.link = front;
                front = temp;
            }
            else
            {
                Node p = front;
                while(p.link!=null && p.link.priority <=elementPriority)
                {
                    p = p.link;
                }

                temp.link = p.link;
                p.link = temp;
            }
        }

        public int Delete()
        {
            int x;
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue underflow");
            else
            {
                x = front.info;
                front = front.link;
            }

            return x;
        }

        public void Display()
        {
            Node p = front;
            if(IsEmpty())
            {
                Console.WriteLine("Queue Underflow");
                return;
            }
            else
            {
                Console.WriteLine("Queue is: ");
                while (p != null)
                {
                    Console.WriteLine($"Priority:{p.priority}|Info:{p.info}");
                    p = p.link;
                }
            }

            Console.WriteLine();
        }
    }
}
