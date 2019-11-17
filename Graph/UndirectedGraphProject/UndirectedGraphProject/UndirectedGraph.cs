using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndirectedGraphProject
{
   public class UndirectedGraph
    {
        public readonly int MAX_VERTICES = 30;

        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;

        public UndirectedGraph()
        {
            adj =new bool[MAX_VERTICES, MAX_VERTICES];
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
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(adj[i,j])
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
            for(int i=0;i<n;i++)
            {
                if (s.Equals(vertexList[i].name))
                    return i;

            }
            throw new InvalidOperationException("Invalid vertex");
        }

        public bool EdgeExists(string s1,string s2)
        {
            return IsAdjacent(GetIndex(s1), GetIndex(s2));
        }

        private bool IsAdjacent(int u,int v)
        {
            return adj[u, v];
        }

        public void InsertEdge(string s1,string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (u == v)
                throw new InvalidOperationException("Not a valid edge.");

            if(adj[u,v]==true)
                Console.WriteLine("Edge already exists");

            else
            {
                adj[u, v] = true;
                adj[v, u] = true;
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
                adj[v, u] = false;
                e--;
            }
        }

        public int Degree(string s)
        {
            int u = GetIndex(s);
            int deg = 0;
            for(int v=0;v<n;v++)
            {
                if (adj[u, v])
                    deg++;
            }
            return deg;
        }
        
    }
}
