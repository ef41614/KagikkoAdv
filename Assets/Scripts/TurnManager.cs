using System.Collections;
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
	public GameObject gameManager;
	GameManager GMScript;

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
		gameManager = GameObject.Find ("GameManager");
		GMScript = gameManager.GetComponent<GameManager> ();
	}

	//####################################  Update  ###################################

	void Update () {

	}

	//####################################  other  ####################################

	public void ChangePlayer(){
		Debug.Log("★ターン切り替えスクリプト呼び出され");
//		if((canMove1P==true)&&(Uscript.UIsRunning==false)){
		if((canMove1P==true)&&(CharaMoveMscript.RunningInfo==false)){
			Debug.Log ("★ターン切り替えスクリプト_1P:fase01");
			if (CharaMoveMscript.RemainingStepsInfo <= 0) {
					Debug.Log ("★ターン切り替えスクリプト_1P:fase02");
					if (CharaMoveMscript.OnBoard == false) {
						Debug.Log ("★ターン切り替えスクリプト_1P:fase03");
						canMove1P = false;
						canMove2P = true;
						ChangePlayerProcess ();
					}
			}

//		}else if((canMove2P==true)&&(Pscript.PIsRunning==false)){
		}else if((canMove2P==true)&&(CharaMoveMscript.RunningInfo==false)){
			Debug.Log("★ターン切り替えスクリプト_2P:fase01");
			if (CharaMoveMscript.RemainingStepsInfo <= 0) {
					Debug.Log ("★ターン切り替えスクリプト_2P:fase02");
					if (CharaMoveMscript.OnBoard == false) {
						Debug.Log ("★ターン切り替えスクリプト_2P:fase03");
						canMove1P = true;
						canMove2P = false;
						ChangePlayerProcess ();
					}
			}
		}
	}

	public void ChangePlayerProcess(){
		ImageMscript.ChangeFaceImage ();
		Debug.Log("TurnManager からToUnderGround へ！！＜現在抑止中じゃない＞ ");//★
		GuideC.ToUnderGround ();	
		GuideC.initializePosition ();
		Debug.Log("★◎★◎★◎★◎★◎★◎★◎★◎★◎ ターン変更完了 ★◎★◎★◎★◎★◎★◎★◎★◎★◎");
		GMScript.CreateBoard ();
		CharaMoveMscript.RemainingStepsInfo = 100;
	}


	//#################################################################################

}
// End
