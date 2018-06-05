using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {

	public GameObject optionsButton;
	public GameObject PausePanel;
	public GameObject MainUI;
	public GameObject OptionsPanel;
	GameObject parent;

	public GameObject menu_UI;
	public GameObject menuPanel;
	public GameObject menuButtons;
	public GameObject loading;
	public GameObject titleLogo;
	public GameObject Buttons;
	public GameObject image1black;
	public GameObject startButton;
	public GameObject quit;


	void Awake(){
//		parent = GameObject.Find ("Main UI");
	}
	//☆################☆################  Start  ################☆################☆

	void Start () {
//		optionsButton = parent.transform.Find("OptionsButton").gameObject;
//		OptionsPanel = parent.transform.Find("OptionsPanel").gameObject;

//		optionsButton.SetActive (true);
//		StartMainScene();

	}


	//####################################  Update  ###################################

	void Update () {


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
	}

	public void PushOptionsButton(){
		OptionsPanel.SetActive (true);
	}

	//#################################################################################

}
// End