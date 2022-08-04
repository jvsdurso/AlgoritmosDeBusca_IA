using System;

namespace Kruskal
{
    class QueueNode
    {
        public Edge info;  
        public QueueNode link;
    
        public QueueNode(Edge e) 
	    {
		    info=e;
		    link=null;
	    }
    }
}