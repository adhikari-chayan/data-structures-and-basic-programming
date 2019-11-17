using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeFromInorderAndPreOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            char[] arr = new char[] { 'D', 'B', 'E', 'A', 'F', 'C' };
            char[] pre = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' };
            int len = arr.Length;
            Node root = tree.BuildTree(arr, pre, 0, len - 1);

            // building the tree by printing inorder traversal 
            Console.WriteLine("Inorder traversal of "
                              + "constructed tree is : ");
            tree.printInorder(root);

            Console.ReadKey();
        }
        /* This funtcion is here just to test buildTree() */
     

    }
    public class BinaryTree
    {
        public Node root;
        public static int preIndex = 0;

        public Node BuildTree(char[] inOrder,char[] preOrder,int inOrderStart,int inOrderEnd)
        {
            if(inOrderStart>inOrderEnd)
            {
                return null;
            }
            /* Pick current node from Preorder traversal 
     using preIndex and increment preIndex */
            Node tNode = new Node(preOrder[preIndex++]);

            /* If this node has no children then return */
            if (inOrderStart == inOrderEnd)
                return tNode;

            int inOrderIdx = Search(inOrder, inOrderStart, inOrderEnd, tNode.data);

            tNode.left = BuildTree(inOrder, preOrder, inOrderStart, inOrderIdx - 1);
            tNode.right = BuildTree(inOrder, preOrder, inOrderIdx + 1, inOrderEnd);

            return tNode;
        }

        private int Search(char[] inOrder, int inOrderStart, int inOrderEnd, char data)
        {
            int i;
            for(i=inOrderStart;i<=inOrderEnd;i++)
            {
                if (inOrder[i] == data)
                    return i;
            }
            return i;
        }

        public void printInorder(Node node)
        {
            if (node == null)
            {
                return;
            }

            /* first recur on left child */
            printInorder(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");

            /* now recur on right child */
            printInorder(node.right);
        }
    }

    public class Node
    {
        public char data;
        public Node left;
        public Node right;

        public Node(char item)
        {
            data = item;
            left = right = null;
        }


             
    }
}
