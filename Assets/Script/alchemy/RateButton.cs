using UnityEngine;


public class RateButton : MonoBehaviour 
{
	public string appleId = "";
	public string apdroidUrl = "market://details?id=com.google.earth";


	private void OnMouseUpAsButton() {
				
		MobileNativeRateUs ratePopUp =  new MobileNativeRateUs("Like this game?", "Please rate to support future updates!");
		ratePopUp.SetAppleId( appleId );
		ratePopUp.SetAndroidAppUrl( apdroidUrl );
		ratePopUp.OnComplete += OnRatePopUpClose;
		
		ratePopUp.Start();
	}


	private void OnRatePopUpClose(MNDialogResult result)  {
				
		switch(result) {

			case MNDialogResult.RATED: break;
			case MNDialogResult.REMIND: break;
			case MNDialogResult.DECLINED: break;
		}	
	}
}
