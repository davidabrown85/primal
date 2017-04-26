using UnityEngine;


public class ScreenSize : MonoBehaviour
{
		
	public static float width;
	public static float height;
	

	void Awake () {
				
		ScreenSize.height = Camera.main.orthographicSize * 2.0f;
		ScreenSize.width = ScreenSize.height * Screen.width / Screen.height;
	}

}

