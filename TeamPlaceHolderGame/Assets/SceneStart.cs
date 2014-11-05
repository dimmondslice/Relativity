using UnityEngine;
using System.Collections;

public class SceneStart : MonoBehaviour 
{
	public float sceneLength;

	public int sceneNumber = 0;

	public Character currentCharacter;

	public Transform enemy;

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}
	public void PlayScene(Character character)
	{

		currentCharacter = character;

		character.enabled = false;
		character.rigidbody.velocity = Vector3.zero;

		print ("i DistanceJoint2D the things, Social love Mesh now");

		//ending scene
		if(sceneNumber == 1)
		{

			character.GetComponentInChildren<Animation>().Play("StabCycle");

			character.sword.GetComponent<Renderer>().enabled = true;

			character.transform.position = transform.position;
			character.transform.forward = transform.forward;

			Invoke("KillerAnim", 3.5f);
			Invoke("NextAnim", 4.5f);
			Invoke("MyAnim", 8f);
		}
		//starting scene, watching other guy run away, up the stairway
		if(sceneNumber == 2)
		{
			Invoke("Unlock", 10f);
		}

		this.enabled = false;
	}
	public void Unlock()
	{
		currentCharacter.enabled = true;
		currentCharacter.sword.GetComponent<Renderer>().enabled = false;
	}
	public void NextAnim()
	{
		GetComponentInChildren<Animation>().Play ("3rdPersonStabbed");

	}

	public void MyAnim()
	{

		currentCharacter.GetComponentInChildren<Animation>().Play("1stPersonStabbed");

		currentCharacter.sword.gameObject.AddComponent("Rigidbody");

	}
	public void KillerAnim()
	{
		currentCharacter.transform.Find ("Past").animation.Play("StabCycle");
	}
}
