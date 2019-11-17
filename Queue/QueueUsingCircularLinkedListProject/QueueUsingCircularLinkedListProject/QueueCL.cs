using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingCircularLinkedListProject
{
   public class QueueCL
    {
        private Node rear;
        public QueueCL()
        {
            rear = null;    
        }

        public bool IsEmpty()
        {
            return (rear == null);
        }

        public void Enqueue(int x)
        {
            Node temp = new Node(x);
            if(IsEmpty())
            {
                rear = temp;
                rear.link = rear;
            }
            else
            {
                temp.link = rear.link;
                rear.link = temp;
                rear = temp;

            }
        
        }

        public int Dequeue()
        {
            int x;
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue Underflow");

            
            if(rear.link==rear)//single node in list
            {
                x = rear.info;                                     
                rear = null; 
            }
            else
            {
                x = rear.link.info;
                rear.link = rear.link.link;
            }

            return x;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue Underflow");

            return rear.link.info;
        }

        public void Display()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Queue Underflow");
                return;
            }
            Node p = rear.link;
            do
            {
                Console.Write(p.info + " ");
                p = p.link;
            } while (p != rear.link);

            Console.WriteLine();

        }

        public int Size()
        {
            int s = 0;
            if (IsEmpty())
                return s;
            Node p = rear.link;
            do
            {
                s++;
                p = p.link;
            } while (p != rear.link);
            return s;
        }

    }
}
