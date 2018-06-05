using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour {
//	public static int GameMode  = 0; // 0:Normal、 1:Rovky
//	public static int AudioPlay = 0; // 0:off、 1:on

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

	public AudioClip pushDecisionSE;
	public AudioClip pushCancelButtonSE;
	AudioSource audioSource;

	[SerializeField]
	RectTransform rectTran;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

	//☆################☆################  Start  ################☆################☆
	void Start () {
		DontDestroyOnLoad(this);
		loading.SetActive(false);
		audioSource = this.gameObject.GetComponent<AudioSource> ();
	}

	//####################################  Update  ###################################
	void Update () {
//		image1black.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime, Space.World);
	}

	//####################################  other  ####################################

	//スタートボタンを押した
	public void PushStartButton () {
		loading.SetActive(true);
		titleLogo.SetActive(false);
		Buttons.SetActive(false);
//		startButton.SetActive(false);
//		quit.SetActive (false);

		var sequence = DOTween.Sequence();
		sequence.InsertCallback(0.5f, () =>(SceneManager.LoadScene ("GameScene")));
		sequence.InsertCallback(1.5f, () =>(StartMainScene()));
//		sequence.InsertCallback(0.4f, () =>(optionsButton.SetActive(true)));
//		SceneManager.LoadScene ("GameScene");	//ゲーム開始
	}

	public void PushDecisionSE(){
		audioSource.PlayOneShot (pushDecisionSE);
	}

	public void PushCancelButtonSE(){
		audioSource.PlayOneShot (pushCancelButtonSE);
	}

	public void StartMainScene(){
		menuPanel.SetActive (true);
		loading.SetActive (false);
		titleLogo.SetActive (false);
		menuButtons.SetActive (true);
		startButton.SetActive(false);
		quit.SetActive (false);
		optionsButton.SetActive (true);
	}

	public void PushNormalButton () {
//		GameMode = 0;
//		AudioPlay = 0;
		SceneManager.LoadScene ("GameScene");	//ゲーム開始

	}

	public void PushRockyButton () {
//		GameMode = 1;
//		AudioPlay = 1;
//★		SceneManager.LoadScene ("GameScene");	//ゲーム開始

	}

//	public static int getSelectMode(){
//		return GameMode;
//	}




	//#################################################################################
}
// End