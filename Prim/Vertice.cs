using System;

namespace Prim
{
    class Vertice
    {
        public String name;
        public int status;
        public int predecessor;
        public int length;

        public Vertice(String name)
        {
            this.name = name;
        }
    }
}