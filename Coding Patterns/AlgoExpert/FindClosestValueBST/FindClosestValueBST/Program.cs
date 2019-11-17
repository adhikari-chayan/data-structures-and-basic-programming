using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestValueBST
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(10);
            root.left = new Node(5);
            root.right = new Node(15);
            root.left.left = new Node(2);
            root.left.right = new Node(5);
            root.left.left.left = new Node(1);
            root.right.left = new Node(13);
            root.right.right = new Node(22);
            root.right.left.right = new Node(14);

            //var result = FindClosestInBST(root, 12);
            var result = FindClosest(root, 12);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int FindClosestInBST(Node root,int target)
        {
            int closest = int.MaxValue;
            Node currentNode = root;
            while(currentNode != null)
            {
                var currentDiff = Math.Abs(target - currentNode.data);
                var closestDiff = Math.Abs(closest - target);
                if(closestDiff > currentDiff)
                {
                    closest = currentNode.data;
                }
                if(target > currentNode.data)
                {
                    currentNode = currentNode.right;
                }
                else if(target<currentNode.data)
                {
                    currentNode = currentNode.left;
                }
                else
                {
                    return closest;
                }
            }
            return closest;

        }

        public static int FindClosest(Node root,int target)
        {
           return FindClosestInBSTRecursive(root, target, int.MaxValue);
        }
        public static int FindClosestInBSTRecursive(Node node,int target,int closest)
        {
            if (node == null)
                return closest;


            var currentDiff = Math.Abs(target - node.data);
            var closestDiff = Math.Abs(closest - target);

            if (closestDiff > currentDiff)
            {
                closest = node.data;
            }
            if (target > node.data)
            {
                return FindClosestInBSTRecursive(node.right, target, closest);
            }
            else if (target < node.data)
            {
                return FindClosestInBSTRecursive(node.left, target, closest);
            }
            else
                return closest;

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
