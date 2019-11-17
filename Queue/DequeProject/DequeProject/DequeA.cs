using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DequeProject
{
   public class DequeA
    {
        private int[] queueArray;
        private int front;
        private int rear;

        public DequeA()
        {
            queueArray = new int[10];
            front = -1;
            rear = -1;
        }

        public DequeA(int maxSize)
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
            return ((front == 0 && rear == queueArray.Length - 1) || (front == rear + 1));
        }

        public void InsertFront(int x)
        {
            if (IsFull())
                throw new System.InvalidOperationException("Queue overflow");
            if (front == -1)
            {
                front = 0;
                rear = 0;
            }
            else if (front == 0)
                front = queueArray.Length - 1;
            else
                front = front - 1;
            queueArray[front] = x;
        }

        public void InsertRear(int x)
        {
            if(IsFull())
                throw new System.InvalidOperationException("Queue overflow");

            if (front == -1)
            {
                front = 0;
                
            }
            if (rear == queueArray.Length - 1)
                rear = 0;
            else
                rear = rear + 1;
            queueArray[rear] = x;
        }

        public int DeleteFront()
        {
            int x;
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue Underflow");

            x = queueArray[front];
            if(front==rear)
            {
                front = -1;
                rear = -1;
            }

            if (front == queueArray.Length - 1)
                front = 0;
            else
                front++;

            return x;
        }

        public int DeleteRear()
        {
            int x;
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue Underflow");

            x = queueArray[rear];
            if (front == rear)
            {
                front = -1;
                rear = -1;
            }

            if (rear ==0 )
                rear=queueArray.Length-1;
            else
                rear--;

            return x;
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            if (front <= rear)
            {
                for (int i = front; i <= rear; i++)
                {
                    Console.Write(queueArray[i] + " ");
                }
            }
            else
            {
                for (int i = front; i <= queueArray.Length - 1; i++)
                {
                    Console.Write(queueArray[i] + " ");
                }
                for (int i = 0; i <= rear; i++)
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
