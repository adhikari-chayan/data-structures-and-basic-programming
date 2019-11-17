using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeFromInOrderAndPostOrder
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class BinaryTree
    {
        public Node root;
        
        public Node BuildTree(char[] inOrder,char[] postOrder,int inStart,int inEnd,int postIndex)
        {
            if (inStart > inEnd)
                return null;
            Node tNode = new Node(postOrder[postIndex--]);

            if (inStart == inEnd)
                return tNode;

            int inOrderIdx = Search(inOrder, inStart, inEnd, tNode.data);

            tNode.left = BuildTree(inOrder, postOrder, inStart, inOrderIdx - 1,postIndex);
            tNode.right = BuildTree(inOrder, postOrder, inOrderIdx + 1, inEnd, postIndex);

            return tNode;
        }

        private int Search(char[] inOrder, int inStart, int inEnd, char data)
        {
            int i;
            for(i=inStart;i<=inEnd;i++)
            {
                if (inOrder[i] == data)
                    break;
            }
            return i;
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
        }
    }
}
