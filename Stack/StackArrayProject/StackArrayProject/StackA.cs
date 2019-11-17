using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackArrayProject
{
    public class StackA
    {
        private int[] stackArray;
        private int top;

        public StackA()
        {
            stackArray = new int[10];
            top = -1;
        }

        public StackA(int maxSize)
        {
            stackArray = new int[maxSize];
            top = -1;

        }

        public int Size()
        {
            return top + 1;
        }

        public bool IsFull()
        {
            return (top == stackArray.Length - 1);
        }

        public bool IsEmpty()
        {
            return (top == -1);
        }

        public void Push(int x)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            top = top + 1;
            stackArray[top] = x;
        }

        public int Pop()
        {
            int x;
            if (IsEmpty())
                throw new System.InvalidOperationException("Stack Underflow");

            x = stackArray[top];
            top--;
            return x;
        }

        public int Peek()
        {
            if(IsEmpty())
                throw new System.InvalidOperationException("Stack Underflow");

            return stackArray[top];
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            Console.WriteLine("Stack is: ");
            for (int i=top;i>=0;i--)
                Console.WriteLine(stackArray[i]+" ");

            Console.WriteLine();

        }
    }
}
