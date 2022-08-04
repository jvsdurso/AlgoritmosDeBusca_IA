using System;
using System.Collections.Generic;

namespace BFSShortestPathsProject
{
    class DirectedGraph
    {
        public readonly int MAX_VERTICES = 30;

        int n;
        int e;
        bool[,] adj;
        Vertice[] vertexList;

        private readonly int INICIO = 0;
        private readonly int WAITING = 1;
        private readonly int VISITADO = 2;

        private readonly int NIL = -1;
        private readonly int INFINITY = 99999;

        public DirectedGraph()
        {
            adj = new bool[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertice[MAX_VERTICES];
        }

        public void FindShortestPath(String s)
	    {
		   for (int v = 0; v < n; v++) 
		   {	
			   vertexList[v].state = INICIO;
			   vertexList[v].predecessor = NIL;
			   vertexList[v].distance = INFINITY;
		   }
		   
		   Bfs ( GetIndex(s) );
		   
		   for (int v = 0; v < n; v++)
		   {
			   if ( vertexList[v].distance == INFINITY )
		        	Console.WriteLine("Nao ha caminho do vertice " + s + " para o vertice " + vertexList[v].name);
		       else	
		       {
		    	   Console.WriteLine("Menor distancia do vertice " + s + " para o vertice "
                                          + vertexList[v].name + " is " + vertexList[v].distance); 
		    			                                             
		    	   int [] path = new int[n];
		    	   int count = 0;
		    	   int x, y = v;
		    	   while ( y != NIL )
		    	   {
		    		   count++;
		    		   path[count] = y;
		    		   x = vertexList[y].predecessor;
		    		   y = x;	
		    	   }
		    	   Console.Write("Caminha mais curto: ");
		    	   int i;
		    	   for ( i = count; i > 1; i-- )	
		    		   Console.Write ( vertexList[path[i]].name +"->" );
		    	   Console.WriteLine ( vertexList[path[i]].name );
		       }
		   }
	   }

        private void Bfs(int v)
	    {	   
		   Queue<int> qu = new Queue<int>();
		   qu.Enqueue(v);
		   vertexList[v].state = WAITING;
		   vertexList[v].distance = 0;
		   vertexList[v].predecessor = NIL;
		   
		   while ( qu.Count != 0 )
	   	   {
	   		 v = qu.Dequeue();
	   		 vertexList[v].state = VISITADO;
	   		
	   		 for ( int i = 0; i < n; i++)
	   		 {
	   			if ( IsAdjacent(v,i) && vertexList[i].state == INICIO ) 
	   			{
	   				qu.Enqueue(i);
	   				vertexList[i].state = WAITING;
	   				vertexList[i].predecessor = v;
	   				vertexList[i].distance = vertexList[v].distance + 1;
	   			}
	   		 }
	   	  }
	   	  Console.WriteLine();
	    }
               
        public void InsertVertex(String name)
        {
            vertexList[n++] = new Vertice(name);
        }

        private int GetIndex(String s)
        {
            for (int i = 0; i < n; i++)
                if (s.Equals(vertexList[i].name))
                    return i;
            throw new System.InvalidOperationException("Vertice invalido");
        }

        private bool IsAdjacent(int u, int v)
        {
            return adj[u, v];
        }

        public void InsertEdge(String s1, String s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (u == v)
                throw new System.InvalidOperationException("Vertice invalido");
            if (adj[u, v] == true)
                Console.Write("Vertice visitado");
            else
            {
                adj[u, v] = true;
                e++;
            }
        }
    }
}