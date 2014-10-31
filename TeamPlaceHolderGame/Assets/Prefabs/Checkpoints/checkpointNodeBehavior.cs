using UnityEngine;
using System.Collections;

public class checkpointNodeBehavior : MonoBehaviour {

	//public GameObject triggerObject;

	private bool active = false;
	private string checkpointTag = "Checkpoint";

	public Vector3 orientation;
	

	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter( Collider other ) {
		Debug.Log ( "Checkpoint triggered" );
		DisableOtherCheckpoints();
		active = true;
	}
	
	public void setActiveState( bool desired ) {
		active = desired;
	}
	
	public bool isActive() {
		return active;
	}
	
	
	void DisableOtherCheckpoints() {
		GameObject[] allCheckpoints = GameObject.FindGameObjectsWithTag( checkpointTag );
		foreach ( GameObject tCheckpoint in allCheckpoints ) {
			tCheckpoint.GetComponent< checkpointNodeBehavior >().setActiveState( false );
		}
	}
	
}
