using UnityEngine;
using System.Collections;

public class musicLayer : MonoBehaviour {

	public AudioClip[] audioClip;       // music layer array
	public float audioFadeTween = 0.05f;
	public string attachTargetName;
	
	
	private AudioSource[] audioSource;  // audio source array
	private float[] targetVolume; // desired sound, for cross fades
	
	private GameObject attachTarget;
	private Transform attachTargetTransform;
	private Transform myTransform;
	/* REMOVE BECAUSE THE LEVELS MAY NOT BE FINISHED, MAKE SOUND INDEPENDENT OF LEVEL
	private static musicLayer instance = null;
	public static musicLayer Instance {
		get { return instance; }
	}
	
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	*/
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
		
		
		attachTarget = GameObject.Find(attachTargetName);
		attachTargetTransform = attachTarget.GetComponent<Transform>();
		myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update()
	{
	
		for (int i = 0; i < audioSource.Length; i++)
		{
			audioSource[i].volume = Mathf.Lerp( audioSource[i].volume, targetVolume[i], audioFadeTween );
		}
		
		myTransform.position = attachTargetTransform.position;
		myTransform.Translate( Vector3.up );
	}

	
	public void setAudioVolume( int index, float volume ) {
		if ( index < audioSource.Length ) {
			targetVolume[ index ] = volume;
		}
	}
	
	
}
