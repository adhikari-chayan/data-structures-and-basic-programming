﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueArrayProject
{
   public class QueueA
    {
        private int[] queueArray;
        private int front;
        private int rear;

        public QueueA()
        {
            queueArray = new int[10];
            front = -1;
            rear = -1;
        }

        public QueueA(int maxSize)
        {
            queueArray = new int[maxSize];
            front = -1;
            rear = -1;
        }

        public bool IsEmpty()
        {
            return (front == -1 || front == rear + 1);
        }

        public bool IsFull()
        {
            return (rear == queueArray.Length - 1);
        }

        public int Size()
        {
            if (IsEmpty())
                return 0;
            else
                return rear - front + 1;
        }

        public void Enqueue(int x)
        {
            if(IsFull())
            {
                Console.WriteLine("Queue Overflow");
                return;
            }
            if (front == -1)
                front = 0;

            rear = rear + 1;
            queueArray[rear] = x;
        }

        public int Dequeue()
        {
            int x;
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue Underflow");
            x = queueArray[front];
            front = front + 1;
            return x;
        }

        public int Peek()
        {
            
            if (IsEmpty())
                throw new System.InvalidOperationException("Queue Underflow");
            return queueArray[front];
        }

        public void Display()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            for(int i=front;i<=rear;i++)
                Console.Write(queueArray[i]+" ");

            Console.WriteLine(); ;
        }

    }
}
