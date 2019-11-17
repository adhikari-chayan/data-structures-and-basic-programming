using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeSumOfBST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(10);
            TreeNode l1 = new TreeNode(5);
            TreeNode r1 = new TreeNode(15);
            root.left = l1;
            root.right = r1;
            l1.left = new TreeNode(3);
            l1.right = new TreeNode(7);
            r1.left = null;
            r1.right = new TreeNode(18);

            int result = RangeSumBST(root, 7, 15);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int RangeSumBST(TreeNode root,int L,int R)
        {
            return RangeSumBST(root, L, R, 0);
        }
        public static int RangeSumBST(TreeNode root, int L, int R,int sum)
        {
           
            if (root.val >= L && root.val <= R)
                sum = sum + root.val;
            if (root.left != null)
              sum=  RangeSumBST(root.left, L, R,sum);
            if (root.right != null)
               sum= RangeSumBST(root.right, L, R,sum);

            return sum;

        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
