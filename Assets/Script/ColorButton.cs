using UnityEngine;

public class ColorButton : MonoBehaviour 
{
	
	public Sprite[] sprites;
	private SpriteRenderer spriteRenderer;

	public EnemyControl enemyControlScript;	
	public PanelScript panel;

	public string color;


	void Awake () {	
				
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		spriteRenderer.sprite = sprites[0];
	} 
	

	void OnMouseDown(){
				
		if (PauseButton.paused) return;

		panel.check_click ();
	}
	

	public void select() {
				
		panel.resetColors ();

		if (enemyControlScript.selectedShape == "") 
			panel.resetShapes ();

		spriteRenderer.sprite = sprites[1];
		transform.localScale = new Vector3( 1.2f, 1.2f, 0 );
				
		enemyControlScript.updateColor ( color );
	}

	
	public void unselect() {
				
		spriteRenderer.sprite = sprites[0];
		transform.localScale = new Vector3( 1f, 1f, 0 );
	}
}
