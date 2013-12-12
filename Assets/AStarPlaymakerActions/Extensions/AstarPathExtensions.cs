using Pathfinding;

namespace HutongGames.PlayMaker.Extensions
{
    public static class AstarPathExtensions 
    {
	    public static void ScanGraph (this NavGraph graph) 
        {
		    if (AstarPath.OnGraphPreScan != null) 
            { AstarPath.OnGraphPreScan (graph); }
		
		    graph.ScanInternal();
		
		    var index = AstarPath.active.astarData.GetGraphIndex (graph);
		    if (index < 0)
            { throw new System.ArgumentException ("Graph is not added to AstarData"); }

            graph.GetNodes(node =>
            {
                node.GraphIndex = (uint) index;
                return true;
            });

            if (AstarPath.OnGraphPostScan != null) 
            { AstarPath.OnGraphPostScan (graph); }
		
		    AstarPath.active.FloodFill ();
            AstarPath.active.DataUpdate();
	    }
    }
}