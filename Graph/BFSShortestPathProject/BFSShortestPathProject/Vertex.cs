using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSShortestPathProject
{
   public class Vertex
    {
        public string name;
        public int state;

        public int predecessor;
        public int distance;
        public Vertex(string name)
        {
            this.name = name;
        }
    }
}
