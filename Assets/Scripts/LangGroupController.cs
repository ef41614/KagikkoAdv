using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LangGroupController : MonoBehaviour {

	public GameObject LangManager;
	LangManager LangMScript;
	int selectedLangMode = 2;
	GameObject JPNSentence;
	GameObject ENGSentence;

	void Awake(){
		LangManager = GameObject.Find ("LangManager");
		LangMScript = LangManager.GetComponent<LangManager> ();
	}

	//☆################☆################  Start  ################☆################☆

	void Start () {
		JPNSentence = transform.FindChild("JPN_Text").gameObject;
		ENGSentence = transform.FindChild("ENG_Text").gameObject;
	}


	//####################################  Update  ###################################

	void Update () {
		selectedLangMode = LangMScript.LangMode;

		if (selectedLangMode == 1) {
			JPNSentence.SetActive (false);
			ENGSentence.SetActive (true);
		}
		if (selectedLangMode == 2) {
			JPNSentence.SetActive (true);
			ENGSentence.SetActive (false);
		}
	}

	//####################################  other  ####################################
	//#################################################################################

}
// End