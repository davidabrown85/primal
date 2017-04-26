using UnityEngine;


public class ShapeButton : MonoBehaviour 
{

	public EnemyControl enemyControlScript;

	public ShapeScript shapeScript;
	public PanelScript panel;


	
	void OnMouseDown() {
				
		if (PauseButton.paused) return;

		select ();
	}


	public void select() {
				
		panel.resetShapes ();

		transform.localScale = new Vector3( 1.2f, 1.2f, 0 );

		if ( enemyControlScript.selectedColor == "" ) 
			shapeScript.setColour( "white" );
		else
			shapeScript.setColour( enemyControlScript.selectedColor );
				
		if (enemyControlScript.selectedColor == "") 
			panel.resetColors ();

		enemyControlScript.updateShape ( shapeScript.current_shape, this );
	}
	

	public void unselect() {
				
		shapeScript.setColour( "blank" );
		transform.localScale = new Vector3( 1f, 1f, 0 );
	}
}
