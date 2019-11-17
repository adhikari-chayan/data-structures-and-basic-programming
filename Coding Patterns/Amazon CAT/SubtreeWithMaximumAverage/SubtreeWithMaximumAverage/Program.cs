using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtreeWithMaximumAverage
{
    class Program
    {
        double max = 0;
        Node result = null;
        static void Main(string[] args)
        {
        }

        public class Node
        {
            public int Val { get; set; }
            public List<Node> Children { get; set; }
            public Node() { }
            public Node(int val, List<Node> children)
            {
                Val = val;
                Children = children;
            }
        }

        public int[] ComputeAvg(Node node)
        {
            if (node == null) return new int[] { 0, 0 };
            int val = node.Val, count = 1;
            foreach (Node child in node.Children)
            {
                int[] arr = ComputeAvg(child);
                val += arr[0];
                count += arr[1];
            }
            if (result == null || val / (0.0 + count) > max)
            {
                result = node;
                max = val / (0.0 + count);
            }
            return new int[] { val, count };
        }
        public Node SubtreeWithMaximumAverage(Node root)
        {
            if (root == null)
                return result;
            ComputeAvg(root);
            return result;
        }
    }
}
