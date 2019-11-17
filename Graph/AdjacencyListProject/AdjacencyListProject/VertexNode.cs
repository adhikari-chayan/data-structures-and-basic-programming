using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjacencyListProject
{
  public  class VertexNode
    {
        public string name;
        public VertexNode nextVertex;
        public EdgeNode firstEdge;

        public VertexNode(string s)
        {
            name = s;
        }
    }
}
