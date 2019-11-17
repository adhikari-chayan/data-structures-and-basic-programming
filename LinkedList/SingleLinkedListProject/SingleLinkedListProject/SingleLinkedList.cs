using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedListProject
{
   public class SingleLinkedList
    {
        private Node start;

        public SingleLinkedList()
        {
            start = null;
        }

        public void DisplayList()
        {
            Node p;
            if (start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            p = start;
            while(p!=null)
            {
                Console.Write(p.info+" ");
                p = p.link;
            }

            Console.WriteLine();
        }

        public void CountNodes()
        {
            int n = 0;
            Node p = start;
            
            while(p!=null)
            {
                n++;
                p = p.link;
            }
            Console.WriteLine("Number of nodes in the list= "+n );
        }

        public bool Search(int x)
        {
            int position = 1;
            Node p = start;

            while(p!=null)
            {
                if (x == p.info)
                    break;
                position++;
                p = p.link;

            }
            if(p==null)
            {
                Console.WriteLine(x+ " is not found in list");
                return false;
            }
            else
            {
                Console.WriteLine(x+ " is found in position "+position);
                return true;
            }
        }

        public void InsertInBeginning(int data)
        {
            Node temp = new Node(data);
            temp.link = start;
            start = temp;

        }

        public void InsertAtEnd(int data)
        {
            Node temp = new Node(data);
            Node p;

            if(start==null)
            {
                start = temp;
                return;
            }

            p = start;
            while(p.link!=null)
            {
                p = p.link;
            }
            p.link = temp;
        }

        public void CreateList()
        {
            int n, data;
            Console.Write("Enter the number of nodes: ");
            n = Convert.ToInt32(Console.ReadLine());

            for(int i = 1; i<=n;i++)
            {
                Console.Write("Enter the element to be inserted: ");
                data = Convert.ToInt32(Console.ReadLine());
                InsertAtEnd(data);
            }
        }

        public void InsertAfter(int data,int x)
        {
            Node p = start;

            while(p!=null)
            {
                if (p.info == x)
                    break;
                p = p.link;
            }

            if(p==null)
            {
                Console.WriteLine(x+" is not present in the list");
            }
            else
            {
                Node temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void InsertBefore(int data,int x)
        {
            Node temp;

            if(start==null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            if(start.info==x)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
                return;
            }

            Node p = start;
            while(p.link!=null)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }

            if(p.link==null)
            {
                Console.WriteLine(x + " is not present in the list");
            }
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void InsertAtPosition(int data,int k)
        {
            Node temp;
            int i = 1;
            if(k==1)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
                return;
            }

            Node p = start;
            for(i=1;i<k-1 && p!=null;i++)
            {
                p = p.link;
            }

            if(p==null)
            {
                Console.WriteLine("You can insert upto the "+i+"th position only");
            }
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void DeleteFirstNode()
        {
            if (start == null)
                return;

            start = start.link;
        }

        public void DeleteLastNode()
        {
            if (start == null)
                return;
            if(start.link==null)
            {
                start = null;
                return;
            }

            Node p = start;
            while(p.link.link!=null)
            {
                p = p.link;
            }

            p.link = null; 
        }

        public void DeleteNode(int x)
        {
            if(start==null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            if(start.info==x)
            {
                start = start.link;
                return;
            }

            Node p = start;
            while(p.link!=null)
            {
                if (p.link.info == x)
                    break;

                p = p.link;
            }

            if (p.link == null)
            {
                Console.WriteLine(x + " is not in list");
            }
            else
            {
                p.link = p.link.link;
            }

        }

        public void ReverseList()
        {
            Node p, next, prev;
            prev = null;

            p = start;
            while(p!=null)
            {
                next = p.link;
                p.link = prev;
                prev = p;
                p = next;
            }

            start = prev;

        }

        public void BubbleSortExData()
        {
            Node p, q, end;

            for(end=null;end != start.link;end=p)
            {
                //for(p=start;p.link==end;p=p.link)
                p = start;
                while (p.link!=end)
                {
                    q = p.link;
                    if(p.info > q.info)
                    {
                        int temp = p.info;
                        p.info = q.info;
                        q.info = temp;
                    }
                    p = p.link;
                }
            }
        }

        public SingleLinkedList Merge1(SingleLinkedList list)
        {
            SingleLinkedList mergeList = new SingleLinkedList();
            mergeList.start = Merge1(start, list.start);
            return mergeList;
        }

        private Node Merge1(Node p1, Node p2)
        {
            Node startM;
            if(p1.info<=p2.info)
            {
                startM = new Node(p1.info);
                p1 = p1.link;
            }
            else
            {
                startM = new Node(p2.info);
                p2 = p2.link;

            }
            Node pM = startM;

            while (p1!=null && p2!=null)
            {
                if(p1.info<=p2.info)
                {
                    pM.link = new Node(p1.info);
                    p1 = p1.link;
                }
                else
                {
                    pM.link = new Node(p2.info);
                    p2 = p2.link;
                }
                pM = pM.link;
            }

            //2nd list has finished but elements are left in the 1st list
            while(p1!=null)
            {
                pM.link = new Node(p1.info);
                p1 = p1.link;
                pM = pM.link;
            }


            //1st list has finished but elements are left in the 2nd list
            while (p2 != null)
            {
                pM.link = new Node(p2.info);
                p2 = p2.link;
                pM = pM.link;
            }

            return startM;
        }

        public SingleLinkedList Merge2(SingleLinkedList list)
        {
            SingleLinkedList mergeList = new SingleLinkedList();
            mergeList.start = Merge2(start, list.start);
            return mergeList;
        }

        private Node Merge2(Node p1, Node p2)
        {
            Node startM;
            if(p1.info<=p2.info)
            {
                startM = p1;
                p1 = p1.link;
            }
            else
            {
                startM = p2;
                p2 = p2.link;
            }

            Node pM = startM;
            while(p1!=null && p2!=null)
            {
                if(p1.info<=p2.info)
                {
                    pM.link = p1;
                    pM = pM.link;
                    p1 = p1.link;
                }
                else
                {
                    pM.link = p2;
                    pM = pM.link;
                    p2 = p2.link;
                }
            }
            //1st list has ended but there is item in 2nd list
            if (p1 == null)
                pM.link = p2;
            else
                pM.link = p1;

            return startM;
        }

        public bool HasCycle()
        {
            if (FindCycle() == null)
                return false;
            else
                return true;
        }

        private Node FindCycle()
        {
            //empty or single node linked list
            if(start==null||start.link==null)
            {
                return null;
            }

            Node slowR = start;
            Node fastR = start;
            //loop will be terminated if the list is null terminated.1st condition is for even no. of nodes 2nd is for odd
            while(fastR!=null && fastR.link!=null)
            {
                slowR = slowR.link;
                fastR = fastR.link.link;
                if (slowR == fastR)
                    return slowR;
            }
            return null;
        }

        public void RemoveCycle()
        {
            Node c = FindCycle();
            if (c == null)
                return;
            Console.WriteLine($"Node at which cycle was detected is {c.info}");

            Node p = c;
            Node q = c;
            int lenCycle = 0;

            do
            {
                lenCycle++;
                q = q.link;
        
            } while (p != q);
            Console.WriteLine($"Number of nodes in cycle is {lenCycle}");

            p = start;
            int lenRemList = 0;
            while(p!=q)
            {
                lenRemList++;
                p = p.link;
                q = q.link;
            }

            Console.WriteLine($"Number of nodes not in cycle is {lenRemList}");

            int lengthList = lenCycle + lenRemList;
            Console.WriteLine($"Length of the list is {lengthList}");


            p = start;
            for(int i=1;i<=lengthList-1;i++)
            {
                p = p.link;
            }
            p.link = null;
        }

        public void InsertCycle(int x)
        {
            if (start == null)
                return;
            Node p = start;
            Node prev = null;
            Node px = null;

            while(p!=null)
            {
                if (p.info == x)
                    px = p;
                prev = p;
                p = p.link;
            }
            if (px != null)
                prev.link = px;
            else
                Console.WriteLine($"{x} not present in list");
        }
    }
}
