using UnityEngine;
using System.Collections;
using DG.Tweening;

public class QuitApplication : MonoBehaviour {

	[SerializeField]
	RectTransform rectTran;

	public void Quit()
	{
		//If we are running in a standalone build of the game
	#if UNITY_STANDALONE
		//Quit the application
		var sequence = DOTween.Sequence();
//		sequence.InsertCallback(1.5f, () =>(Application.Quit();));
		Application.Quit();
	#endif

		//If we are running in the editor
	#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
	#endif
	}
}
