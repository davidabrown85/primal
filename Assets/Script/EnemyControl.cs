using UnityEngine;
using System.Collections.Generic;

public class EnemyControl : MonoBehaviour 
{

	[HideInInspector] 
	public string selectedColor = null;
	[HideInInspector] 
	public string selectedShape = null;

	public GameObject trail;
	public GameObject[] enemies;
	public float spawnTime = 3;
	
	public int defaultHealth = 5;
	public ScoreScript health;
	public ScoreScript score;
			
	private List<GameObject> _pooledEnemies = new List<GameObject>();
	private List<GameObject> _pooledTrails = new List<GameObject>();
	private int _poolAmountEach = 5;

	private int[] _enemyRandomOrder;
	private int _enemyCounter = 0;

	private float[] _randomX = new float[6];

	private bool _intro;

	private ShapeButton _shapeBtn;


	void Awake()
	{
				
		foreach (GameObject enemy in enemies) {
						
			for ( int i = 0; i < _poolAmountEach; i++ ) {
								
				//Create Enemy
				GameObject newEnemy = GameObject.Instantiate( enemy, new Vector3( 0, 0, 10), Quaternion.identity ) as GameObject;
				_pooledEnemies.Add( newEnemy );
				
				//Create Enemy Trails	
				GameObject newTrail = GameObject.Instantiate( trail, new Vector3( 0, 0, 11), Quaternion.identity ) as GameObject;
				_pooledTrails.Add( newTrail );
			}
		}

		randomizeEnemies ();
		
		health.manual_score (defaultHealth);
		score.manual_score (0);
	}



	/****** ENEMY CONTROL *****/

	public void startEnemyFalling( bool fullscreen ) {
	
		_intro = fullscreen;

		setFallingRange ( fullscreen);

		resetEnemy ();

		InvokeRepeating("addEnemy", spawnTime, spawnTime);
	}


	private void addEnemy() {
				
		if (PauseButton.paused) return;

		GameObject newEnemy = nextEnemy();

		EnemyScript enemyScript = (EnemyScript) newEnemy.GetComponent ("EnemyScript");

		if (!enemyScript.GetComponent<Renderer>().enabled) { 
						
			enemyScript.startFall ( Random.Range (_randomX [0], _randomX [_randomX.Length-1]), _pooledTrails[_enemyCounter] );
		}
	}


	private GameObject nextEnemy() {
				
		if ( _enemyCounter >= _enemyRandomOrder.Length ) randomizeEnemies ();

		int enemyNum = _enemyRandomOrder [_enemyCounter];
		_enemyCounter += 1;

		return _pooledEnemies [ enemyNum ];
	}

	
	private void destroyEnemy( string enemyColor, string enemyShape ) {
	
		string shapeCode = enemyColor + enemyShape;

		foreach (GameObject enemy in _pooledEnemies) {
	
			EnemyScript enemyScript = (EnemyScript) enemy.GetComponent ("EnemyScript");
			if (enemyScript.falling && enemyScript.shapeCode() == shapeCode ) {
								
				enemyScript.destroyShape();

				score.increase_score(1);
			}
		}
	}


	public void randomizeEnemies() {
				
		_enemyRandomOrder = Array.CreateRandom( PanelScript.shape_amount * _poolAmountEach );

		_enemyCounter = 0;
	}
	
	
	public void resetEnemy() {	
				
		foreach( GameObject enemy in _pooledEnemies) {
						
			EnemyScript enemyScript = (EnemyScript) enemy.GetComponent ("EnemyScript");
			enemyScript.destroyShape (); 
			enemyScript.recycleShape();
		}
	}


	public void Update() {
				
		if ( PauseButton.paused ) return;

		foreach( GameObject enemy in _pooledEnemies) {
						
			EnemyScript enemyScript = (EnemyScript) enemy.GetComponent ("EnemyScript");
			if (enemyScript.falling) {
								
				bool landed = enemyScript.updatePosition();
				if( landed && !_intro ){
										
					health.decrease_score(1);
				}
			}
		}
	}


	/***** CONTROL USER SELECTION *****/

	public void updateColor( string newColor ) {
				
		selectedColor = newColor;
		
		if (selectedColor == "" || selectedShape == "") return;
		
		_shapeBtn.select ();
		destroyEnemy( selectedColor, selectedShape );
		selectedColor = selectedShape = "";
	}
	

	public void updateShape( string newShape, ShapeButton newShapeBtn ) {
				
		selectedShape = newShape; 
		_shapeBtn = newShapeBtn;
		if (selectedColor == "" || selectedShape == "") return;
		
		destroyEnemy( selectedColor, selectedShape );
		selectedColor = selectedShape = "";
	}




	/***** CONTROL FALLING RANGE *****/

	private void setFallingRange( bool fullScreen = false ) {
		
		if (fullScreen) {
						
			float worldHeight = ScreenSize.height;		
			float worldWidth = ScreenSize.width;
			
			_randomX [0] = -worldWidth / 2;
			_randomX [_randomX.Length - 1] = worldWidth / 2;
		} 
		else {
						
			float colorSize = enemies [0].GetComponent<Renderer>().bounds.size.y * 1.2f;
			float shapeMaxWidth = colorSize * (_randomX.Length - 1);
			float posX = -(shapeMaxWidth / 2);
			
			for (int i = 0; i < _randomX.Length; i++) {
				_randomX [i] = posX;
				posX += colorSize;
			}
		}
	}
}
