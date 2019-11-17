using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeProject
{
   public class BinarySearchTree
    {
        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        //iterative
        public bool Search1(int x)
        {
            Node p = root;
            while (p != null)
            {
                if (x < p.info)
                    p = p.lchild;//move to left child
                else if (x > p.info)
                    p = p.rchild;//move to right child
                else //match found
                    return true;
            }
            //if not foudd we have reached a empty node 
            return false;
        }

        //recursive
        public bool Search(int x)
        {
            return (Search(root, x) != null);
        }

        private Node Search(Node p, int x)
        {
            if (p == null)
                return null; //key not found
            if (x > p.info)
                Search(p.rchild, x);//Search in right subtree
            if (x < p.info)
                Search(p.lchild, x);//Search in left subtree
            return p;//key is found
        }

        //iterative
        public int Min1()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Tree is empty");
            Node p = root;
            while (p.lchild != null)
                p = p.lchild;
            return p.info;
        }

        //recursive
        public int Min()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Tree is empty");

            return Min(root).info;
        }

        private Node Min(Node p)
        {
            if (p.lchild == null)
                return p;
            return Min(p.lchild);
        }


        //iterative
        public int Max1()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Tree is empty");
            Node p = root;
            while (p.rchild != null)
                p = p.rchild;
            return p.info;
        }

        //recursive
        public int Max()
        {

            if (IsEmpty())
                throw new InvalidOperationException("Tree is empty");

            return Max(root).info;
        }

        private Node Max(Node p)
        {
            if (p.rchild == null)
                return p;

           return Max(p.rchild);
        }

        //iterative
        public void Insert1(int x)
        {
            Node p = root;
            Node par = null;
            while(p!=null)
            {
                par = p;
                if (x > p.info)
                    p = p.rchild;
                else if (x < p.info)
                    p = p.lchild;
                else
                {
                    Console.WriteLine($"{x} already present in tree");
                    return;
                }
            }

            Node temp = new Node(x);
            if (x > par.info)
                par.rchild = temp;
            else
                par.lchild = temp;
        }

        //recursive
        public void Insert(int x)
        {
            root = Insert(root, x);
        }

        private Node Insert(Node p, int x)
        {
            if (p == null)
                p = new Node(x);

            if (x > p.info)
                p.rchild = Insert(p.rchild, x);
            else if (x < p.info)
                p.lchild = Insert(p.lchild, x);
            else
                Console.WriteLine($"{x} is already present in tree");
            return p;
        }

        //iterative
        public void Delete1(int x)
        {
            Node p = root;
            Node par = null;

            while(p!=null)
            {
                if (p.info == x)
                    break;
                par = p;
                if (x > p.info)
                    p = p.rchild;
                else
                    p = p.lchild;
            }

            if(p==null)
            {
                Console.WriteLine($"{x} not found");
                return;
            }

            // Case C: 2 children 
            //Find inorder successor and its parent

            Node s, ps;
            if(p.lchild!=null && p.rchild!=null)
            {
                ps = p;
                s = p.rchild;
                while(s.lchild!=null)
                {
                    ps = s;
                    s = s.lchild;
                }
                p.info = s.info;
                //since inorder successor needs to be deleted
                p = s;
                par = ps;
            }

            //Case B and A: 1 or no child
            Node ch;
            if (p.lchild != null) //Node to be deleted has left child
                ch = p.lchild;
            else                  //Node to be deleted has right child   
                ch = p.rchild;


            if (par == null) //Node to be deleted is root node
                root = ch;
            else if (p == par.lchild) //Node is left child of its parent
                par.lchild = ch;
            else                      // Node is right child of its parent   
                par.rchild = ch;

        }
        //recursive
        public void Delete(int x)
        {
            root = Delete(root, x);
        }

        private Node Delete(Node p,int x)
        {
            Node ch, s;
            if(p==null)
            {
                Console.WriteLine($"{x} is not found");
                return p;
            }

            if (x < p.info)
                p.lchild = Delete(p.lchild, x);
            else if (x > p.info)
                p.rchild = Delete(p.rchild, x);
            else
            {
                if(p.lchild!=null && p.rchild !=null)//two children
                {
                    s = p.rchild;
                    while(s.lchild!=null)
                    {
                        s = s.lchild;
                    }
                    p.info = s.info;
                    p.rchild = Delete(p.rchild, s.info);
                }
                else
                {
                    if (p.lchild != null)
                        ch = p.lchild;
                    else
                        ch = p.rchild;
                    p = ch;
                }
            }
            return p;
        }
    }
}
