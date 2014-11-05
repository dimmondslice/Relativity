using UnityEngine;
using System.Collections;

public class levelscript : MonoBehaviour {
	// Use this for initialization
	public int scene;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HEREIMHERE(int scene){

		Application.LoadLevel (scene);
	}
	void OnTriggerEnter(Collider self){
		Application.LoadLevel (scene);
		print ("HERE");
	}
}