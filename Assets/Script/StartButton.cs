using UnityEngine;

public class StartButton : MonoBehaviour 
{
	
	public Animator startAnim;

	public EnemyControl enemyControl;
	public FadeControl fader;
	public PanelScript panel;
	public PauseButton pause;


	void Start () {
	
		showMenu ();
	}
	
	public void showMenu() {
						
		startAnim.SetBool ("showMenu", true);
		startAnim.SetBool("hideMenu", false);
		
		GetComponent<Collider2D>().enabled = true;

		fader.setFaderManually(.85f);
		enemyControl.startEnemyFalling ( true );
	}

	
	public void hideMenu() {
	
		startAnim.SetBool ("hideMenu", true);
		startAnim.SetBool("showMenu", false);
		
		GetComponent<Collider2D>().enabled = false;
	}


	void OnMouseUpAsButton() {
				
		hideMenu ();

		fader.fadeOut ();
		Invoke( "startGame", 1.2f );
	}


	public void startGame( ) {
				
		enemyControl.startEnemyFalling ( false );
		panel.gameStart ();
		pause.gameStart ();
	}
}
