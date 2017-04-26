using UnityEngine;


public class EnemyScript : MonoBehaviour 
{
	
	[HideInInspector] public bool falling = false;
	[HideInInspector] public bool inUse = false;
	
	public float moveMin = .01f;
	public float moveMax = .04f;
	private Vector3 _moveVec;
	
	private ShapeScript _shapeScript;
	private Animator _anim;
	private float _floor;	
	private GameObject trail;


	void Awake() {
				
		_shapeScript = GetComponent<ShapeScript> ();
		_anim = GetComponent<Animator> ();
		GetComponent<Renderer>().enabled = inUse = false;

		_floor = -Camera.main.orthographicSize - GetComponent<Renderer>().bounds.size.y;
	}

	
	public void startFall( float startX, GameObject newTrail ) {
				
		trail = newTrail;
		_moveVec = new Vector3( 0, -Random.Range(moveMin, moveMax), 0 );

		_shapeScript.setRandomColor ();

		Renderer quadRenderer = trail.GetComponentInChildren<Renderer> ();
		Color newColor = quadRenderer.material.color;
		newColor.r = _shapeScript.r;
		newColor.g = _shapeScript.g;
		newColor.b = _shapeScript.b;
		newColor.a = .2f;
		quadRenderer.material.color = newColor;
		trail.transform.localScale = new Vector3(.6f,0,1f);
		trail.transform.position = new Vector3( startX, Camera.main.orthographicSize, trail.transform.position.z );

		transform.position = new Vector3 ( startX, Camera.main.orthographicSize, transform.position.z );

		_anim.SetBool ("AnimFalling", true);
		GetComponent<Renderer>().enabled = inUse = true;
		falling = true;
	}
		
	
	public void destroyShape() {
				
		_anim.SetBool ("AnimFalling", false);
		falling = false;
	}	


	public void recycleShape() {
				
		GetComponent<Renderer>().enabled = inUse = false;
		if(trail) trail.transform.localScale = new Vector3(.6f,0,1f);
    }
    

	public string shapeCode() {
				
		return _shapeScript.shapeCode();
    }
    

	public bool updatePosition () {
				
		transform.position += _moveVec;

		float newS = Mathf.Abs( Camera.main.orthographicSize - transform.position.y );
		trail.transform.localScale = new Vector3(.6f,newS,1f);

		if( transform.position.y < _floor ){
			falling = false; 
			recycleShape();
			return true;
		}

		return false;
	}
}
