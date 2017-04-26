using UnityEngine;


public class Bounce : MonoBehaviour 
{
	
	private Vector3 startScale;
	private Vector3 newScale;
	
	public float amplitude = .2f;
	public float period = 1f;
	

	protected void Start() {
				
		startScale = newScale = transform.localScale;
	}	
	
	protected void Update() {
				
		float theta = Time.timeSinceLevelLoad / period;
		float distance = amplitude * Mathf.Sin(theta);

		newScale = startScale;
		newScale.x += distance;
		newScale.y -= distance;

		transform.localScale = newScale;
	}
}

