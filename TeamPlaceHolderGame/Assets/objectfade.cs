using UnityEngine;
using System.Collections;

public class objectfade : MonoBehaviour {
	public float fadeSpeed;
	public GameObject fadeobject;
	private float targetAlpha=0.0f;
	void Start () {
	
	}

	// Update is called once per frame
	void Update()
	{
		//Color c=fadeobject.GetComponent<Color>();
		//c.a=Mathf.Lerp(fadeobject.color.a,0.5f,Time.deltaTime*fadeSpeed);
		//fadeobject.color=c;
		float t=0.0f;
		float currentAlpha=renderer.material.color.a;
		while(t<=1){
			Color tempcolor=renderer.material.color;
			//renderer.material.color.a=Mathf.Lerp (currentAlpha,targetAlpha,t);
			tempcolor.a=Mathf.Lerp (currentAlpha,targetAlpha,t);
			renderer.material.color=tempcolor;
			t+=Time.deltaTime/t;
		}
		//renderer.material.color.a=targetAlpha;

	}
}
