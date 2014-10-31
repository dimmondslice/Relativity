using UnityEngine;
using System.Collections;

public class musicLayer : MonoBehaviour {

	public AudioClip[] audioClip;       // music layer array
	
	private AudioSource[] audioSource;  // audio source array
	
	// Use this for initialization
	void Start()
	{
		audioSource = new AudioSource[audioClip.Length];

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
			audioSource[i].volume = 1.0f;
		}
	}
}
