﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	GameObject unitychan; 
	UnityChanController Uscript; 
	GameObject pchan; 
	PchanController Pscript; 
	private GameObject DiceB; 
	public DiceButtonController DiceC;
	GameObject imageManager;
	ImageManager ImageMscript;
	public GameObject GuideM;
	guideController GuideC;
	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;

	public bool canMove1P = true; 
	public bool canMove2P = false; 

	//☆################☆################  Start  ################☆################☆

	void Start () {
		Debug.Log("TurnMスクリプト出席確認");
		unitychan = GameObject.Find ("unitychan"); 
		Uscript = unitychan.GetComponent<UnityChanController>(); 
		pchan = GameObject.Find ("pchan"); 
		Pscript = pchan.GetComponent<PchanController>(); 
		DiceB = GameObject.Find ("DiceBox");
		DiceC = DiceB.GetComponent<DiceButtonController>(); 
		imageManager = GameObject.Find ("imageManager");
		ImageMscript = imageManager.GetComponent<ImageManager> ();
		GuideC = GuideM.GetComponent<guideController> ();
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
	}

	//####################################  Update  ###################################

	void Update () {

	}

	//####################################  other  ####################################

	public void ChangePlayer(){
	//	Debug.Log("★ターン切り替えスクリプト呼び出され");
		if((Uscript.RemainingSteps <=0)&&(canMove1P==true)&&(Uscript.UIsRunning==false)){
			if ((Uscript.UDiceTicket <= 0)&&(Pscript.PDiceTicket >0)) {
				if (CharaMoveMscript.OnBoard == false) {
					canMove1P = false;
					canMove2P = true;
					ChangePlayerProcess ();
				}
			}
		}else if((Pscript.RemainingSteps <=0)&&(canMove2P==true)&&(Pscript.PIsRunning==false)){
			if ((Pscript.PDiceTicket <= 0) && (Uscript.UDiceTicket > 0)) {
				if (CharaMoveMscript.OnBoard == false) {
					canMove1P = true;
					canMove2P = false;
					ChangePlayerProcess ();
				}
			}
		}
	}

	public void ChangePlayerProcess(){
		Uscript.UDiceTicket = 1;
		Pscript.PDiceTicket = 1;
		ImageMscript.ChangeFaceImage ();
		GuideC.ToUnderGround ();	
		GuideC.initializePosition ();
	}


	//#################################################################################

}
// End
