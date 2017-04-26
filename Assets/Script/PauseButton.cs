using UnityEngine;


public class PauseButton : MonoBehaviour {
		
	public static bool paused;


	void Awake() {
				
		paused = false;
		transform.position = new Vector3 ( transform.position.x, -6, -5);
	}


	void OnMouseUpAsButton () {
				
		if (!paused) {
						
			paused = true;
			LeanTween.scale( gameObject, new Vector3(.8f,.8f,1f), .5f).setEase( LeanTweenType.easeOutBack );
			LeanTween.move( gameObject, new Vector3(0f,0f,-5f), .5f).setEase( LeanTweenType.easeOutBack );
		} else {
						
			paused = false;
			LeanTween.scale( gameObject, new Vector3(.15f,.15f,1f), .2f);
			LeanTween.move( gameObject, new Vector3(0f,-4f,-5f), .2f);
		}
	}


	public void gameStart() {
				
		buttonShow ();
	}
	
	public void gameEnd() {
				
		buttonHide ();
	}

	
	private void buttonShow() {
				
		//LeanTween.moveY( gameObject, -4, 1f).setEase( LeanTweenType.easeOutBack );		
	}

	private void buttonHide() {
				
		//LeanTween.moveY( gameObject, -6, .5f).setEase( LeanTweenType.easeInBack );
	}
}
