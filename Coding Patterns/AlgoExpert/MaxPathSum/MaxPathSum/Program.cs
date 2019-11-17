using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int MaxPathSum(BinaryTreeNode root)
        {
            List<int> maxSumArray = FindMaxSum(root);
            return maxSumArray[0];
        }

        public static List<int> FindMaxSum(BinaryTreeNode node)
        {
            if (node == null)
                return new List<int> { 0, 0 };

            List<int> leftMaxSumArray = FindMaxSum(node.left);
            //LSB(Branch only)
            int leftMaxSumAsBranch = leftMaxSumArray[0];
            //LS(With Triangle)
            int leftMaxPathSum = leftMaxSumArray[1];

            List<int> righMaxSumArray = FindMaxSum(node.right);
            //RSB
            int rightMaxSumAsBranch = righMaxSumArray[0];
            //RS
            int rightMaxPathSum = righMaxSumArray[1];


            //MCSB
            int maxChildSubAsBranch = Math.Max(leftMaxSumAsBranch, rightMaxSumAsBranch);
            //MSB
            int maxSumAsBranch = Math.Max(maxChildSubAsBranch + node.value, node.value);

            //MaxSumAsTriangle(MST)
            int maxSumAsRoot = Math.Max(maxSumAsBranch, leftMaxSumAsBranch + node.value + rightMaxSumAsBranch);

            //RMPS(Running Max Path Sum)
            int maxPathSum = Math.Max(leftMaxPathSum, Math.Max(rightMaxPathSum, maxSumAsRoot));

            return new List<int> { maxSumAsBranch, maxPathSum };
        }
    }

    public class BinaryTreeNode
    {
        public int value;
        public BinaryTreeNode left;
        public BinaryTreeNode right;

        public BinaryTreeNode(int value)
        {
            this.value = value;
        }
    }
}
