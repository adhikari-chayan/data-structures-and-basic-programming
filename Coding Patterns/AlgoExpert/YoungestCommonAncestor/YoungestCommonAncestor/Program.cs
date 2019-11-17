using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoungestCommonAncestor
{
    class Program
    {
        static void Main(string[] args)
        {
            AncestralTreeNode A = new AncestralTreeNode('A');
            AncestralTreeNode B = new AncestralTreeNode('B');
            AncestralTreeNode C = new AncestralTreeNode('C');
            AncestralTreeNode D = new AncestralTreeNode('D');
            AncestralTreeNode E = new AncestralTreeNode('E');
            AncestralTreeNode F = new AncestralTreeNode('F');
            AncestralTreeNode G = new AncestralTreeNode('G');
            AncestralTreeNode H = new AncestralTreeNode('H');
            AncestralTreeNode I = new AncestralTreeNode('I');

            I.ancestor = D;
            H.ancestor = D;
            D.ancestor = B;
            E.ancestor = B;
            B.ancestor = A;
            C.ancestor = A;
            F.ancestor = C;
            G.ancestor = C;

            var result = GetYoungestCommonAncestor(A, E, I);
            Console.WriteLine(result.name);
            Console.ReadKey();
        }

        public class AncestralTreeNode
        {
            public char name;
            public AncestralTreeNode ancestor;

            public AncestralTreeNode(char name)
            {
                this.name = name;
                this.ancestor = null;
            }
        }

        public static AncestralTreeNode GetYoungestCommonAncestor(AncestralTreeNode topAncestor,AncestralTreeNode descendentOne,AncestralTreeNode descendentTwo)
        {
            int depthOne = GetDescendentDepth(descendentOne, topAncestor);
            int depthTwo= GetDescendentDepth(descendentTwo, topAncestor);

            if(depthOne > depthTwo)
            {
                return BackTrackAncestralTree(descendentOne, descendentTwo, depthOne - depthTwo);
            }
            else
            {
                return BackTrackAncestralTree(descendentTwo, descendentOne, depthTwo - depthOne);
            }
        }

        private static AncestralTreeNode BackTrackAncestralTree(AncestralTreeNode lowerDescendent, AncestralTreeNode higherDescendent, int diff)
        {
            while(diff > 0)
            {
                lowerDescendent = lowerDescendent.ancestor;
                diff--;
            }
            while(lowerDescendent!=higherDescendent)
            {
                lowerDescendent = lowerDescendent.ancestor;
                higherDescendent = higherDescendent.ancestor;
            }

            return lowerDescendent;
        }

        private static int GetDescendentDepth(AncestralTreeNode descendent, AncestralTreeNode topAncestor)
        {
            int depth = 0;
            while(descendent != topAncestor)
            {
                depth++;
                descendent = descendent.ancestor;
            }

            return depth;
        }
    }
}
