using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	//GROUND VARIABLES
	public Vector3 downVec{get; protected set;}//a vector which tells you where gravity is directing this character
	private float groundAccuracy;//the distance of the racast from the feet, if there is an object less than that far away then you are on the ground
	private float deathByFallDist;//fall farther than this and you will die 
	public bool onGround		//getter function returns whether you are on the ground or not
	{
		get
		{
			RaycastHit hitInfo;
			if(Physics.Raycast(transform.position, downVec, out hitInfo, groundAccuracy))
			{
				return true;
			}
			else //start to fall to your death
			{
				if(Physics.Raycast(transform.position, downVec, out hitInfo, deathByFallDist))
				{
					StartFallingToDeath();
				}
				return false;
			}
		}
		protected set { onGround = value;}
	}

	//CHARACTER PROPERTIES
	public float maxSpeed{get; protected set;}


	void Start ()
	{
		maxSpeed = 10f;
	}

	void Update ()
	{
		MovementMotor();
	}
	void MovementMotor()
	{
		rigidbody.velocity = new Vector3(0f,0f,0f);

		//---------------------------------------------------
		//Temporary movement stuff, will be made better later
		//---------------------------------------------------

		//move relative right
		if(Input.GetAxis("Horizontal") > 0f)
		{

		}
		//move relative left
		if(Input.GetAxis("Horizontal") < 0f)
		{
			rigidbody.velocity = new Vector3(rigidbody.velocity.x - maxSpeed, rigidbody.velocity.y, rigidbody.velocity.z);
		}
		//move relative forward
		if(Input.GetAxis("Vertical") > 0f)
		{
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z + maxSpeed);
		}
		//move relative backward
		if(Input.GetAxis("Vertical") < 0f)
		{
			rigidbody.velocity = new Vector3(rigidbody.velocity.x + maxSpeed, rigidbody.velocity.y, rigidbody.velocity.z - maxSpeed);
		}
	}

	void StartFallingToDeath()
	{

	}
}
