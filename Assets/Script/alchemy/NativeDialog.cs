using UnityEngine;


public class NativeDialog : MonoBehaviour
{

	public void showDialog () {
				
		MobileNativeDialog dialog = new MobileNativeDialog("Dialog Titile", "Dialog message");
		dialog.OnComplete += OnDialogClose;
	}


	private void OnDialogClose(MNDialogResult result) {
				
		switch(result) {

			case MNDialogResult.YES: break;
			case MNDialogResult.NO: break;			
		}
	}
}

