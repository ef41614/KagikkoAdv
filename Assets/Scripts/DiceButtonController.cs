﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DiceButtonController : MonoBehaviour {

	private GameObject DiceB;
	private int DiceResult = 0;
	GameObject unitychan; 
	UnityChanController Uscript; 
	public bool canRoll = true;
	public GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
	private GameObject stepTx;  //残り歩数
	GameObject turnmanager;
	TurnManager TurnMscript;
	GameObject pchan; 
	PchanController Pscript; 
	GameObject GuideM;
	guideController GuideC;
	GameObject fadeScript;
	FadeScript FadeSC;
	GameObject ArrowB;
    GameObject gameManager;
    GameManager GMScript;

    private float timeleft;
	public AudioClip DiceRollSE;
	private AudioSource audioSource;
	GameObject RollPart;
	public bool RollPartActive = false;
	public AudioClip RouletteSE;
	float RollAngle = 0.05f;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		unitychan = GameObject.Find ("unitychan"); 
		Uscript = unitychan.GetComponent<UnityChanController>(); 
		pchan = GameObject.Find ("pchan"); 
		Pscript = pchan.GetComponent<PchanController>(); 
		turnmanager = GameObject.Find ("turnmanager");
		TurnMscript = turnmanager.GetComponent<TurnManager>(); 
		Debug.Log("Diceスクリプト出席確認");
		this.stepTx = GameObject.Find("stepText");
		this.DiceB = GameObject.Find ("DiceRollButton");
		RollPart = GameObject.Find ("RollingPart");
		GuideM = GameObject.Find ("guideMaster");
		GuideC = GuideM.GetComponent<guideController> ();
		fadeScript = GameObject.Find ("blackpanel");
		FadeSC = fadeScript.GetComponent<FadeScript> ();
		ArrowB = GameObject.Find ("arrowButtons");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		audioSource = this.gameObject.GetComponent<AudioSource> ();
        gameManager = GameObject.Find("GameManager");
        GMScript = gameManager.GetComponent<GameManager>();
    }

	//####################################  Update  ###################################

	void Update () {

		//スペースが押されたらサイコロをふる
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			DiceRoll ();
//		}

		// 進めるマスが0 && サイコロふる準備ができたら、サイコロボタンを有効（再表示）にする
		if (canRoll == true) {
//			Debug.Log("DiceB.transform.rotation.y！"+DiceB.transform.rotation.y);
			if((DiceB.transform.rotation.y>RollAngle)||(DiceB.transform.rotation.y<-1*RollAngle)){
			DiceB.transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
			}else if ((DiceB.transform.rotation.y <=RollAngle)||(DiceB.transform.rotation.y>=-1*RollAngle)) {
				DiceB.transform.Rotate(new Vector3(0, 0, 0));
			}
			DiceB.SetActive (true);
//            GMScript.RouletteExist = true;
            var sequence = DOTween.Sequence();
            sequence.InsertCallback(0.5f, () => (GMScript.RouletteExist = true));
        } else if(canRoll == false){
			DiceB.SetActive (false);
            GMScript.RouletteExist = false;
        }

        RollPart.transform.Rotate(new Vector3(0, 0, -15));
		if (RollPartActive) {
            RollPart.SetActive (true);
        } else if (RollPartActive == false) {
			RollPart.SetActive (false);
        }
	}

	//####################################  other  ####################################

	IEnumerator WaitAndDiceSet(){
		yield return new WaitForSeconds (1.8f);
		DiceB.SetActive (true);
	}

	void DiceSet(){
		DiceB.SetActive (true);
	}

	//サイコロをふる処理
	public void DiceRoll() {
		Debug.Log("ルーレットを回せ！");
		this.DiceB = GameObject.Find ("DiceRollButton");
		if (DiceB != null) {
            GMScript.RouletteExist = true;
            int num = Random.Range (1, 11);
			Debug.Log("num :" +num);
			DiceResult = num;
//			if((TurnMscript.canMove1P == true)&&(TurnMscript.canMove2P == false)){
				if(TurnMscript.canMove1P == true){
//				Uscript.RemainingSteps = DiceResult;
				CharaMoveMscript.RemainingStepsInfo = DiceResult;
//				this.stepTx.GetComponent<Text> ().text = "あと " + (CharaMoveMscript.RemainingStepsInfo) + "マス";
			}
//			if((TurnMscript.canMove2P == true)&&(TurnMscript.canMove1P == false)){
				if(TurnMscript.canMove2P == true){
//				Pscript.RemainingSteps = DiceResult;
				CharaMoveMscript.RemainingStepsInfo = DiceResult;
//				this.stepTx.GetComponent<Text> ().text = "あと " + (CharaMoveMscript.RemainingStepsInfo) + "マス";
			}
			CharaMoveMscript.stepsLeft ();
			Debug.Log("サイコロ投げた！");
			Debug.Log("サイコロが止まった！ あと"+DiceResult+"マス動けます");
//			audioSource.PlayOneShot (DiceRollSE);
			audioSource.PlayOneShot (RouletteSE);
//			DiceB.transform.Translate (0,0,10);
			DiceB.transform.Rotate(new Vector3(0, 270, 0));
			Debug.Log("DiceButtonController からToUnderGround へ！！");//★＜現在抑止中＞
			GuideC.ToUnderGround ();	
			GuideC.initializePosition ();

			RollPartActive = true;
			var sequence = DOTween.Sequence();
			sequence.InsertCallback(0.8f, () =>(RollPartActive = false));
			sequence.InsertCallback(0.8f, () =>(canRoll = false));
//			canRoll = false;
		} else {
		}

	}

	//#################################################################################

}
// End
