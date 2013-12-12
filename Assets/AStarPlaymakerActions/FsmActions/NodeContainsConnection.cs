using HutongGames.PlayMaker.Pathfinding;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Extensions;
using Pathfinding;
using UnityEngine;

namespace Assets.AStarPlaymakerActions.FsmPathfinding
{
	[ActionCategory("A Star")]
	[Tooltip("set node attributes directly")]
	public class NodeContainsConnection : FsmStateAction
	{
		[ActionSection("Any type of node.")]
		[ObjectType(typeof(FsmGraphNode))]
		[Tooltip("node1")]	
		public FsmObject node;
		
		[Tooltip("node2")]
		public FsmObject node2;
		
		[ActionSection("Output")]
		public FsmBool connected;
		
		public override void Reset()
		{
			node = null; 
			node2 = null;
			connected = false;
		}		
      
		public override void OnEnter() 
	  	{
			var sourceFsmNode = node.Value as FsmGraphNode;
			var nodeToCheck = node2.Value as FsmGraphNode; 
			if(sourceFsmNode == null || nodeToCheck == null || (sourceFsmNode.Value == null) || (nodeToCheck.Value == null)) 
			{
				Debug.Log("Input incomplete, node not valid or does not exist. Make sure you assigned it properly.");
				Finish(); 
				return;
			}
			
			var a = (node.Value as FsmGraphNode).Value;
			connected.Value = a.ContainsConnection(node2.GetAnythingShallow() as GraphNode); 
			Finish();	
		} 
   	}
}