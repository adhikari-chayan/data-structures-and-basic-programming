using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueueProject
{
   public class CircularQueue
    {
        private int[] queueArray;
        private int front;
        private int rear;

        public CircularQueue()
        {
            queueArray = new int[10];
            front = -1;
            rear = -1;
        }

        public CircularQueue(int maxSize)
        {
            queueArray = new int[maxSize];
            front = -1;
            rear = -1;
        }

        public bool IsEmpty()
        {
            return (front == -1);
        }

        public bool IsFull()
        {
            return ((front == 0 && rear == queueArray.Length - 1) || (front == rear+ 1));
        }

        public void Enqueue(int x)
        {
            if (IsFull())
                throw new System.InvalidOperationException("Queue overflow");

            if (front == -1)
                front = 0;
            if (rear == queueArray.Length - 1)
                rear = 0;

            rear = rear + 1;
            queueArray[rear] = x;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue underflow");
            int x = queueArray[front];

            if (front == rear)//only one item in queue
            {
                front = -1;
                rear = -1;
            }
            else if (front == queueArray.Length - 1)
                front = 0;
            else
                front = front + 1;

            return x;

        }

        public int Peek()
        {
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue underflow");
            return queueArray[front];
        }

        public void Display()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            if(front<=rear)
            {
                for(int i=front;i<=rear;i++)
                {
                    Console.Write(queueArray[i]+" ");
                }
            }
            else
            {
                for(int i=front;i<=queueArray.Length-1;i++)
                {
                    Console.Write(queueArray[i] + " ");
                }
                for(int i=0;i<=rear;i++)
                {
                    Console.Write(queueArray[i] + " ");
                }
            }

            Console.WriteLine();
        }

        public int Size()
        {
            if (IsEmpty())
                return 0;
            if (IsFull())
                return queueArray.Length;

            int size = 0;


            if (front <= rear)
            {
                for (int i = front; i <= rear; i++)
                {
                    size++;
                }
            }
            else
            {
                for (int i = front; i <= queueArray.Length - 1; i++)
                {
                    size++;
                }
                for (int i = 0; i <= rear; i++)
                {
                    size++;
                }
            }

            return size;
        }
    }
}
