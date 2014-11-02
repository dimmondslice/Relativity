using UnityEngine;
using System.Collections;

public class UIscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		//GUI.Box (new Rect(100,100,100,100),"TEXT");
		if(GUI.Button(new Rect(600,300,200,100),"Start Game")){
			Application.LoadLevel(0);
		}
		if(GUI.Button(new Rect(100,400,100,100),"DEBUG LVL1")){
			Application.LoadLevel(0);
		}
		if(GUI.Button(new Rect(200,400,100,100),"DEBUG LVL2")){
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(300,400,100,100),"DEBUG LVL3")){
			Application.LoadLevel(2);
		}
		if(GUI.Button (new Rect(400,400,100,100),"DEBUG LVL4")){
			Application.LoadLevel(3);
		}
		if(GUI.Button (new Rect(500,400,100,100),"Bridge")){
			Application.LoadLevel(4);
		}
		if(GUI.Button (new Rect(600,400,100,100),"Opening")){
			Application.LoadLevel(5);
		}
	}
}
