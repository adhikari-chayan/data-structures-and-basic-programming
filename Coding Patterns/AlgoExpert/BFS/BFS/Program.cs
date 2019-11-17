using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Node
    {
        public string name;
        List<Node> children = new List<Node>();
        public Node(string name)
        {
            this.name = name;
        }

        public List<string> BreadthFirstSearch(List<string> array)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(this);
            while(queue.Count != 0)
            {
                Node current = queue.Dequeue();
                array.Add(current.name);
                for(var i=0;i<current.children.Count;i++)
                {
                    queue.Enqueue(current.children[i]);
                }
            }
            return array;
        }
    }

}
