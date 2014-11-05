using UnityEngine;
using System.Collections;

public class addMusicLayer : MonoBehaviour {

	public int soundLayerToActivate = 0;
	public float volume = 1.0f;
	public bool activateAllUpTo = false;

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
			if ( activateAllUpTo ) {
				for ( int i = 0; i < soundLayerToActivate; ++i ) {
					soundCon.GetComponent<musicLayer>().setAudioVolume( i, volume );
				}
			}
			else {
				soundCon.GetComponent<musicLayer>().setAudioVolume( soundLayerToActivate, volume );
			}
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
