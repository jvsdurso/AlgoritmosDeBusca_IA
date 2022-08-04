using System;

namespace DijkstraShortestPathProject
{
    class DirectedWeightedGraph
    {
        public readonly int MAX_VERTICES = 30;

        int n;
        int e;
        int[,] adj;
        Vertice[] vertexList;

        private readonly int TEMPORARY = 1;
        private readonly int PERMANENT = 2;
        private readonly int NIL = -1;
        private readonly int INFINITY = 99999; 

        public DirectedWeightedGraph()
        {
            adj = new int[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertice[MAX_VERTICES];
        }


        private void Dijkstra(int s)
        {
            int v, c;

            for (v = 0; v < n; v++)
            {
                vertexList[v].status = TEMPORARY;
                vertexList[v].pathLength = INFINITY;
                vertexList[v].predecessor = NIL;
            }

            vertexList[s].pathLength = 0;

            while (true)
            {
                c = TempVertexMinPL();

                if (c == NIL)
                    return;

                vertexList[c].status = PERMANENT;

                for (v = 0; v < n; v++)
                {
                    if (IsAdjacent(c, v) && vertexList[v].status == TEMPORARY)
                        if (vertexList[c].pathLength + adj[c,v] < vertexList[v].pathLength)
                        {
                            vertexList[v].predecessor = c;
                            vertexList[v].pathLength = vertexList[c].pathLength + adj[c,v];
                        }
                }
            }
        }

        private int TempVertexMinPL()
        {
            int min = INFINITY;
            int x = NIL;
            for (int v = 0; v < n; v++)
            {
                if (vertexList[v].status == TEMPORARY && vertexList[v].pathLength < min)
                {
                    min = vertexList[v].pathLength;
                    x = v;
                }
            }
            return x;
        }

        public void FindPaths(String source)
        {
	        int s = GetIndex(source);
	   
	        Dijkstra(s);
	   
	        Console.WriteLine("Vertice escolhido : " + source + "\n");
	        
            for (int v = 0; v < n; v++)
	        {
		        Console.WriteLine("Vertice de destino: " + vertexList[v].name);
		        if ( vertexList[v].pathLength == INFINITY )
	                Console.WriteLine("Nao ha caminho do vertice" + source + " para o vertice " + vertexList[v].name + "\n");
		        else
				    FindPath(s,v);
	        }
        }

        private void FindPath(int s, int v)
        {
   	        int i, u;
   	        int [] path = new int[n]; 
   	        int sd = 0;	     
   	        int count = 0;		    
   	   	
   	        while (v != s)
   	        {
   		        count++;
   		        path[count] = v;
   	            u = vertexList[v].predecessor;
   		        sd += adj[u,v];
   		        v=u;	
   	        }
   	        count++;
   	        path[count] = s;

   	        Console.Write("Menor caminho: ");
   	        for (i = count; i>=1; i--)	
   		        Console.Write(path[i] + " ");
   	        Console.WriteLine("\n Menor distancia: " + sd + "\n");
   	    }

        private int GetIndex(String s)
        {
            for (int i = 0; i < n; i++)
                if (s.Equals(vertexList[i].name))
                    return i;
            throw new System.InvalidOperationException("Vertice Invalido");
        }

        public void InsertVertex(String name)
        {
            vertexList[n++] = new Vertice(name);
        }

       
        private bool IsAdjacent(int u, int v)
        {
            return (adj[u, v] != 0);
        }

        public void InsertEdge(String s1, String s2, int wt)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);
            if (u == v)
                throw new System.InvalidOperationException("Vertice invalido");

            if (adj[u, v] != 0)
                Console.Write("Vertice visitado");
            else
            {
                adj[u, v] = wt;
                e++;
            }
        }
    }
}