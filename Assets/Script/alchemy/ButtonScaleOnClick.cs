using UnityEngine;

public class ButtonScaleOnClick : MonoBehaviour 
{

	private float downScale;
	private float upScale;


	void Awake () {
				
		upScale = transform.localScale.x;
		downScale = upScale * 1.1f;
	}
	

	void OnMouseDown() {
				
		transform.localScale = new Vector3( downScale, downScale, 0 );
	}
	

	void OnMouseUp() {
		
		transform.localScale = new Vector3( upScale, upScale, 0 );
	}
}
