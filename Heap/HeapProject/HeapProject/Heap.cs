using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapProject
{
   public class Heap
    {
        private int[] a;
        private int n;

        public Heap()
        {
            a = new int[10];
            n = 0;
            a[0] = 99999;
        }

        public Heap(int maxSize)
        {
            a = new int[maxSize];
            n = 0;
            a[0] = 99999;
        }

        public void Insert(int value)
        {
            n++;
            a[n] = value;
            RestoreUp(n);
        }

        private void RestoreUp(int i)
        {
            int k = a[i];
            int iParent = i / 2;

            while(a[iParent] < k) //if no sentinel value the while condition will be- while(iParent>=1 && a[iParnet]<k)
            {
                a[i] = a[iParent];
                i = iParent;
                iParent = i / 2;
            }

            a[i] = k;
        }

        public int DeleteRoot()
        {
            if (n == 0)
            {
                throw new InvalidOperationException("Heap is empty");

            }

            int maxValue = a[1];
            a[1] = a[n];
            n--;
            RestoreDown(1);
            return maxValue;
        }

        private void RestoreDown(int i)
        {
            int k = a[i];
            int lchild = 2 * i;
            int rchild = lchild + 1;

            while (rchild<=n)
            {
                if(k >= a[lchild] && k >= a[rchild])
                {
                    a[i] = k;
                    return;
                }
                else if(a[lchild] > a[rchild])
                {
                    a[i] = a[lchild];
                    i = lchild;
                }
                else
                {
                    a[i] = a[rchild];
                    i = rchild;
                }
                lchild = 2 * i;
                rchild = lchild + 1;
            }

            //if number of nodes is even
            if(lchild==n && k<a[lchild])
            {
                a[i] = a[lchild];
                i = lchild;
            }
            a[i] = k;
        }
    }
}
