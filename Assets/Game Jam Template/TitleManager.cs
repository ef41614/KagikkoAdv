using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour {
//	public static int GameMode  = 0; // 0:Normal、 1:Rovky
//	public static int AudioPlay = 0; // 0:off、 1:on

	public GameObject loading;
	public GameObject titleLogo;
	public GameObject Buttons;
	public GameObject image1black;

	[SerializeField]
	RectTransform rectTran;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

	//☆################☆################  Start  ################☆################☆
	void Start () {
		DontDestroyOnLoad(this);
	}

	//####################################  Update  ###################################
	void Update () {
//		image1black.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime, Space.World);
	}

	//####################################  other  ####################################
	//#################################################################################

	//スタートボタンを押した
	public void PushStartButton () {
		loading.SetActive(true);
		titleLogo.SetActive(false);
		Buttons.SetActive(false);

		var sequence = DOTween.Sequence();
		sequence.InsertCallback(0.5f, () =>(SceneManager.LoadScene ("GameScene")));
//		SceneManager.LoadScene ("GameScene");	//ゲーム開始
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





}
// End