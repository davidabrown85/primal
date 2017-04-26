using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour 
{

	public GUIText t;

	private int _the_score = 0;
	private int _target_score = 0;
	

	void Update ()  {
				
		if (_the_score == _target_score) return;

		if( _the_score < _target_score ) {
						
			_the_score += 1;
		}else {
						
			_the_score -= 1;
		}
		
		t.text = _the_score.ToString();
	}

	
	public void increase_score( int amount ) {
				
		_target_score += amount;
	}
	

	public void decrease_score( int amount ) {
				
		_target_score -= amount;
	}


	public void manual_score( int amount ) {
				
		_the_score = _target_score = amount;
		t.text = _the_score.ToString();
	}
	

	public void reset() {
				
		_the_score = _target_score = 0;
	}
}
