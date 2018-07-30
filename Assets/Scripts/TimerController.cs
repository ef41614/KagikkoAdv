using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimerController : MonoBehaviour {

	public Text timerText;
	public GameObject TimerBox;
	public float totalTime;
	float bonus;

	public GameObject Board;
	public GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		totalTime = Random.Range(5.0f, 10.0f);
		bonus = Random.Range(0.0f, 3.0f);
		totalTime = totalTime + bonus;
		totalTime = Mathf.Round(totalTime);

		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		deactivateTimerText ();
	}

	//####################################  Update  ###################################

	void Update () {
		if (CharaMoveMscript.OnBoard) {
			if (totalTime > 0) {
				totalTime -= Time.deltaTime;
				activateTimerText ();
			}
			if (totalTime <= 0) {
				totalTime = 0.00f;
			}
			timerText.text = totalTime.ToString ("F2"); //小数2桁にして表示
		}
	}

	//####################################  other  ####################################

	//TimerText一時無効化
	public void deactivateTimerText(){
		Debug.Log("TimerText一時無効化");
		//		ArrowB.interactable = false;
//		timerText.interactable = false;
		TimerBox.SetActive (false);
	}

	//TimerText有効化
	public void activateTimerText(){
		Debug.Log("TimerText有効化");
		//		ArrowB.interactable = false;
		//		timerText.interactable = false;
		TimerBox.SetActive (true);
	}

	//#################################################################################

}
// End