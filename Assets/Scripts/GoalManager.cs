using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class GoalManager : MonoBehaviour {
	public Camera GoalCamera;
	public AudioClip getTreasureSE;
	public AudioClip KachaSE;
	public AudioClip gacha_gachaSE;
	private AudioSource audioSource;

	[SerializeField]
	RectTransform rectTran;

	GameObject graypanel;
	FadeGoalScript FadeGoalSC;
	public GameObject GoalTreasure;
	GameObject ConfettiParticleSystem;
	GameObject GoUpLight;
	GameObject GoUpLight2;
	GameObject GoUpLightSmall;
	GameObject GoAroundLight;
	GameObject GoalTreatureOpen;

	public GameObject GoalUchan;
	public GameObject Goalpchan;
//	public GameObject graypanel;
	public GameObject CanvasGoalButton;
	public GameObject CanvasGoalMessage;
	GameObject GoTitleButton;
	public KeyController keySC;
	public GameObject KeyPrefab;
	public string HoldingKeyPlayer = null;
	GameObject Canvas;

	GameManager GMScript;
	GameObject GameMgr;


	//☆################☆################  Start  ################☆################☆

	void Start () {
		audioSource = this.gameObject.GetComponent<AudioSource> ();

		GoalSetOff ();

		Canvas = GameObject.Find ("Canvas");

		GameMgr = GameObject.Find ("GameManager");
		GMScript = GameMgr.GetComponent<GameManager> ();

	}


	//####################################  Update  ###################################

	void Update () {


	}

	//####################################  other  ####################################

	public void GoalSetOff(){
		GoalCamera.enabled = false;
		graypanel = GameObject.Find ("graypanel");
		FadeGoalSC = graypanel.GetComponent<FadeGoalScript> ();
		FadeGoalSC.goFadeOut = false;
		FadeGoalSC.goFadeIn = true;
//		graypanel.SetActive (false);
//★		GoalTreasure = GameObject.Find ("GoalTreasure");
		if (GoalTreasure != null) {
			GoalTreasure.SetActive (false);
		}
		ConfettiParticleSystem = GameObject.Find ("ConfettiParticleSystem");
		ConfettiParticleSystem.SetActive (false);
		GoUpLight = GameObject.Find ("GoUpLight");
		GoUpLight.SetActive (false);
		GoUpLight2 = GameObject.Find ("GoUpLight2");
		GoUpLight2.SetActive (false);
		GoUpLightSmall = GameObject.Find ("GoUpLightSmall");
		GoUpLightSmall.SetActive (false);
		GoAroundLight = GameObject.Find ("GoAroundLight");
		GoAroundLight.SetActive (false);
		GoalTreatureOpen = GameObject.Find ("GoalTreatureOpen");
		GoalTreatureOpen.SetActive (false);

//		GoalUchan = GameObject.Find ("GoalUchan");
		if (GoalUchan != null) {
			GoalUchan.SetActive (false);
		}
//		Goalpchan = GameObject.Find ("Goalpchan");
		if (Goalpchan != null) {
			Goalpchan.SetActive (false);
		}
//		CanvasGoalButton = GameObject.Find ("CanvasGoalButton");
		CanvasGoalButton.SetActive (false);
		CanvasGoalMessage.SetActive (false);
	}


	public void GoalDirection(){
		GMScript.HaltBGM ();

		GameObject key = GameObject.Find("KeyPrefab(Clone)");
		Destroy (key);
		FadeGoalSC.goFadeOut = true;
		FadeGoalSC.goFadeIn = false;
		GoalTreasure.SetActive (true);
		GoalCamera.enabled = true;
		Canvas.SetActive (false);

		// パンチング
		var sequence = DOTween.Sequence();
		sequence.Append(GoalTreasure.transform.DOPunchPosition (new Vector3 (15f, 0f), 2f, 10, 5f));

		sequence.Join(GoalTreasure.transform.DOPunchRotation (new Vector3 (15f, 0f), 2f, 10, 5f));

//		sequence.Append(GoalTreasure.transform.DOScale (new Vector3 (3f, 4f, 5f), 14f));
	
		sequence.InsertCallback(2f, () =>(ConfettiParticleSystem.SetActive (true)));
		sequence.InsertCallback(1f, () =>(GoUpLight.SetActive (true)));
		sequence.InsertCallback(1.5f, () =>(GoUpLight2.SetActive (true)));
		sequence.InsertCallback(1.5f, () =>(GoUpLightSmall.SetActive (true)));
		sequence.InsertCallback(2f, () =>(GoAroundLight.SetActive (true)));
		sequence.InsertCallback(2.95f, () =>(GoalTreasure.SetActive (false)));
		sequence.InsertCallback(3f, () =>(GoalTreatureOpen.SetActive (true)));

		sequence.InsertCallback(0.1f, () =>(audioSource.PlayOneShot (gacha_gachaSE)));
		sequence.InsertCallback(0.6f, () =>(audioSource.PlayOneShot (gacha_gachaSE)));
		sequence.InsertCallback(1.4f, () =>(audioSource.PlayOneShot (gacha_gachaSE)));
		sequence.InsertCallback(2.6f, () =>(audioSource.PlayOneShot (KachaSE)));
		sequence.InsertCallback(3f, () =>(audioSource.PlayOneShot (getTreasureSE)));

//		GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");

//		GameObject key = GameObject.Find("KeyPrefab*");
//		keySC = KeyPrefab.GetComponent<KeyController> ();
//		keySC = key.GetComponent<KeyController> ();
		Debug.Log ("HoldingKeyPlayer:" + HoldingKeyPlayer);

		if(HoldingKeyPlayer == "unitychan"){
			sequence.InsertCallback(1f, () =>(GoalUchan.SetActive (true)));
		}
		if (HoldingKeyPlayer == "pchan") {
			sequence.InsertCallback(1f, () =>(Goalpchan.SetActive (true)));
		}
		sequence.InsertCallback(7f, () =>(CanvasGoalMessage.SetActive (true)));
		sequence.InsertCallback(9f, () =>(CanvasGoalButton.SetActive (true)));
//		sequence.InsertCallback(5f, () =>(GoTitleButton.SetActive (true)));
	}

	public void RestartGame(){
		GoalSetOff ();
		CanvasGoalButton.SetActive (false);
		CanvasGoalMessage.SetActive (false);
		Canvas.SetActive (true);
		GMScript.CreateKey ();
		GMScript.RestartBGM ();
		graypanel = GameObject.Find ("graypanel");
//		graypanel.SetActive (false);
	}

	public void GoBackTitle(){
		Debug.Log ("TitleScene に戻ります");
		SceneManager.LoadScene ("TitleScene");
	}

	//#################################################################################

}
// End