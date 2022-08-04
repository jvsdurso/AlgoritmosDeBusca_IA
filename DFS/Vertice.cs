using System;

namespace BFSShortestPathsProject
{
    class Vertice
    {
        public String name;
        public int state;
        public int predecessor;
        public int distance;

        public Vertice(String name)
        {
            this.name = name;
        }
    }
}