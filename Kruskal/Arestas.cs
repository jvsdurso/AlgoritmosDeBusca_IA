using System;

namespace Kruskal
{
    class Edge 
    {
        public int u;
        public int v;
        public int wt;

        public Edge(int u, int v, int wt)
        {
            this.u = u;
            this.v = v;
            this.wt = wt;
        }
    }
}