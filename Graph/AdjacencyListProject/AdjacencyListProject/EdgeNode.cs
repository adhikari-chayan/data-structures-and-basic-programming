using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjacencyListProject
{
   public class EdgeNode
    {
        public VertexNode endVertex;
        public EdgeNode nextEdge;

        public EdgeNode(VertexNode v)
        {
            endVertex = v;
        }
    }
}
