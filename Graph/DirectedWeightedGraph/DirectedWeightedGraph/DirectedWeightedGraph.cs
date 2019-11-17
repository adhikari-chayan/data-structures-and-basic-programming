using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectedWeightedGraphProject
{
   public class DirectedGraph
    {
        public readonly int MAX_VERTICES = 30;

        int n;
        int e;
        int[,] adj;
        Vertex[] vertexList;

        public DirectedGraph()
        {
            adj =new int[MAX_VERTICES, MAX_VERTICES];
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

                    Console.Write(adj[i,j]+" ");    
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
            return (adj[u, v] != 0);
        }

        public void InsertEdge(string s1,string s2,int weight)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (u == v)
                throw new InvalidOperationException("Not a valid edge.");

            if(adj[u,v]!=0)
                Console.WriteLine("Edge already exists");

            else
            {
                adj[u, v] = weight;
                e++;
            }
        }

        public void DeleteEdge(string s1, string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            

            if (adj[u, v] == 0)
                Console.WriteLine("Edge not present in the graph");

            else
            {
                adj[u, v] = 0;
                e--;
            }
        }

        public int Outdegree(string s)
        {
            int u = GetIndex(s);
            int outD = 0;
            for(int v=0;v<n;v++)
            {
                if (adj[u, v]!=0)
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
                if (adj[u, v]!=0)
                    inD++;
            }
            return inD;
        }
    }
}
