using UnityEngine;

public class MuteButton : MonoBehaviour 
{
	
	public Sprite[] sprites;
	private SpriteRenderer _spriteRenderer;
	

	void Awake () {
				
		_spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;

		if( PlayerPrefs.GetInt( "audio", 1 ) == 1 ){
						
			AudioListener.pause = true;
			_spriteRenderer.sprite = sprites[0];
		}else{
						
			AudioListener.pause = false;
			_spriteRenderer.sprite = sprites[1];
        }
    }
	
	void OnMouseUpAsButton() {
				
		if( PlayerPrefs.GetInt( "audio", 1 ) == 1 ){
			PlayerPrefs.SetInt( "audio", 0 );
			AudioListener.pause = false;
			_spriteRenderer.sprite = sprites[1];
		}else {
						
			PlayerPrefs.SetInt( "audio", 1 );
			AudioListener.pause = true;
			_spriteRenderer.sprite = sprites[0];
        }
	}
}
