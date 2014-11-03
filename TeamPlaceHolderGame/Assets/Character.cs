using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	//GROUND VARIABLES
	public Vector3 relativeDownVec;//a vector which tells you where gravity is directing this character
	private float groundAccuracy = .1f;//the distance of the racast from the feet, if there is an object less than that far away then you are on the ground
	private float deathByFallDist;//fall farther than this and you will die 
	public bool onGround		//getter function returns whether you are on the ground or not
	{
		get
		{
			RaycastHit hitInfo;
			//Debug.DrawLine( transform.position, transform.position + relativeDownVec * groundAccuracy);

			//if there is something within groundAccuracy of your feet
			Vector3 start = transform.position + relativeDownVec * -1 * .05f; // start the vector just slightly above the feet
			if(Physics.Raycast(start, relativeDownVec, out hitInfo, groundAccuracy))
			{
				_secretOnGround = true;
				currentFallingSpeed = 0f;
				return true;
			}
			else 
			{
				//if there is nothing betweeen your feet and deathByFallDist underneath you, you will start to fall to your death
				if(!Physics.Raycast(transform.position, relativeDownVec, out hitInfo, deathByFallDist))
				{
					StartFallingToDeath();
				}
				_secretOnGround = false;
				return false;
			}
		}
		protected set { _secretOnGround = value;}
	}
	//this is the actual value of onGround, but don't ever use it, just needs to be here okay
	private bool _secretOnGround;

	//CHARACTER PROPERTIES
	public float maxSpeed{get; protected set;}
	public float currentSpeed{get; protected set;}

	public float maxFallingSpeed{get; protected set;}
	public float currentFallingSpeed{get; protected set;}
	public float fallingAccel{get; protected set;}

	public float jumpForce{get; protected set;}
	protected float relativeYVel
	{
		get
		{
			Vector3 relYVel = new Vector3(rigidbody.velocity.x * relativeDownVec.x, rigidbody.velocity.y * relativeDownVec.y, rigidbody.velocity.z * relativeDownVec.z);
			return relYVel.magnitude;
		}
	}

	//MISC
	public checkpointRespawnAt CPRA;

	void Start ()
	{
		//gotta initialize those variables
		maxSpeed = 8f;
		currentSpeed = maxSpeed;
		currentFallingSpeed = 0f;
		maxFallingSpeed = 70f;
		fallingAccel = 7f;
		relativeDownVec = new Vector3(0f,-1f,0f);
		deathByFallDist = 20f;

		jumpForce = 500f;

		CPRA = GetComponent<checkpointRespawnAt>();
	}

	void Update ()
	{
		//this is really mostly for debug, manually changes player orientation by pressing 1-6
		CheckForManualOrientationChange();
		if(onGround)
			MovementMotor();

		//apply gravity (don't worry inside the fn it checks if you're actually on the ground or not)
		ApplyGravity();

		//temporary way to check for jumping
		if(Input.GetButtonDown("Jump") && onGround)
		{
			Jump();
		}

		Debug.DrawRay(transform.position, rigidbody.velocity, Color.magenta);
	}

	void OnTriggerEnter(Collider other)
	{
		//Start Teleport code
		if(other.tag == "Teleport")
		{
			Teleporter teleport = other.GetComponent<Teleporter>();
			if(teleport.receivingTeleporter == null)// teleporters aren't really two sided so this should stop shenanigans
				return;

			rigidbody.velocity = Vector3.zero;
			ChangeOrientation(teleport.orientationAfterTeleport);
			transform.position = teleport.receivingTeleporter.position;

			transform.rotation = teleport.receivingTeleporter.rotation;
			//transform.forward = teleport.receivingTeleporter.forward;	//this is important, it makes sure you face the exit of the reciever teleport
		}
	}

	//moves the character based on user input, does not apply gravity, that is down from the ApplyGravity fn which is called from update()
	protected void MovementMotor()
	{
		//weighted forward vector based on vertical input axis
		Vector3 verticalVelocity = transform.forward * Input.GetAxis("Vertical");
		//vector that is orthogonal to transform.forward
		Vector3 sideways = transform.right;
		//weighted sidways vector based on horizontal input axis
		Vector3 horizontalVelocity = sideways * Input.GetAxis("Horizontal");
		Debug.DrawRay(transform.position, sideways);
		Debug.DrawRay(transform.position, transform.forward);
		//now add the horizontal and vertical vectors to give you your desired forward velocity
		Vector3 newVelocity = verticalVelocity + horizontalVelocity;

		//now scale the vector by your current speed
		newVelocity *= currentSpeed;

		//finally set your characters velocity equal to the vector we've been calculating
		rigidbody.velocity = newVelocity;
	}

	protected void ApplyGravity()
	{
		if(!onGround)
		{
			//increase fallingspeed if you're not at your max yet
			if(currentFallingSpeed < maxFallingSpeed)
			{
				//your downward speed from gravity will accelerate based on time in seconds
				currentFallingSpeed += fallingAccel;
			}
			//adds "gravity vector" to your current velocity. gravity is just the relative downward direction time the scalar currentFallingSpeed
			rigidbody.velocity = rigidbody.velocity + currentFallingSpeed * Time.fixedDeltaTime * relativeDownVec;
		}
		else if (relativeYVel < .1f)	//this should prevent setting the rel. Y =0 if you just jumped
		{

			currentFallingSpeed = 0f;

			//if you are on the ground, set whichever axis of your velocity vec that is down = to 0
			if(relativeDownVec.x != 0)
			{
				rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, rigidbody.velocity.z);
			}
			if(relativeDownVec.y != 0)
			{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f,rigidbody.velocity.z);
			}
			if(relativeDownVec.z != 0)
			{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0f);
			}

		}
	}
	protected void Jump()
	{
		Vector3 forceVec = relativeDownVec * -1 * jumpForce;	//the -1 makes sure that the jump pushes opposite to gravity
		rigidbody.AddForce(forceVec);
		//Debug.Break();
	}

	public void ChangeOrientation(Vector3 whichWayIsDown)
	{
		//update down vec
		relativeDownVec = whichWayIsDown;
		//rotate the character so their local down is the same as whichwayisDown
		transform.forward = relativeDownVec;
		transform.Rotate(-90f,0f,0f, Space.Self);
	}
	public void Respawn()
	{
		//CPRA.doRespawn();
		//ChangeOrientation( CPRA.newOrientation);
	}

	//this is really mostly for debug, manually changes player orientation by pressing 1-6
	protected void CheckForManualOrientationChange()
	{
		if(Input.GetKeyDown("1"))
		{
			ChangeOrientation(new Vector3(0f,-1f, 0f));
		}
		else if(Input.GetKeyDown("2"))
		{
			ChangeOrientation(new Vector3(0f,1f, 0f));
		}
		else if(Input.GetKeyDown("3"))
		{
			ChangeOrientation(new Vector3(-1f,0f, 0f));
		}
		else if(Input.GetKeyDown("4"))
		{
			ChangeOrientation(new Vector3(1f,0f, 0f));
		}
		else if(Input.GetKeyDown("5"))
		{
			ChangeOrientation(new Vector3(0f,0f,-1f));
		}
		else if(Input.GetKeyDown("6"))
		{
			ChangeOrientation(new Vector3(0f,0f, 1f));
		}
	}

	void StartFallingToDeath()
	{
		currentFallingSpeed = 0f;

		print("you would have died right here right now because you are bad at this game");
		Respawn();
	}
}
