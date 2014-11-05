using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {
	public int scene;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="player"){
			Application.LoadLevel(scene);
			print("SOMETHING");
		}

	}
	void DOTHIS(int scene){
		Application.LoadLevel (scene);
	}
	
}
