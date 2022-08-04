using System;

namespace DijkstraShortestPathProject
{
    class Vertice
    {
        public String name;
        public int status;
        public int predecessor;
        public int pathLength;

        public Vertice(String name)
        {
            this.name = name;
        }
    }
}