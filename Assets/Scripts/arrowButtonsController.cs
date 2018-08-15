using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class arrowButtonsController : MonoBehaviour {
	
	private GameObject ArrowB;
	GameObject unitychan; 
	UnityChanController Uscript;
	public bool canMove = false;

	public GameObject UchanCamera;
	public GameObject PchanCamera;
	public GameObject UchanMapCamera;
	public GameObject PchanMapCamera;

//	public GameObject CamerasControllerBox;
//	CamerasController CamerasControllerSC;

	public GameObject ViewButtons;
	public Button ButtonF;
	public Button ButtonB;
	public Button ButtonL;
	public Button ButtonR;
	public GameObject SearchButtons;

	public bool ActiveArrowButton = true;

	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
	int checkArrow = 0;
	float mini = 0.5f;
	float original = 1;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		unitychan = GameObject.Find ("unitychan"); 
		Uscript = unitychan.GetComponent<UnityChanController>(); 
		Debug.Log("Arrowスクリプト出席確認");
		ArrowB = GameObject.Find ("arrowButtons");

		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
	}

	//####################################  Update  ###################################

	void Update () {
		if (CharaMoveMscript.RemainingStepsInfo > 70) {
			ArrowB.SetActive (false);	
			ActiveArrowButton = false;
			checkArrow = 1;
		} else if(checkArrow ==1) {
			ActiveArrowButton = true;
			checkArrow = 0;
		}

		// 勧めるマスが0より大きい時、移動矢印ボタンを有効（再表示）にする
		if(canMove == true){
			if(ActiveArrowButton){
				if ((UchanCamera.activeSelf) || (PchanCamera.activeSelf)) {
				ArrowB.SetActive (false);	
//				ViewButtons.SetActive (true);
				} else {
					ArrowB.SetActive (true);
//				ViewButtons.SetActive (false);
				}
			}
		} else {
			ArrowB.SetActive (false);
//			ViewButtons.SetActive (false);
		}


		if ((UchanCamera.activeSelf) || (PchanCamera.activeSelf)) {
			ArrowB.SetActive (false);
			ViewButtons.SetActive (true);
		} else {
//			ArrowB.SetActive (true);
			ViewButtons.SetActive (false);
		}

		if ((UchanMapCamera.activeSelf) || (PchanMapCamera.activeSelf)) {
			ArrowB.SetActive (false);
			SearchButtons.SetActive (true);
		}else{
//			ArrowB.SetActive (true);
			SearchButtons.SetActive (false);
		}

		//もしキャラ視点カメラがアクティブなら、移動矢印ボタンを無効（非表示）にする
//		if ((UchanCamera==false) && (PchanCamera==false)) {
//			ArrowB.SetActive (true);
//		} else {
//			ArrowB.SetActive (false);	
//		}


	}

	//####################################  other  ####################################

	//矢印ボタン一時無効化
	public void deactivateArrowButton(){
		if(CharaMoveMscript.ExistFuture){
		Debug.Log("矢印ボタン一時無効化");
//		ArrowB.interactable = false;
		ButtonF.interactable = false;
		ButtonB.interactable = false;
		ButtonL.interactable = false;
		ButtonR.interactable = false;
		ActiveArrowButton = false;
//		ArrowB.SetActive (false);	

		var sequence = DOTween.Sequence();
		sequence.InsertCallback(0.5f, () =>(activateArrowButton()));
		}
	}

	//矢印ボタン有効化
	public void activateArrowButton(){
		Debug.Log("矢印ボタン有効化");
		ButtonF.interactable = true;
		ButtonB.interactable = true;
		ButtonL.interactable = true;
		ButtonR.interactable = true;
		ActiveArrowButton = true;
	}

	public void smallButtonF(){
		ButtonF.transform.localScale = new Vector3(mini,mini,mini);
	}
	public void smallButtonB(){
		ButtonB.transform.localScale = new Vector3(mini,mini,mini);
	}
	public void smallButtonL(){
		ButtonL.transform.localScale = new Vector3(mini,mini,mini);
	}
	public void smallButtonR(){
		ButtonR.transform.localScale = new Vector3(mini,mini,mini);
	}

	public void normalSizeButtonF(){
		ButtonF.transform.localScale = new Vector3(original,original,original);
	}
	public void normalSizeButtonB(){
		ButtonB.transform.localScale = new Vector3(original,original,original);
	}
	public void normalSizeButtonL(){
		ButtonL.transform.localScale = new Vector3(original,original,original);
	}
	public void normalSizeButtonR(){
		ButtonR.transform.localScale = new Vector3(original,original,original);
	}

	//#################################################################################

}
// End