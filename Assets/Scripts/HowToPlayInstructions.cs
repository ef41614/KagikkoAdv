using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class HowToPlayInstructions : MonoBehaviour {

	int pageNum = 1;
	int MaxPageNum = 7;
	public GameObject SetumeiPanel;
	public GameObject page1;
	public GameObject page2;
	public GameObject page3;
	public GameObject page4;
	public GameObject page5;
	public GameObject page6;
	public GameObject page7;
	GameObject pageX;

	//☆################☆################  Start  ################☆################☆
	void Start () {
		Debug.Log ("HowToPlayスクリプト出席確認");
		ResetPositon ();
		pageNum = 1;
		HidePages();
		CurrentPageOpen(); 
	}

	//####################################  Update  ###################################

	void Update () {

		if(pageNum == 1){

		}

	}

	//####################################  other  ####################################

	public void ResetPositon () {
		pageNum = 1;
		HidePages();
		CurrentPageOpen(); 
	}

	public void ToNextPage(){
		if(pageNum < MaxPageNum){
			HidePages();
			pageNum += 1;
			CurrentPageOpen();
		}
	}


	public void ToBackPage(){
		if(pageNum > 1){
			HidePages();
			pageNum -= 1;
			CurrentPageOpen();
		}
	}


	public void CurrentPageOpen(){
		int i = pageNum;
		// 数字をテキストにする
		string s = i.ToString();
//		string pg = "page" + s;
//		pg.SetActive (true);

		// parentはTargetの親のGameObject
//		GameObject g = parent.transform.Find("Target").gameObject;
		pageX = SetumeiPanel.transform.Find("page" + s).gameObject;
//		pageX = GameObject.Find ("page" + s);
//		pageX = ("page" + s).gameObject;
//		pageX.SetActive (true);
		pageX.SetActive (true);
	}


	public void HidePages(){
		if (page1 != null) {
			page1.SetActive (false);
		}
		if (page2 != null) {
			page2.SetActive (false);
		}
		if (page3 != null) {
			page3.SetActive (false);
		}
		if (page4 != null) {
			page4.SetActive (false);
		}
		if (page5 != null) {
			page5.SetActive (false);
		}
		if (page6 != null) {
			page6.SetActive (false);
		}
		if (page7 != null) {
			page7.SetActive (false);
		}
	}

	//#################################################################################

}
// End