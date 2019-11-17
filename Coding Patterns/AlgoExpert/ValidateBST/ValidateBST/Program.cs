using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBST
{
    class Program
    {
        static void Main(string[] args)
        {
            //Node root = new Node(5);
            //root.left = new Node(14);
            //root.right = new Node(3);
            //root.left.left = new Node(6);
            //root.right.right = new Node(7);
            //root.left.left.left = new Node(9);
            //root.left.left.right = new Node(1);

            Node root = new Node(10);
            root.left = new Node(5);
            root.right = new Node(15);
            root.left.left = new Node(2);
            root.left.right = new Node(5);
            root.left.left.left = new Node(1);
            root.right.left = new Node(13);
            root.right.right = new Node(22);
            root.right.left.right = new Node(14);

            Console.WriteLine(IsBSTValid(root));
            Console.ReadKey();
        }


        public static bool IsBSTValid(Node root)
        {
            return ValidBST(root, int.MinValue, int.MaxValue);
        }
        private static bool ValidBST(Node node,int min,int max)
        {
            if (node == null)
                return true;
            if (node.data < min || node.data >= max)
                return false;
            if (ValidBST(node.left, min, node.data) && ValidBST(node.right, node.data, max))
                return true;
            else
                return false;
        }
    }

    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int value)
        {
            data = value;
        }
    }
}
