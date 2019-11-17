using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<string>();
            var root = new Node("A");
            root.AddChild("B").AddChild("C").AddChild("D");
            root.children[0].AddChild("E").AddChild("F");
            root.children[2].AddChild("G").AddChild("H");
            root.children[0].children[1].AddChild("I").AddChild("J");
            root.children[2].children[0].AddChild("K");
            root.DepthFirstSearch(input);
            foreach(var item in input)
                Console.Write(item);

            Console.ReadKey();
        }
    }

    public class Node
    {
        public string name;
        public List<Node> children = new List<Node>();

        public Node(string name)
        {
            this.name = name;
        }

        public List<string> DepthFirstSearch(List<string> array)
        {
            array.Add(this.name);
            for(int i=0;i<this.children.Count;i++)
            {
                children[i].DepthFirstSearch(array);
            }
            return array;
        }

        public Node AddChild(string name)
        {
            Node child = new Node(name);
            this.children.Add(child);
            return this;
        }
    }
}
