using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimerController : MonoBehaviour {

	public Text timerText;
	public GameObject TimerBox;
	public float totalTime = 5.0f;
//	float bonus;
	int TimeMode =0;
	public GameObject Board;
	public GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;


	void Awake(){
		TimeMode = Random.Range(0, 100);
		totalTime = 5.0f;
	}
	//☆################☆################  Start  ################☆################☆

	void Start () {
		SetTime ();
	}

	//####################################  Update  ###################################

	void Update () {
		if (CharaMoveMscript.OnBoard) {
			if (totalTime > 0) {
				totalTime -= Time.deltaTime;
				if (CharaMoveMscript.RunningInfo) {
					activateTimerText ();
				}
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

	public void SetTime(){
		TimeMode = Random.Range(0, 100);
		totalTime = 5.0f;

		if (0<=TimeMode && TimeMode <= 40) {
			totalTime = 5.0f;
		} else if (41<=TimeMode && TimeMode  <= 70) {
			totalTime = 7.0f;
		} else if (71<=TimeMode && TimeMode  <= 85) {
			totalTime = 9.0f;
		} else if (86<=TimeMode && TimeMode  <= 95) {
			totalTime = 11.0f;
		} else if (96<=TimeMode && TimeMode  <= 100) {
			totalTime = 15.0f;
		} else {
			totalTime = 5.0f;
		}
		//		bonus = Random.Range(0.0f, 3.0f);
		//		totalTime = totalTime + bonus;
		totalTime = Mathf.Round(totalTime);

		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		deactivateTimerText ();
	}

	//#################################################################################

}
// End