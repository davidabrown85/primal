using UnityEngine;


public class PanelScript : MonoBehaviour 
{
	
	public ColorButton[] colors;
	public ShapeButton[] shapes;
	
	[HideInInspector] public static int color_amount = 4;
	[HideInInspector] public static int shape_amount = 4;

	public GUIText guiText;

	private float _worldWidth;


	void Awake() {	
				
		float worldHeight = Camera.main.orthographicSize * 2f;		
		_worldWidth = worldHeight / Screen.height * Screen.width;
		colorSetup ();
		shapeSetup ();
	}
	
	private void colorSetup() {	
				
		float colorSize = colors[0].GetComponent<Collider2D>().bounds.size.y;
		float shapeMaxHeight = colorSize * (color_amount-1);
		
		float pos_x = ( _worldWidth / 2 ) + ( colors [0].GetComponent<Collider2D>().bounds.size.x / 2 );
		float pos_y = ( shapeMaxHeight / 2 );
		
		for( int i = 0; i < colors.Length; i++ ) {
						
			colors[i].GetComponent<Renderer>().enabled = ( i < color_amount );
			colors[i].transform.position = new Vector3 ( pos_x, pos_y, 0);
			pos_y -= colorSize;
		}
	}
	 
	private void shapeSetup() {
				
		float shapeSize = shapes[0].GetComponent<Collider2D>().bounds.size.y;
		float shapeMaxHeight = shapeSize * (shape_amount-1);

		float pos_x = ( -_worldWidth / 2 ) - ( shapes[0].GetComponent<Collider2D>().bounds.size.x / 2 );
		float pos_y = ( shapeMaxHeight / 2 );
		
		for( int i = 0; i < shapes.Length; i++ ) {
						
			shapes[i].GetComponent<Renderer>().enabled = ( i < shape_amount );
			shapes[i].transform.position = new Vector3 ( pos_x, pos_y, 0);
			pos_y -= shapeSize;
		}
	}
	
	private void showColors() {
				
		float pos_x = ( _worldWidth / 2 ) - ( colors [0].GetComponent<Collider2D>().bounds.size.x / 2 );
		for( int i = 0; i < color_amount; i++ ){
			LeanTween.moveX( colors[i].gameObject, pos_x, 1f).setEase( LeanTweenType.easeOutBack );
		}
	}
	
	private void hideColors() {
				
		float pos_x = ( _worldWidth / 2 ) + ( colors [0].GetComponent<Collider2D>().bounds.size.x / 2 );
		for( int i = 0; i < color_amount; i++ ){
			LeanTween.moveX( colors[i].gameObject, pos_x, .5f).setEase( LeanTweenType.easeInBack );
		}
	}
	
	private void showShapes(){
		float pos_x = ( -_worldWidth / 2 ) + ( shapes[0].GetComponent<Collider2D>().bounds.size.x / 2 );
		for( int i = 0; i < shape_amount; i++ ){
			LeanTween.moveX( shapes[i].gameObject, pos_x, 1f).setEase( LeanTweenType.easeOutBack );
		}		
	}
	
	private void hideShapes() {
				
		float pos_x = ( -_worldWidth / 2 ) - ( shapes[0].GetComponent<Collider2D>().bounds.size.x / 2 );
		for( int i = 0; i < shape_amount; i++ ){
			LeanTween.moveX( shapes[i].gameObject, pos_x, .5f).setEase( LeanTweenType.easeInBack );
		}	
	}


	public void check_click() {
				
		Vector3 mouseClick = Input.mousePosition;
		Vector3 screenPoint = Camera.main.ScreenToWorldPoint( mouseClick );
		screenPoint.z = 0;
		guiText.text = "touchPos3D: "+screenPoint+ ", bounds: "+colors[1].GetComponent<BoxCollider2D>().bounds;
		
		for( int j = 0; j < color_amount; j++ ) {

			if( colors[j].GetComponent<BoxCollider2D>().bounds.Contains( screenPoint ) ) {
				colors[j].select();
				Debug.Log ("click");
			}
		}
		
		for( int k = 0; k < shape_amount; k++ ) {
						
			if( shapes[k].GetComponent<BoxCollider2D>().bounds.Contains( screenPoint ) ) shapes[k].select();
		}
	}

	public void Update () {	
				
		if (Input.touchCount == 0 || PauseButton.paused) return;
		
		for (int i = 0; i < Input.touchCount; i++) {
						
			Touch t = Input.GetTouch (i);

			if (t.phase == TouchPhase.Began) {
								
				Vector3 touchPos3D = new Vector3( t.position.x, t.position.y, 1 );
				Vector3 screenPoint = Camera.main.ScreenToWorldPoint( touchPos3D );
				screenPoint.z = 0;

				for( int j = 0; j < color_amount; j++ ) {
										
					if( colors[j].GetComponent<BoxCollider2D>().bounds.Contains( screenPoint ) ){ colors[j].select(); }
				}

				for( int k = 0; k < shape_amount; k++ ) {
										
					if( shapes[k].GetComponent<BoxCollider2D>().bounds.Contains( screenPoint ) ){ shapes[k].select(); }
				}
			}
		}
	}
	
	
	public void gameStart() {
				
		showColors ();
		showShapes ();
	}
	
	public void gamePause() {
				
		hideColors ();
		hideShapes ();
	}

	public void resetColors() {
				
		for( int i = 0; i < color_amount; i++ ) {
			colors[i].unselect();
		}
	}
	
	public void resetShapes() {
				
		for( int i = 0; i < shape_amount; i++ ) {
			shapes[i].unselect();
		}
	}
}
