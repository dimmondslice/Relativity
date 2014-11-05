using UnityEngine;
using System.Collections;

public class GuyCharacter : Character
{
	//the next node
	public Transform target;

	void Start ()
	{
	
	}

	protected override void Update () 
	{
		/*
		float distThreshold = 2f;

		if(target == null)
			target = PathNode.FindClosestNode(transform).transform;
		
		if(Vector3.Distance(transform.position, target.position) < distThreshold)
		{
			if(target.GetComponent<PathNode>().nextNode == null)					//if you run out of nodes to follow just start to wander around
			{
				//need to destroy this instance
			}
			//otherwise just make the next node your target
			target = target.GetComponent<PathNode>().nextNode.transform;
		}
		//otherwise increase your speed
		else
		{
			//if(currentSpeed < maxSpeed)
				//currentSpeed += agent.accel;
		}
		//then actually move yourself
		TurnTowards(target.position);
		rigidbody.velocity = new Vector3(transform.forward.x * agent.currentSpeed, rigidbody.velocity.y, transform.forward.z * agent.currentSpeed);
		*/
	}
	
}
