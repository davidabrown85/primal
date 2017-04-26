using UnityEngine;

public class Array : MonoBehaviour 
{
	
	public static int[] CreateRandom( int amount ) {
				
		int[] arr = Create( amount );
		Shuffle (arr);
		
		return arr;
	}
	

	public static int[] Create( int amount ) {
				
		int[] arr = new int[ amount ];
		for (int i = 0; i < amount; i++) arr[i] = i;
		
		return arr;
	}
	

	public static void Shuffle<T>( T[] arr ) {
				
		for (int i = arr.Length-1; i > 0; i--) {
		
			int r = Random.Range(0,i);
			T tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}
	}
}
