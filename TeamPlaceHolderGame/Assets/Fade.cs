using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fade : MonoBehaviour {
	public float fadeSpeed;
	public Image fadepanel;
	void Start () {
	}

	void Update ()
	{
		Color c=fadepanel.color;
		c.a=Mathf.Lerp(fadepanel.color.a,0.5f,Time.deltaTime*fadeSpeed);
		fadepanel.color=c;
	}
	
	
}