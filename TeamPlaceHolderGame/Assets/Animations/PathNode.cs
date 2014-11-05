using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathNode : MonoBehaviour
{
	public PathNode nextNode;

	public static List<PathNode> allPathNodes;

	void Awake () 
	{
		//initialize allPathNodes if it hasn't been initialized by any other existing node yet
		if(allPathNodes == null)
			allPathNodes = new List<PathNode>();

		//add myself to the list of all pathnodes
		allPathNodes.Add (this);

		//set the nextnode in the path
		//nextNode = FindClosestNodeWithNullPTR(transform);
	}
	public static PathNode FindClosestNode(Transform t)
	{
		PathNode currentClosest = PathNode.allPathNodes[0];		//arbitrarily make currentclosest node the first nod in the list so it isn't null

		foreach(PathNode node in PathNode.allPathNodes)
		{
			if(Vector3.Distance(t.position, node.transform.position) < Vector3.Distance(t.position, currentClosest.transform.position))
			{
				currentClosest = node;		//update what is stored as the closest node to t
			}
		}
		return currentClosest;
	}




	public static PathNode FindClosestNodeWithNullPTR(Transform t)
	{
		PathNode currentClosest = PathNode.allPathNodes[0];		//arbitrarily make currentclosest node the first nod in the list so it isn't null
		
		foreach(PathNode node in PathNode.allPathNodes)
		{
			if(Vector3.Distance(t.position, node.transform.position) < Vector3.Distance(t.position, currentClosest.transform.position))
			{
				if(node.nextNode == null && node != t.GetComponent<PathNode>())				///if the ptr isnt null or is just the node who called this func, then ignore it
					currentClosest = node;		//update what is stored as the closest node to t
			}
		}
		return currentClosest;
	}
}
