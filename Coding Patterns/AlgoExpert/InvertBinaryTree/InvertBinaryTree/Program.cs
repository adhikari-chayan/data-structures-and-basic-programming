using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertBinaryTree
{
    class Program
    {
        
        static void Main(string[] args)
        {
        }

        public static void InvertBinaryTree(BinaryTreeNode root)
        {
            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);
            BinaryTreeNode current;
            while (queue.Count()!=0)
            {
                current = queue.Dequeue();
                if (current == null)
                    continue;
                SwapLeftAndRight(current);
                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);
            }
        }

        public static void InverseBinaryTreeRecursive(BinaryTreeNode root)
        {
            if (root == null)
                return;
            SwapLeftAndRight(root);
            InverseBinaryTreeRecursive(root.left);
            InverseBinaryTreeRecursive(root.right);
        }

        private static void SwapLeftAndRight(BinaryTreeNode current)
        {
            BinaryTreeNode left = current.left;
            current.left = current.right;
            current.right = left;
        }
    }

    public class BinaryTreeNode
    {
        public int data;
        public BinaryTreeNode left;
        public BinaryTreeNode right;

        public BinaryTreeNode(int value)
        {
            data = value;
        }
    }

}
