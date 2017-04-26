using UnityEngine;


public class FadeControl : MonoBehaviour 
{

	void Awake() {
				
		transform.localScale = new Vector3(ScreenSize.width, ScreenSize.height, 1f);
	}


	public void setFaderManually( float newAlpha ) 	{
				
		GetComponent<Renderer>().enabled = true;	
		Color newColor = GetComponent<Renderer>().material.color;
		newColor.a = newAlpha;
		GetComponent<Renderer>().material.color = newColor;
	}
	
	
	public void fadeOut() {
				
		CancelInvoke ();
		
		LeanTween.alpha( gameObject, 1f, 1f).setEase( LeanTweenType.linear ).setOnComplete(cleanUpFader);
	} 

	
	public void cleanUpFader() {	
				
		Color newColor = GetComponent<Renderer>().material.color;
		newColor.a = 0;
		GetComponent<Renderer>().material.color = newColor;
		GetComponent<Renderer>().enabled = false;
	}
}
