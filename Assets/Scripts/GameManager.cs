using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class GameManager : MonoBehaviour {

	public AudioClip getKeySE;
	public AudioClip ArriveTreasureSE;
	public AudioClip CrashPlayerSE_small;
	public AudioClip CrashPlayerSE_big;
	public AudioClip fieldBGM;
	public AudioSource FieldBGM;
	private AudioSource audioSource;

	public GameObject TreasurePrefab;
	public GameObject KeyPrefab;
	public GameObject BoardPrefab;
	GameObject[] tagBoards;

	public Vector3 appearPosition;
	public Vector3 appearBoardPosition;
	private int rndNum = 0;
	private int lastTimeNum = 0;
	private int lastBoardNum = 0;

	GameObject Mewindow;
	public Text targetText; 
	public bool messageOrder = false;
	public string sentence = "";
	public float waitTime =0;
	GameObject graypanel;
	FadeGoalScript FadeGoalSC;
	GameObject blackpanel;
	FadeScript FadeSC;
	GameObject CanvasGoal;
	GoalManager GoalM;
	public GameObject timerManager;
	TimerController TimerSC;
	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
	FadeBoardScript FadeBoSC;
	GameObject polygon;


	public GameObject titleM;
	public GameObject titleMSC;

	public GameObject menu_UI;
	public GameObject menuPanel;
	public GameObject menuButtons;
	public GameObject loading;
	public GameObject titleLogo;
	public GameObject Buttons;
	public GameObject image1black;
	public GameObject startButton;
	public GameObject quit;
	public GameObject optionsButton;
	public GameObject fountain;
	Vector3 ftPos;

//	public GameObject CreditPanel;
//	public GameObject HowToPlayPanel;


	void Awake(){

	}

	//☆################☆################  Start  ################☆################☆

	void Start () {
//		titleM = GameObject.Find ("titleManager");
//		titleMSC = titleM.GetComponent<TitleManager> ().gameObject;
//		titleMSC.StartMainScene ();
//		StartMainScene ();
		audioSource = this.gameObject.GetComponent<AudioSource> ();
		CreateKey ();
		CreateBoard ();
//		CreateBoard ();

		Mewindow = GameObject.Find ("MeWindow");
		Mewindow.gameObject.SetActive (false);
//		graypanel = GameObject.Find ("graypanel");
//		FadeGoalSC = graypanel.GetComponent<FadeGoalScript> ();
		CanvasGoal = GameObject.Find ("CanvasGoal");
		GoalM = CanvasGoal.GetComponent<GoalManager> ();
		timerManager = GameObject.Find ("TimerManager");
		TimerSC = timerManager.GetComponent<TimerController> ();
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		polygon = GameObject.Find ("Polygon");
		FadeBoSC = polygon.GetComponent<FadeBoardScript>();
		ftPos = fountain.transform.position;
	}


	//####################################  Update  ###################################

	void Update () {
	//	if (messageOrder == true) {
	//		ActiveMewindow ();
	//	} else if (messageOrder == false) {
	//		InactiveMewindow ();
	//	}

	}

	//####################################  other  ####################################

	public void StartMainScene(){
		menuPanel.SetActive (true);
		loading.SetActive (false);
		titleLogo.SetActive (false);
		menuButtons.SetActive (true);
		startButton.SetActive(false);
		quit.SetActive (false);
		optionsButton.SetActive (true);

//		CreditPanel.SetActive (false);
//		HowToPlayPanel.SetActive (false);
	}


	// -----メッセージウィンドウ---------------------

	public void ActiveMewindow(){
		Mewindow.gameObject.SetActive(true);
		StartCoroutine("DelayMethod");
	}

	public void InactiveMewindow(){
		Mewindow.gameObject.SetActive(false);
	}

	public void DisplayMessage(){
		this.targetText = Mewindow.GetComponentInChildren<Text>();
		this.targetText.text = sentence; 
	}

	public IEnumerator DelayMethod(){
		yield return new WaitForSeconds(waitTime);
		InactiveMewindow ();
	}

	// -------------------------------------------------

	public void HaltBGM(){
		AudioSource AudioSourceComponent = GameObject.Find("FieldBGM").GetComponent<AudioSource>();

		// 一時停止
		AudioSourceComponent.Pause();

//		audioSource = fieldBGM;
//		audioSource.Pause ();
//		this.AudioSource.Pause();
//		FieldBGM.Pause();
	}

	public void RestartBGM(){
		AudioSource AudioSourceComponent = GameObject.Find("FieldBGM").GetComponent<AudioSource>();

		// 再生
		AudioSourceComponent.Play();
	}


	public void CreateKey(){
		Debug.Log ("CreateKey します");
		if (GameObject.Find ("KeyPrefab(Clone)") == null) {
			GameObject key = (GameObject)Instantiate (KeyPrefab);	
		}
	}
		
	public void CreateTreasure(){
		if (GameObject.Find ("TreasurePrefab(Clone)") == null) {
			GameObject treasure = (GameObject)Instantiate (TreasurePrefab);
		}
	}

	public void CreateBoard(){
		//Debug.Log ("CreateBoard します");
//		if (GameObject.Find ("BoardPrefab(Clone)") == null) {
		//	GameObject board = (GameObject)Instantiate (BoardPrefab);	
//		}
		CheckBoardCount();
	}

	public void GetKey(){
		audioSource.PlayOneShot (getKeySE);
	}

	public void GetTreasure(){
		Debug.Log ("GetTreasure です");
//		FadeGoalSC.goFadeOut = true;
//		FadeGoalSC.goFadeIn = false;
		GoalM.GoalDirection();
//		audioSource.PlayOneShot (getTreasureSE);
		Debug.Log ("GetTreasure 終了です");
	}

	public void ArriveTreasure(){
		audioSource.PlayOneShot (ArriveTreasureSE);
	}

	public void DestroyBoardPart(){
		GameObject board = GameObject.Find("BoardPrefab(Clone)");
//		FadeBoSC.goFadeOut = true;
		CharaMoveMscript.RunningInfo = false;
		CharaMoveMscript.ArrivedNextPoint = true;

		var sequence = DOTween.Sequence();
		sequence.InsertCallback(1.5f, () =>(Destroy (board)));
		sequence.InsertCallback(0.6f, () =>(TimerSC.deactivateTimerText()));
	}

	public void CrashOtherPlayer_weak(){
		audioSource.PlayOneShot (CrashPlayerSE_small);
	}

	public void CrashOtherPlayer_strong(){
		audioSource.PlayOneShot (CrashPlayerSE_big);
	}

	public void getPositionInfo(){
		do {
			rndNum = Random.Range (1, 16);

			if (lastTimeNum != rndNum) {
				Debug.Log ("rndNum      :"+rndNum);
				Debug.Log ("lastTimeNum : " + lastTimeNum);

				switch (rndNum) {
				case 1:
					appearPosition = new Vector3 (-24, 0, 27);
					Debug.Log ("目指す場所はNORTH_L");
					break;

				case 2:
					appearPosition = new Vector3 (-3, 0, 27);
					Debug.Log ("目指す場所はNORTH_C");
					break;

				case 3:
					appearPosition = new Vector3 (21, 0, 27);
					Debug.Log ("目指す場所はNORTH_R");
					break;

				case 4:
					appearPosition = new Vector3 (-24, 0, 6);
					Debug.Log ("目指す場所はCENTER_L");
					break;

				case 5:
					appearPosition = new Vector3 (0, 0, 12);
					Debug.Log ("目指す場所はCENTER_C");
					break;

				case 6:
					appearPosition = new Vector3 (21, 0, 9);
					Debug.Log ("目指す場所はCENTER_R");
					break;

				case 7:
					appearPosition = new Vector3 (-24, 0, -24);
					Debug.Log ("目指す場所はSOUTH_L");
					break;

				case 8:
					appearPosition = new Vector3 (-6, 0, -9);
					Debug.Log ("目指す場所はSOUTH_C");
					break;

				case 9:
					appearPosition = new Vector3 (21, 0, -18);
					Debug.Log ("目指す場所はSOUTH_R");
					break;

				case 10:
					appearPosition = new Vector3 (ftPos.x-28.5f, ftPos.y+0, ftPos.z+19.5f);
					Debug.Log ("目指す場所はFountain_北西");
					break;

				case 11:
					appearPosition = new Vector3 (ftPos.x+28f, ftPos.y+0, ftPos.z+19.5f);
					Debug.Log ("目指す場所はFountain_北東");
					break;

				case 12:
					appearPosition = new Vector3 (ftPos.x-28.5f, ftPos.y+0, ftPos.z-19.5f);
					Debug.Log ("目指す場所はFountain_南西");
					break;

				case 13:
					appearPosition = new Vector3 (ftPos.x+28, ftPos.y+0, ftPos.z-7.5f);
					Debug.Log ("目指す場所はFountain_南東");
					break;

				case 14:
					appearPosition = new Vector3 (ftPos.x-11f, ftPos.y+0, ftPos.z+10.5f);
					Debug.Log ("目指す場所はFountain_中央西");
					break;

				case 15:
					appearPosition = new Vector3 (ftPos.x+10, ftPos.y+0, ftPos.z-10.5f);
					Debug.Log ("目指す場所はFountain_中央東");
					break;

				case 16:
					appearPosition = new Vector3 (ftPos.x+10, ftPos.y+0, ftPos.z-10.5f);
					Debug.Log ("目指す場所はFountain_中央東");
					break;
				}
			}
		} while(lastTimeNum == rndNum);
		lastTimeNum = rndNum;
		Debug.Log ("lastTimeNum が " + lastTimeNum +"に上書きされます。");
	}

	public void getBoardPositionInfo(){
		do {
			rndNum = Random.Range (7, 13);

			if (lastBoardNum != rndNum) {
				Debug.Log ("rndNum      :"+rndNum);
				Debug.Log ("lastBoardNum : " + lastBoardNum);

				switch (rndNum) {
				case 1:
					appearBoardPosition = new Vector3 (-18, 0, 21);
					Debug.Log ("ボードが左上に生成");
					break;

				case 2:
					appearBoardPosition = new Vector3 (18, 0, 24);
					Debug.Log ("ボードが右上に生成");
					break;

				case 3:
					appearBoardPosition = new Vector3 (-18, 0, 0);
					Debug.Log ("ボードが左中央に生成");
					break;

				case 4:
					appearBoardPosition = new Vector3 (18, 0, 0);
					Debug.Log ("ボードが右中央に生成");
					break;

				case 5:
					appearBoardPosition = new Vector3 (-18, 0, -18);
					Debug.Log ("ボードが左下に生成");
					break;

				case 6:
					appearBoardPosition = new Vector3 (15, 0, -18);
					Debug.Log ("ボードが右下に生成");
					break;

				case 7:
					appearBoardPosition = new Vector3 (ftPos.x-20f, ftPos.y+0, ftPos.z+19.5f);
					Debug.Log ("ボードがFountain_左上");
					break;

				case 8:
					appearBoardPosition = new Vector3 (ftPos.x+19f, ftPos.y+0, ftPos.z+20f);
					Debug.Log ("ボードがFountain_右上");
					break;

				case 9:
					appearBoardPosition = new Vector3 (ftPos.x-20f, ftPos.y+0, ftPos.z-19f);
					Debug.Log ("ボードがFountain_左下");
					break;

				case 10:
					appearBoardPosition = new Vector3 (ftPos.x+19f, ftPos.y+0, ftPos.z-19f);
					Debug.Log ("ボードがFountain_右下");
					break;

				case 11:
					appearBoardPosition = new Vector3 (ftPos.x-23f, ftPos.y+0, ftPos.z-1.0f);
					Debug.Log ("ボードがFountain_左中央");
					break;

				case 12:
					appearBoardPosition = new Vector3 (ftPos.x+22f, ftPos.y+0, ftPos.z+1.8f);
					Debug.Log ("ボードがFountain_右中央");
					break;

				case 13:
					appearBoardPosition = new Vector3 (ftPos.x+22f, ftPos.y+0, ftPos.z+1.8f);
					Debug.Log ("ボードがFountain_右中央");
					break;
				}
			}
		} while(lastBoardNum == rndNum);
		lastBoardNum = rndNum;
		Debug.Log ("lastBoardNum が " + lastBoardNum +"に上書きされます。");
	}


	//Boardタグが付いたオブジェクトを数える
	public void CheckBoardCount(){
		tagBoards = GameObject.FindGameObjectsWithTag("Board");
		Debug.Log(tagBoards.Length); //tagObjects.Lengthはオブジェクトの数
		//Destroy(tagBoards);

		for (int i = 0; i < 2; i++) {
			GameObject BoardP = GameObject.Find ("BoardPrefab(Clone)");
			if (BoardP != null) {
				Destroy (BoardP);
				Debug.Log ("Board はすべて消します");
			}
		}

//		for (int i = 0; i < 2; i++) {
			if (tagBoards.Length < 2) {
				Debug.Log ("タグがついたオブジェクトは2個以下です。不足分を生成します");
				Debug.Log ("CreateBoard します");
				GameObject board = (GameObject)Instantiate (BoardPrefab);	
				GameObject board2 = (GameObject)Instantiate (BoardPrefab);	
			}
//		}
	}

//	public void DestroyB(){
//	var clones = GameObject.FindGameObjectsWithTag ("Board");
//	for (var clone in clones){
//		Destroy(clone);
//	}
//	}

	//#################################################################################

}
// End