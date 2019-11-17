using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BfsProject
{
    public class DirectedGraph
    {
        public readonly int MAX_VERTICES = 30;

        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;

        private readonly int INITIAL = 0;
        private readonly int WAITING = 1;
        private readonly int VISITED = 2;

        public DirectedGraph()
        {
            adj = new bool[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }

        public int Vertices()
        {
            return n;
        }

        public int Edges()
        {
            return e;
        }

        public void Display()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (adj[i, j])
                        Console.Write("1 ");
                    else
                        Console.Write("0 ");
                }
                Console.WriteLine();
            }
        }

        public void InsertVertex(string name)
        {
            vertexList[n++] = new Vertex(name);
        }

        public int GetIndex(string s)
        {
            for (int i = 0; i < n; i++)
            {
                if (s.Equals(vertexList[i].name))
                    return i;

            }
            throw new InvalidOperationException("Invalid vertex");
        }

        public bool EdgeExists(string s1, string s2)
        {
            return IsAdjacent(GetIndex(s1), GetIndex(s2));
        }

        private bool IsAdjacent(int u, int v)
        {
            return adj[u, v];
        }

        public void InsertEdge(string s1, string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (u == v)
                throw new InvalidOperationException("Not a valid edge.");

            if (adj[u, v] == true)
                Console.WriteLine("Edge already exists");

            else
            {
                adj[u, v] = true;
                e++;
            }
        }

        public void DeleteEdge(string s1, string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);



            if (adj[u, v] == false)
                Console.WriteLine("Edge not present in the graph");

            else
            {
                adj[u, v] = false;
                e--;
            }
        }

        public int Outdegree(string s)
        {
            int u = GetIndex(s);
            int outD = 0;
            for (int v = 0; v < n; v++)
            {
                if (adj[u, v])
                    outD++;
            }
            return outD;
        }
        public int Indegree(string s)
        {
            int v = GetIndex(s);
            int inD = 0;
            for (int u = 0; u < n; u++)
            {
                if (adj[u, v])
                    inD++;
            }
            return inD;
        }

        public void BfsTraversal()
        {
            for (var i = 0; i < n; i++)
                vertexList[i].state = INITIAL;

            Console.Write("Enter starting vertex for BFS: ");
            string s = Console.ReadLine();
            Bfs(GetIndex(s));
        }

        public void BfsTraversalAll()
        {
            for (var i = 0; i < n; i++)
                vertexList[i].state = INITIAL;

            Console.Write("Enter starting vertex for BFS: ");
            string s = Console.ReadLine();
            Bfs(GetIndex(s));
            

            //Continue BFS still all vertices are visited
            for(int j=0;j<n;j++)
            {
                if (vertexList[j].state == INITIAL)
                    Bfs(j);
            }
        }

        private void Bfs(int v)
        {
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(v);

            vertexList[v].state = WAITING;
            while (qu.Count != 0)
            {
                v = qu.Dequeue();
                Console.Write(vertexList[v].name);
                vertexList[v].state = VISITED;

                for(var i=0;i<n;i++)
                {
                    if(IsAdjacent(v,i) && vertexList[i].state==INITIAL)
                    {
                        qu.Enqueue(i);
                        vertexList[i].state = WAITING;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
