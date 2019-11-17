using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjacencyListProject
{
  public  class LinkedDigraph
    {
        public VertexNode start;
        int n;
        int e;

        public int Vertices()
        {
            return n;

        }

        public int Edges()
        {
            return e;
        }

        public void InsertVertex(string s)
        {
            VertexNode temp = new VertexNode(s);
            if (start == null)
                start = temp;
            else
            {
                VertexNode p = start;
                while (p.nextVertex != null)
                {
                    if(p.name.Equals(s))
                    {
                        Console.WriteLine("Vertex exists");
                        return;
                    }
                    p = p.nextVertex;
                }
                if(p.name.Equals(s))
                {
                    Console.WriteLine("Vertex exists");
                    return;
                }
                p.nextVertex = temp;
                
            }
            n++;
        }

        public void DeleteVertex(string s)
        {
            DeleteFromEdgeList(s);
            DeleteFromVertexList(s);
        }

        //Delete incoming edges
        private void DeleteFromEdgeList(string s)
        {
            for(VertexNode p=start;p!=null;p=p.nextVertex)
            {
                if (p.firstEdge == null)
                    continue;
                if(p.firstEdge.endVertex.name.Equals(s))
                {
                    p.firstEdge = p.firstEdge.nextEdge;
                    e--;
                }
                else
                {
                    EdgeNode q = p.firstEdge;
                    while(q.nextEdge!=null)
                    {
                        if(q.nextEdge.endVertex.name.Equals(s))
                        {
                            q.nextEdge = q.nextEdge.nextEdge;
                            e--;
                            break;
                        }
                        q = q.nextEdge;
                    }
                }
            }
        }

        private void DeleteFromVertexList(string s)
        {
            if(start==null)
            {
                Console.WriteLine("No Vertices to be deleted");
                return;
            }
            if(start.name.Equals(s))
            {
                for (EdgeNode q = start.firstEdge; q != null; q = q.nextEdge)
                    e--;
                start = start.nextVertex;
                n--;
            }
            else
            {
                VertexNode p = start;
                while(p.nextVertex!=null)
                {
                    if (p.nextVertex.name.Equals(s))
                        break;
                    p = p.nextVertex;
                }
                if(p.nextVertex==null)
                {
                    Console.WriteLine("Vertex not found");
                    return;
                }
                else
                {
                    for (EdgeNode q = p.nextVertex.firstEdge; q != null; q = q.nextEdge)
                        e--;

                    p.nextVertex = p.nextVertex.nextVertex;
                    n--;
                }
            }
        }

        public VertexNode FindVertex(string s)
        {
            VertexNode p = start;
            while(p!=null)
            {
                if (p.name.Equals(s))
                    return p;
                p = p.nextVertex;
            }
            return null;
        }

        public void InsertEdge(string s1,string s2)
        {
            if(s1.Equals(s2))
            {
                Console.WriteLine("Invalid Edge: Start and End vertices are same");
                return;
            }

            VertexNode u = FindVertex(s1);
            VertexNode v = FindVertex(s2);

            if(u==null)
            {
                Console.WriteLine("Vertex does not exist");
                return;
            }

            if (v == null)
            {
                Console.WriteLine("Vertex does not exist");
                return;
            }

            EdgeNode temp = new EdgeNode(v);
            if(u.firstEdge==null)
            {
                u.firstEdge = temp;
                e++;
            }
            else
            {
                EdgeNode p = u.firstEdge;
                while(p.nextEdge!=null)
                {
                     if(p.nextEdge.endVertex.Equals(v))
                     {
                        Console.WriteLine("Edge is present");
                        return;
                     }

                }

                p.nextEdge = temp;
                e++;
            }
        }
    }
}
