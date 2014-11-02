using UnityEngine;
using System.Collections;

public class levelscript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HEREIMHERE(int scene){

		Application.LoadLevel (scene);
	}
}