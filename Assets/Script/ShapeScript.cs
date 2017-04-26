using UnityEngine;


public class ShapeScript : MonoBehaviour 
{
	
	public Sprite[] sprites;
	private SpriteRenderer spriteRenderer;

	private string[] colors = new string[] { "white", "red", "green", "blue", "cyan", "magenta", "yellow" };
	
	private string current_color;
	public string current_shape;
	
	public float r;
	public float g;
	public float b;


	void Awake () {
				
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	

	public void setRandomColor() {
				
		setColour ( colors [Random.Range (1, PanelScript.color_amount+1)] );
	}


	public void setColour( string color ) {
				
		current_color = color;
		r = g = b = 0;

		switch (color) {

			case "blank": spriteRenderer.sprite = sprites[0]; break;
			case "white": spriteRenderer.sprite = sprites[1]; r=g=b=1; break;
			case "red": spriteRenderer.sprite = sprites[2]; r=1; break;
			case "green": spriteRenderer.sprite = sprites[3]; g=1; break;
			case "blue": spriteRenderer.sprite = sprites[4]; b=1; break;
			case "cyan": spriteRenderer.sprite = sprites[5]; b=1;g=1; break;
			case "magenta": spriteRenderer.sprite = sprites[6]; r=1;b=1; break;
			case "yellow": spriteRenderer.sprite = sprites[7];r=1;g=1; break;
		}
	}

	
	public string shapeCode() {
		
		return current_color + current_shape;
    }
}
