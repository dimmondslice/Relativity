using UnityEngine;
using System.Collections;

public class musicLayer : MonoBehaviour {

	public AudioClip[] audioClip;       // music layer array
	public float audioFadeTween = 0.05f;
	
	private AudioSource[] audioSource;  // audio source array
	private float[] targetVolume; // desired sound, for cross fades
	/*
	private static DynamicSoundController instance = null;
	public static DynamicSoundController Instance {
		get { return instance; }
	}
	
	void Awake() {
		if (instance != null &amp;&amp; instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}*/
	
	// Use this for initialization
	void Start()
	{
		audioSource = new AudioSource[audioClip.Length];
		targetVolume = new float[audioClip.Length];
		
		for (int i = 0; i < audioSource.Length; i++)
		{
			audioSource[i] = gameObject.AddComponent<AudioSource>();
			audioSource[i].clip = audioClip[i];
			audioSource[i].Play();
			audioSource[i].loop = true;
			audioSource[i].volume = 0.0f;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
	
		for (int i = 0; i < audioSource.Length; i++)
		{
			audioSource[i].volume = Mathf.Lerp( audioSource[i].volume, targetVolume[i], audioFadeTween );
		}
		
		
	}
	
	public void setAudioVolume( int index, float volume ) {
		if ( index < audioSource.Length ) {
			targetVolume[ index ] = volume;
		}
	}
	
	
}
