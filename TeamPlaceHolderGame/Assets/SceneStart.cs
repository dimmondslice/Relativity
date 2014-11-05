using UnityEngine;
using System.Collections;

public class SceneStart : MonoBehaviour 
{
	public float sceneLength;

	public int sceneNumber = 1;

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}
	public void PlayScene(Character character)
	{
		Destroy(character.GetComponentInChildren<MouseLook>());

		character.enabled = false;
		character.rigidbody.velocity = Vector3.zero;

		print ("i DistanceJoint2D the things, Social love Mesh now");

		//
		if(sceneNumber == 1)
		{
			transform.position = Vector3.Lerp(character.transform.position,transform.position, 1f);
		}


	}
}
