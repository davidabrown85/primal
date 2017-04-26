using UnityEngine;

public class Grid : MonoBehaviour 
{

	[HideInInspector] 
	private Vector2[,] _posList = new Vector2[6,6];


	void Awake () {
		
		float worldHeight = Camera.main.orthographicSize * 2f;		
		float worldWidth = worldHeight / Screen.height * Screen.width;
		float startX = -worldWidth / 2;
		float colWidth = worldWidth / 9;
		
		float startY = worldHeight / 2;
		float rowHeight = -worldHeight / 7;
		
		for( int x = 0; x < 6; x++ ) {
						
			for( int y = 0; y < 6; y++ ) {
								
				float posX = startX + colWidth * (x + 2f);
				float posY = startY + rowHeight * (y + 2f);

				_posList[x,y] = new Vector2(posX,posY);
			}
		}
	}


	public float randomCol() {
				
		return _posList [Random.Range (0, 6), 0].x;
	}
}
