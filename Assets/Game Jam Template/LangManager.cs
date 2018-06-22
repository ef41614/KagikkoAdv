using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LangManager : MonoBehaviour {

	public int LangMode = 2;

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
		
	}

	//####################################  other  ####################################

	public void inEnglish(){
		LangMode = 1;
	}

	public void inJapanese(){
		LangMode = 2;
	}

	//#################################################################################
}
// End