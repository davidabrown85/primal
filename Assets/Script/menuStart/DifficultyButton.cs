using UnityEngine;


public class DifficultyButton : MonoBehaviour 
{
	
	public GameObject panel;
	private PanelScript _panelScript;

	public Sprite[] sprites;
	private SpriteRenderer _spriteRenderer;


	void Awake () {

		_spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		_spriteRenderer.sprite = sprites[1];

        float worldScreenHeight = Camera.main.orthographicSize*2f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		float worldScreenWidthHalf = worldScreenWidth / 2;
		float pos_x = worldScreenWidth / 7;
		
		transform.position = new Vector3 (-worldScreenWidthHalf + pos_x, transform.position.y, 0);

		_panelScript = (PanelScript)panel.GetComponent ("PanelScript");
	}


	void OnMouseUpAsButton() {
				
		//panelScript.shapeSetup ();

		/*if (Global.vars.difficulty == 3) {
			spriteRenderer.sprite = sprites[0];
		} else {
			spriteRenderer.sprite = sprites[1];
		}*/
	}
}