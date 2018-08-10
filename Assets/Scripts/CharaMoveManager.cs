using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CharaMoveManager : MonoBehaviour {

	// 任意の移動スピード用変数
	private float RunTime = 0.7f;

	// あと何マス動けるか
	public int RemainingStepsInfo = 100;

	public Vector3 Player_pos; 
	public Vector3 NextPos;

	public Rigidbody rbInfo;
	public Animator myAnimator;
	public GameObject stepTx;  //残り歩数

//	public bool UIsRunning = false;
	[SerializeField]
	RectTransform rectTran;

	private bool canGoR = true;
	private bool canGoL = true;
	private bool canGoF = true;
	private bool canGoB = true;

	public GameObject dirR;
	public GameObject dirL;
	public GameObject dirF;
	public GameObject dirB;

	public GameObject DiceB; 
	DiceButtonController DiceC;
	public GameObject Arrowbox;
	public GameObject ArrowBtns;
	arrowButtonsController ArrowC;
	public GameObject GuideM;
	guideController GuideC;

	public bool ArrivedNextPoint = false;

	private GameObject unitychan;
	UnityChanController Uscript; 
	GameObject pchan; 
	PchanController Pscript; 
	public GameObject turnmanager;
	TurnManager TurnMscript;
	public GameObject blackpanel;
	FadeScript FadeSC;
	public GameObject CamerasControllerBox;
	CamerasController CamerasControllerSC;

	bool canMoveInfo;
	public bool RunningInfo;
//	public int TicketInfo = 0;
	public GameObject activeChara;
	GameObject activeCharaScript;

	public GameObject wall_Left;
	public GameObject wall_Right;
	public GameObject wall_Bottom;
	public GameObject wall_Top;

	public Vector3 LeftPos;
	public Vector3 RightPos;
	public Vector3 BottomPos;
	public Vector3 TopPos;

	public GameObject LangManager;
	LangManager LangMScript;
	public bool OnBoard = false;
	public float BoardSpeed = 8;

	public bool isFButtonDown = false;
	public bool isBButtonDown = false;
	public bool isLButtonDown = false;
	public bool isRButtonDown = false;

	public bool ExistFuture = true;
	float MoveForce = 2.0f;
	Vector3 moveDirection;

	//☆################☆################  Start  ################☆################☆
	void Start () {
		Debug.Log ("CharaMoveManagerスクリプト出席確認");

		Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
		rbInfo = GetComponent<Rigidbody>();
		myAnimator = GetComponent<Animator>();
//		this.stepTx = GameObject.Find("stepText");
//		this.myAnimator.SetBool ("isRunning", false);

//		DiceB = GameObject.Find ("DiceBox");
		DiceC = DiceB.GetComponent<DiceButtonController>(); 
//		Arrowbox = GameObject.Find ("ArrowsBox");
//		ArrowBtns = GameObject.Find ("arrowButtons");
		ArrowC = Arrowbox.GetComponent<arrowButtonsController>();
//		GuideM = GameObject.Find ("guideMaster");
		GuideC = GuideM.GetComponent<guideController> ();

		this.unitychan = GameObject.Find ("unitychan");
		Uscript = unitychan.GetComponent<UnityChanController>();
		pchan = GameObject.Find ("pchan"); 
		Pscript = pchan.GetComponent<PchanController>(); 
//		turnmanager = GameObject.Find ("turnmanager");
		TurnMscript = turnmanager.GetComponent<TurnManager>(); 
//		blackpanel = GameObject.Find ("blackpanel");
		FadeSC = blackpanel.GetComponent<FadeScript> ();

		CamerasControllerSC = CamerasControllerBox.GetComponent<CamerasController> ();

		ArrivedNextPoint = true;

//		wall_Left = GameObject.Find ("Cube_W");
//		wall_Right = GameObject.Find ("Cube_E");
//		wall_Bottom = GameObject.Find ("Cube_S");
//		wall_Top = GameObject.Find ("Cube_N");

		LeftPos = wall_Left.transform.position;
		LeftPos.x += 3; 
		RightPos = wall_Right.transform.position;
		RightPos.x -= 3;
		BottomPos = wall_Bottom.transform.position;
		BottomPos.z += 3;
		TopPos = wall_Top.transform.position;
		TopPos.z -= 3.5f;

		stepsLeft ();
	}

	//####################################  Update  ###################################

	void Update () {
			unitychan.transform.position = (new Vector3 (
			Mathf.Clamp (unitychan.transform.position.x, LeftPos.x, RightPos.x),
			Mathf.Clamp (unitychan.transform.position.y, -1, 3),
			Mathf.Clamp (unitychan.transform.position.z, BottomPos.z, TopPos.z)
		));
			
			pchan.transform.position = (new Vector3 (
			Mathf.Clamp (pchan.transform.position.x, LeftPos.x, RightPos.x),
			Mathf.Clamp (pchan.transform.position.y, -1, 3),
			Mathf.Clamp (pchan.transform.position.z, BottomPos.z, TopPos.z) 
		));

		if (TurnMscript.canMove1P == true) {
			canMoveInfo = TurnMscript.canMove1P;
//★			RunningInfo = Uscript.UIsRunning;
			//★rbInfo = unitychan.GetComponent<Rigidbody> ();
//			RemainingStepsInfo = Uscript.RemainingSteps;
//★			Uscript.RemainingSteps = RemainingStepsInfo;
//			RemainingStepsInfo = Uscript.RemainingSteps;
			Player_pos = unitychan.GetComponent<Transform>().position; 
			activeChara = unitychan;
			Uscript.Player_pos = Player_pos;
			myAnimator = unitychan.GetComponent<Animator> ();
			rbInfo = Uscript.rb;
//			activeCharaScript = Uscript;
//			Uscript.NextPos = NextPos;
		}

		if (TurnMscript.canMove2P == true) {
			canMoveInfo = TurnMscript.canMove2P;
//★			RunningInfo = Pscript.PIsRunning;
			//★rbInfo = pchan.GetComponent<Rigidbody> ();
//			RemainingStepsInfo = Pscript.RemainingSteps;
//			Pscript.RemainingSteps = RemainingStepsInfo;
			Player_pos = pchan.GetComponent<Transform>().position; 
			activeChara = pchan;
			Pscript.Player_pos = Player_pos;
			myAnimator = Pscript.GetComponent<Animator> ();
			rbInfo = Pscript.rb;
//			activeCharaScript = Pscript;
//			Pscript.NextPos = NextPos;
		}



		if (canMoveInfo == true) {

//			Debug.Log ("CharaMoveManagerからターン切り替えスクリプト呼び出し前5");
			if (ArrivedNextPoint == true) {
				// 走行中状態がOFF（＝停止状態）の時
//				this.myAnimator.SetBool ("isRunning", false);  

				//●◎〇---動けなくなった時の救済措置---●◎〇
				if(ArrowC.canMove == true){
					//				GameObject[] directions = GameObject.FindGameObjectsWithTag("guideChild");
					//				if (directions != null) {
					if((dirR)||(dirL)||(dirF)||(dirB)){
						Debug.Log("ターン中だよ。ガイドマスあるよ。");
						ExistFuture = true;
						//				}else{
					}else if((dirR==false)&&(dirL==false)&&(dirF==false)&&(dirB==false)){
						Debug.Log("ターン中だけど行き場がないよー");
						ExistFuture = false;

						if (isFButtonDown){
							//奥に移動
							//						rbInfo.AddForce (0,0,MoveForce);
							moveDirection = new Vector3 (0, 0, MoveForce);
							rbInfo.velocity = moveDirection;
							//activeChara.transform.rotation = Quaternion.AngleAxis (0, new Vector3 (0, 1, 0));
							activeChara.transform.rotation = Quaternion.Euler(0, 0f, 0);
							//						rbInfo.velocity = activeChara.transform.forward * 0.1f;
							HelperGuide();
						}
						if (isBButtonDown){
							//手前に移動
							//						rbInfo.AddForce (0,0,-MoveForce);
							moveDirection = new Vector3 (0, 0, -MoveForce);
							rbInfo.velocity = moveDirection;
							//activeChara.transform.rotation = Quaternion.AngleAxis (0, new Vector3 (180, 1, 0));
							activeChara.transform.rotation = Quaternion.Euler(0, 180f, 0);
							//						rbInfo.velocity = activeChara.transform.forward * 0.1f;
							HelperGuide();
						}
						if (isLButtonDown){
							//左に移動
							//						rbInfo.AddForce (-MoveForce, 0, 0);
							moveDirection = new Vector3 (-MoveForce,0,0);
							rbInfo.velocity = moveDirection;
							//activeChara.transform.rotation = Quaternion.AngleAxis (0, new Vector3 (-90, 1, 0));
							activeChara.transform.rotation = Quaternion.Euler(0, -90f, 0);
							//						rbInfo.velocity = activeChara.transform.forward * 0.1f;
							HelperGuide();
						}
						if (isRButtonDown){
							//右に移動
							//						rbInfo.AddForce (MoveForce, 0, 0);
							moveDirection = new Vector3 (MoveForce,0,0);
							rbInfo.velocity = moveDirection;
							//activeChara.transform.rotation = Quaternion.AngleAxis (0, new Vector3 (90, 1, 0));
							activeChara.transform.rotation = Quaternion.Euler(0, 90f, 0);
							//						rbInfo.velocity = activeChara.transform.forward * 0.1f;
							HelperGuide();
						}
					}
				}
				//●◎〇-----------------------------------●◎〇

				RunningInfo = false;
				if (RemainingStepsInfo > 0) {
					checkNextMove ();
					ArrowC.canMove = true;
//					Debug.Log ("CharaMoveManagerからターン切り替えスクリプト呼び出し前4");
				} else if (RemainingStepsInfo <= 0) {
//					Debug.Log ("CharaMoveManagerからターン切り替えスクリプト呼び出し前3");
//						Debug.Log ("CharaMoveManagerからターン切り替えスクリプト呼び出し前2");
//						if (rbInfo.IsSleeping ()) {
							DiceC.canRoll = true;
							ArrowC.canMove = false;
							Debug.Log ("CharaMoveManagerからターン切り替えスクリプト呼び出し前");
//						Invoke ("TurnMscript.ChangePlayer", 1.0f);
//					TurnMscript.ChangePlayer ();
						if(OnBoard==false){
							StartCoroutine("WaitAndTurnChange");
							Debug.Log ("CharaMoveManagerからターン切り替えスクリプト呼び出し後");
						}
				}

			} else {
//				this.myAnimator.SetBool ("isRunning", true);
				RunningInfo = true;
				ArrivedNextPoint = false;

			}
		} else {
			// 走行中状態がOFF（＝停止状態）の時
//			this.myAnimator.SetBool ("isRunning", false);  
			RunningInfo = false;
		}
			
		if (OnBoard == true) {
//			rbInfo.MovePosition(transform.position + transform.forward * Time.deltaTime);
//			Vector3 moveVector = transform.forward.normalized * 5000;
				rbInfo.velocity = activeChara.transform.forward * BoardSpeed;
				this.myAnimator.SetBool ("OnBoard", true);
				RunningInfo = true;
				Debug.Log ("ボードに乗っているよ");

				activeChara.transform.position = (new Vector3 (
					Mathf.Clamp (activeChara.transform.position.x, LeftPos.x, RightPos.x),
					Mathf.Clamp (activeChara.transform.position.y, 0.20f, 0.21f),
//				Mathf.Clamp (activeChara.transform.position.y, 0.5f, 0.51f),
					Mathf.Clamp (activeChara.transform.position.z, BottomPos.z, TopPos.z)
				));
		}
		if (OnBoard == false) {
			this.myAnimator.SetBool ("OnBoard", false);
			activeChara.transform.position = (new Vector3 (
				Mathf.Clamp (activeChara.transform.position.x, LeftPos.x, RightPos.x),
				Mathf.Clamp (activeChara.transform.position.y, 0.0f, 0.05f),
				Mathf.Clamp (activeChara.transform.position.z, BottomPos.z, TopPos.z)
			));
		}
	}

	//####################################  other  ####################################

	IEnumerator WaitAndTurnChange(){
		yield return new WaitForSeconds(0.8f);
		Debug.Log ("WaitAndTurnChange 呼び出され中");
		if (OnBoard == false) {
			Debug.Log ("WaitAndTurnChange の中で OnBoard == false");
			FadeSC.goFadeOut = true;
			FadeSC.goFadeIn = false;
//		GuideC.initializePosition ();

			var sequence = DOTween.Sequence();
			sequence.InsertCallback(0.8f, () =>(TurnMscript.ChangePlayer ()));
			sequence.InsertCallback(0.8f, () =>(FadeSC.goFadeOut = false));
			sequence.InsertCallback(0.8f, () =>(FadeSC.goFadeIn = true));
			sequence.InsertCallback(0.8f, () =>(CamerasControllerSC.inactiveMapCamera ()));
			sequence.InsertCallback(0.8f, () =>(CamerasControllerSC.inactiveCharaCamera ()));
			//yield return new WaitForSeconds (0.8f);
//		GuideC.initializePosition ();
			//TurnMscript.ChangePlayer ();
//		GuideC.initializePosition ();
			//FadeSC.goFadeOut = false;
			//FadeSC.goFadeIn = true;
			//CamerasControllerSC.inactiveMapCamera ();
			//CamerasControllerSC.inactiveCharaCamera ();
		}
	}

	public void checkNextMove(){
		this.dirR = GameObject.Find ("directionR");
		this.dirL = GameObject.Find ("directionL");
		this.dirF = GameObject.Find ("directionF");
		this.dirB = GameObject.Find ("directionB");

		if (dirR != null) {
			canGoR = true;
		} else {
			canGoR = false;
		}

		if (dirL != null) {
			canGoL = true;
		} else {
			canGoL = false;
		}

		if (dirF != null) {
			canGoF = true;
		} else {
			canGoF = false;
		}

		if (dirB != null) {
			canGoB = true;
		} else {
			canGoB = false;
		}



	}

//	public int reduceSteps(int stp){
//		stp -= 1;
//		return stp;
//	}

	//------------------------------------------------

	public void MoveForward() {
		MoveNextPosition (0,3,0,canGoF);
	}

	public void MoveBack() {
		MoveNextPosition (0,-3,180,canGoB);
	}

	public void MoveLeft() {
		MoveNextPosition (-3,0,-90,canGoL);
	}

	public void MoveRight() {
		MoveNextPosition (3,0,90,canGoR);
	}

	public void MoveNextPosition(int x, int z, int turn, bool canGoDir){
		if (canMoveInfo == true) {
			if (ArrivedNextPoint == true) {
				RunningInfo = false;
				if (RemainingStepsInfo > 0) {
					if (canGoDir == true) {
//						Player_pos = GetComponent<Transform> ().position;
//						Debug.Log("Player_pos 修正前:"+Player_pos);
						FixPosition ();
//						Debug.Log("Player_pos 修正後:"+Player_pos);
						NextPos = Player_pos + (new Vector3 (x, 0, z));

						activeChara.transform.DOLocalMove (NextPos, RunTime);
						activeChara.transform.rotation = Quaternion.AngleAxis (turn, new Vector3 (0, 1, 0));


						Debug.Log("CharaMoveManager からToUnderGround へ！！");
						GuideC.ToUnderGround ();	
						GuideC.adjustNextGuidePos ();
//						ArrowC.activateArrowButton ();
						RemainingStepsInfo -= 1;
						Debug.Log("歩数「1」減らしたよ！！");
						stepsLeft ();
					}
				} else {

				}
			}
		}
	}

	public void stepsLeft(){
		LangManager = GameObject.Find ("LangManager");
		LangMScript = LangManager.GetComponent<LangManager> ();

		if (LangMScript.LangMode == 1) {
			if (RemainingStepsInfo > 90) {
				this.stepTx.GetComponent<Text> ().text = "0 steps left";
			} else if (RemainingStepsInfo <= 90) {
				this.stepTx.GetComponent<Text> ().text = (RemainingStepsInfo) + " steps left";
			}
		}
		if (LangMScript.LangMode == 2) {
			if (RemainingStepsInfo > 90) {
				this.stepTx.GetComponent<Text> ().text = "あと0マス";
			} else if (RemainingStepsInfo <= 90) {
				this.stepTx.GetComponent<Text> ().text = "あと " + (RemainingStepsInfo) + "マス";
			}
		}
	}

	//---------------------------------------


	void FixPosition(){
//		this.stepTx.GetComponent<Text> ().text = "あと " + RemainingStepsInfo + "マス";
		Debug.Log ("修正中");
		Player_pos.x = Mathf.RoundToInt ( ((Player_pos.x)/3)*3);
		Debug.Log ("Player_pos.x % 3 は"+ Player_pos.x % 3);
		if ((Player_pos.x % 3 == 2)||(Player_pos.x % 3 == -1)) {
			Player_pos.x ++;
			Debug.Log ("ｘ++修正完了");
		} else if ((Player_pos.x % 3 == 1)||(Player_pos.x % 3 == -2)) {
			Player_pos.x --;
			Debug.Log ("ｘ--修正完了");
		}

		Player_pos.z = Mathf.RoundToInt ( ((Player_pos.z)/3)*3);
			if ((Player_pos.z % 3 == 2)||(Player_pos.z % 3 == -1)) {
			Player_pos.z ++;
			Debug.Log ("ｚ++修正完了");
		} else if ((Player_pos.z % 3 == 1)||(Player_pos.z % 3 == -2)) {
			Player_pos.z --;
			Debug.Log ("ｚ--修正完了");
		}
	}
		
	public void StartRunning(){
		RunningInfo = true;		
	}


	public void Get_F_ButtonDown() {
		this.isFButtonDown = true;
	}
	public void Get_F_ButtonUp() {
		this.isFButtonDown = false;
	}
		
	public void Get_B_ButtonDown() {
		this.isBButtonDown = true;
	}
	public void Get_B_ButtonUp() {
		this.isBButtonDown = false;
	}
		
	public void Get_L_ButtonDown() {
		this.isLButtonDown = true;
	}
	public void Get_L_ButtonUp() {
		this.isLButtonDown = false;
	}
		
	public void Get_R_ButtonDown() {
		this.isRButtonDown = true;
	}
	public void Get_R_ButtonUp() {
		this.isRButtonDown = false;
	}
		
	public void GuideToCharapos(){
		GuideC.ToUnderGround ();
		GuideC.initializePosition ();
	}

	public void HelperGuide(){
		GuideToCharapos ();
		var sequence = DOTween.Sequence();
		if ((dirR == false) && (dirL == false) && (dirF == false) && (dirB == false)) {
			sequence.InsertCallback (0.5f, () => (GuideToCharapos ()));
		}
		if ((dirR == false) && (dirL == false) && (dirF == false) && (dirB == false)) {
			sequence.InsertCallback (1.0f, () => (GuideToCharapos ()));
		}
	}
		
	//#################################################################################

}
// End
