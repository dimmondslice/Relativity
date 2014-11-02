using UnityEngine;
using System.Collections;

public class addMusicLayer : MonoBehaviour {

	public int soundLayerToActivate = 0;

	private bool active = true;
	

	// Use this for initialization
	void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter( Collider other ) {
		if ( active ) {
			Debug.Log("sound change");
			GameObject soundCon = GameObject.Find ("DynamicSoundController" );
			soundCon.GetComponent<musicLayer>().setAudioVolume( soundLayerToActivate, 1.0f );
			active = false;
		}
	}
	
	public void setActiveState( bool desired ) {
		active = desired;
	}
	
	public bool isActive() {
		return active;
	}

}
