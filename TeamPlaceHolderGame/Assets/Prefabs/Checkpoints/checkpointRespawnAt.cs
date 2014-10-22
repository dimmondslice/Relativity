using UnityEngine;
using System.Collections;

public class checkpointRespawnAt : MonoBehaviour {

	private string checkpointTag = "Checkpoint";
	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = GetComponent< Transform >();
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKey ( "t" ) ) {
			doRespawn();
		}
	}
	
	void doRespawn() {
		GameObject[] allCheckpoints = GameObject.FindGameObjectsWithTag( checkpointTag );
		foreach ( GameObject tCheckpoint in allCheckpoints ) {
			if (tCheckpoint.GetComponent< checkpointNodeBehavior >().isActive() ) {
				Vector3 checkpointPosition = tCheckpoint.GetComponent< Transform >().position;
				myTransform.position =  checkpointPosition;
			}
		}
	}
	
}
