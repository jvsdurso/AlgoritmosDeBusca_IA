using System;

namespace Kruskal
{
    class UndirectedWeightedGraph
    {
        public readonly int MAX_VERTICES = 30;

        int n;
        int e;
        int[,] adj;
        Vertice[] vertexList;
                
        private readonly int NIL = -1;
        
        public UndirectedWeightedGraph()
        {
            adj = new int[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertice[MAX_VERTICES];
        }

        public int Vertices()
        {
            return n;
        }

        public int Edges()
        {
            return e;
        }

        public void Kruskals()
        {
 	        PriorityQueue pq = new PriorityQueue();
 	   
 	        int u,v;
 	        for (u = 0; u < n; u++)
 		        for (v = 0; v < u; v++)
 		        {
 			        if (adj[u,v] != 0)
 				        pq.Insert(new Edge(u,v,adj[u,v]));
 		        }
 	   
 	        for (v = 0; v < n; v++)
 	   		    vertexList[v].father = NIL;
 	   
 	        int v1, v2, r1 = NIL, r2 = NIL;
	        int edgesInTree = 0;  
	        int wtTree = 0;
	   
 	        while (!pq.IsEmpty() && edgesInTree <n-1)
 	        {
 		        Edge edge = pq.Delete();
 		        v1 = edge.u;
 		        v2 = edge.v;
 	   		
 	   		    v = v1;
 		        while(vertexList[v].father!=NIL)
 	   			    v = vertexList[v].father;
 	   		    r1 = v;
 		    
 	   		    v = v2;
 		        while(vertexList[v].father!=NIL)
 		    	    v = vertexList[v].father;
 			    r2 = v;

 	   		    if(r1!=r2) 
 	   		    {
 	   			    edgesInTree++;
 	   		        Console.WriteLine(vertexList[v1].name + "->"  + vertexList[v2].name ); 
 	   	    	    wtTree += edge.wt;
 	   	            vertexList[r2].father = r1;
 	   		    }
 	   	    }
 	  
 	   	    if(edgesInTree < n-1)
 	   	        throw new InvalidOperationException
                ("Grafo eh nao conectado, nao ha arvore minima\n");
 	  	   	
 	   	    Console.WriteLine("Tamanho da arvore geradora minima eh " + wtTree);
 	    }

       
        private int GetIndex(String s)
        {
            for (int i = 0; i < n; i++)
                if (s.Equals(vertexList[i].name))
                    return i;
            throw new System.InvalidOperationException("Vertice invalido");
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
            if (adj[u, v] != 0)
                Console.Write("Vertice ja presente");
            else
            {
                adj[u, v] = wt;
                adj[v, u] = wt;
                e++;
            }
        }
    }
}