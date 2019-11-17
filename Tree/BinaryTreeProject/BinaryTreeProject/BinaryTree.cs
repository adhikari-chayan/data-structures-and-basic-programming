using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeProject
{
   public class BinaryTree
    {
        private Node root;
        public BinaryTree()
        {
            root = null;
        }
        public void CreateTree()
        {
            root = new Node('P');
            root.lchild = new Node('Q');
            root.rchild = new Node('R');
            root.lchild.lchild = new Node('A');
            root.lchild.rchild = new Node('B');
            root.rchild.lchild = new Node('X');
        }

        public void Display()
        {
            Display(root, 0);
            Console.WriteLine();
        }

        private void Display(Node p, int level)
        {
            if (p == null)
                return;
            Display(p.rchild, level + 1);
            Console.WriteLine();

            for(int i=0;i<level;i++)
                Console.Write("    ");
            Console.Write(p.info);

            Display(p.lchild, level + 1);

        }

        public void Preorder()
        {
            Preorder(root);
            Console.WriteLine();
        }

        private void Preorder(Node p)
        {
            if (p == null)
                return;

            Console.Write(p.info+" ");
            Preorder(p.lchild);
            Preorder(p.rchild);
        }

        public void Inorder()
        {
            Inorder(root);
            Console.WriteLine();
        }

        private void Inorder(Node p)
        {
            if (p == null)
                return;
            Inorder(p.lchild);
            Console.Write(p.info+" ");
            Inorder(p.rchild);
        }

        public void Postorder()
        {
            Postorder(root);
            Console.WriteLine();
        }

        private void Postorder(Node p)
        {
            if (p == null)
                return;
            Postorder(p.lchild);
            Postorder(p.rchild);
            Console.Write(p.info+" ");
        }

        public void LevelOrder()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node p;
            while (q.Count() != 0)
            {
                p = q.Dequeue();
                Console.Write(p.info + " ");
                if (p.lchild != null)
                    q.Enqueue(p.lchild);
                if (p.rchild != null)
                    q.Enqueue(p.rchild);
            }

            Console.WriteLine();
        }

        public int Height()
        {
            return Height(root);
            
        }

        private int Height(Node p)
        {
            if (p == null)
                return 0;

            int hL = Height(p.lchild);
            int hR = Height(p.rchild);

            if (hL > hR)
                return 1 + hL;
            else
                return 1 + hR;
        }
    }
}
