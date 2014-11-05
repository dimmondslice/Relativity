using UnityEngine;
using System.Collections;

public class GuyCharacter : Character
{
	//the next node
	public Transform target;

	public float turnSnapAng = 10f;			//used to snap turns if the angle is less than this 
	public float AngVel = 8f;

	protected override void Start ()
	{
		target = PathNode.FindClosestNode(transform).transform;
		base.Start();

		currentSpeed = 7f;
	}

	protected override void Update () 
	{
		float distThreshold = .5f;

		if(target == null)
			target = PathNode.FindClosestNode(transform).transform;
		
		if(Vector3.Distance(transform.position, target.position) < distThreshold)
		{
			if(target.GetComponent<PathNode>().nextNode == null)					//if you run out of nodes to follow just start to wander around
			{
				Destroy(gameObject);
			}
			else//otherwise just make the next node your target
			{
				target = target.GetComponent<PathNode>().nextNode.transform;
			}
		}
		//otherwise increase your speed
		else
		{
			//if(currentSpeed < maxSpeed)
				//currentSpeed += agent.accel;
		}
		//then actually move yourself
		TurnTowards(target.position);
		rigidbody.velocity = transform.forward * currentSpeed;

		//apply gravity (don't worry inside the fn it checks if you're actually on the ground or not)
		if(!onGround)
			ApplyGravity();
	}
	public void TurnTowards(Vector3 POI)
	{
		//calculate the angle between this agents direction and the location of the target
		Vector3 relative = transform.InverseTransformPoint(POI);
		float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
		
		if(angle > turnSnapAng)
		{
			transform.Rotate(0f, AngVel, 0f);
		}
		else if (angle < -turnSnapAng)
		{
			transform.Rotate(0f, -AngVel, 0f);
		}
		else  		//otherwise just look right at them
		{
			Vector3 oldRot = transform.rotation.eulerAngles;
			transform.LookAt(POI);
			transform.rotation = Quaternion.Euler(oldRot.x, transform.rotation.eulerAngles.y, oldRot.z);
		}
	}
	
}
