using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeInorderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void IterativeInorderTraversal(BinaryTreeNode root,Action<BinaryTreeNode> callBack)
        {
            BinaryTreeNode previousNode = null;
            BinaryTreeNode currentNode = root;
            while(currentNode!=null)
            {
                BinaryTreeNode nextNode;
                //if it is root node or a node whose parent is same as previousNode pointer==> going down
                if(previousNode==null||currentNode.parent==previousNode)
                {
                    if(currentNode.left!=null)
                    {
                        nextNode = currentNode.left;
                    }
                    else
                    {
                        callBack(currentNode);
                        if(currentNode.right!=null)
                        {
                            nextNode = currentNode.right;
                        }
                        else
                        {
                            nextNode = currentNode.parent;
                        }
                    }
                }
                //coming up when previousNode pointer is below current node
                else if (previousNode == currentNode.left)
                {
                    callBack(currentNode);
                    if (currentNode.right != null)
                    {
                        nextNode = currentNode.right;
                    }
                    else
                    {
                        nextNode = currentNode.parent;
                    }
                }
                else//previousNode==currentNode.right
                {
                    nextNode = currentNode.parent;
                }

                previousNode = currentNode;
                currentNode = nextNode;
             }

            
        }

    public class BinaryTreeNode
    {
        public int value;
        public BinaryTreeNode left;
        public BinaryTreeNode right;
        public BinaryTreeNode parent;

        public BinaryTreeNode(int value)
        {
            this.value = value;
        }

        public BinaryTreeNode(int value,BinaryTreeNode parent)
        {
            this.value = value;
            this.parent = parent;
        }

    }
}
