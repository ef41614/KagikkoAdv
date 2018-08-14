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

	public GameObject CamerasControllerBox;
	CamerasController CamerasControllerSC;
//	public GameObject Board;
	public FadeBoardScript FadeBoSC;

	void Awake(){
		TimeMode = Random.Range(0, 100);
		totalTime = 5.0f;
	}
	//☆################☆################  Start  ################☆################☆

	void Start () {
		SetTime ();
		CamerasControllerSC = CamerasControllerBox.GetComponent<CamerasController> ();

	}

	//####################################  Update  ###################################

	void Update () {
		if (CharaMoveMscript.OnBoard) {
			if (totalTime > 0) {
				totalTime -= Time.deltaTime;
				if (CharaMoveMscript.RunningInfo) {
					activateTimerText ();
				}
//					CamerasControllerBox = GameObject.Find ("CamerasControllerBox"); 
//					CamerasControllerSC = CamerasControllerBox.GetComponent<CamerasController> ();
				if (totalTime < 0.5f) {
//					FadeBoSC.goFadeOut = true;
					if (totalTime < 0.15f) {
						if (CamerasControllerSC.CharaViewActive) {
							Debug.Log ("カメラ上からに戻るよ");
							CamerasControllerSC.ChangeCharaCamera ();
						}
					}
				}
			}
			if (totalTime <= 0.02f) {
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
//		Board = GameObject.Find ("BoardPrefab(Clone)");
//		FadeBoSC = Board.GetComponent<FadeBoardScript>();

		TimeMode = Random.Range(0, 100);
		totalTime = 5.0f;

		if (0<=TimeMode && TimeMode <= 10) {
			totalTime = 3.0f;
		} else if (11<=TimeMode && TimeMode  <= 60) {
			totalTime = 5.0f;
		} else if (61<=TimeMode && TimeMode  <= 80) {
			totalTime = 7.0f;
		} else if (81<=TimeMode && TimeMode  <= 95) {
			totalTime = 8.0f;
		} else if (96<=TimeMode && TimeMode  <= 100) {
			totalTime = 10.0f;
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