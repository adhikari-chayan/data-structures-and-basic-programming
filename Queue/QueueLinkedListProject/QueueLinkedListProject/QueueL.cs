using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLinkedListProject
{
   public class QueueL
    {
        private Node front;
        private Node rear;

        public QueueL()
        {
            front = null;
            rear = null;
        }

        public int Size()
        {
            int s = 0;
            Node p = front;
            while(p!=null)
            {
                s++;
                p = p.link;
            }

            return s;
        }

        public bool IsEmpty()
        {
            return (front == null);
        }

        public void Enqueue(int x)
        {
            Node temp = new Node(x);
            if (front == null)
                front = temp;
            else
                rear.link = temp;
            rear = temp;
        }

        public int Dequeue()
        {
            int x;
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue underflow");

            x = front.info;
            front = front.link;

            return x;
        }

        public int Peek()
        {
            if(IsEmpty())
                throw new System.InvalidOperationException("Queue underflow");

            return front.info;
        }

        public void Display()
        {
            Node p = front;
            if(IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            Console.WriteLine("Queue is: ");
            while (p != null)
            {
                Console.Write(p.info+ " ");
                p = p.link;
            }

            Console.WriteLine();
        }
    }
}
