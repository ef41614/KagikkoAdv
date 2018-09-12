﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class guideController : MonoBehaviour {

	private GameObject unitychan;
	private UnityChanController Uscript;
	GameObject pchan; 
	PchanController Pscript; 
	GameObject turnmanager;
	TurnManager TurnMscript;
	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
	public Vector3 NextGuidePos;
	[SerializeField]
	RectTransform rectTran;
	Vector3 NGP;
	public GameObject P1;
	public GameObject P2;
	public GameObject P3;
	public GameObject P4;
	public GameObject Key;
	public GameObject Peke;
	public Vector3 IconPos;
	public Vector3 IconPos2;
	public GameObject WMap;
	WMapController WMapC;
	public GameObject BirdB;
	public GameObject FountainB;

	public GameObject FountainStage;

	//☆################☆################  Start  ################☆################☆
	void Start () {
		this.unitychan = GameObject.Find ("unitychan");
		Uscript = unitychan.GetComponent<UnityChanController>();
		pchan = GameObject.Find ("pchan"); 
		Pscript = pchan.GetComponent<PchanController>(); 
		turnmanager = GameObject.Find ("turnmanager");
		TurnMscript = turnmanager.GetComponent<TurnManager>(); 
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		WMapC = WMap.GetComponent<WMapController>(); 
	}
		
	//####################################  Update  ###################################
	void Update () {

	}

	//####################################  other  ####################################

	public void ToUnderGround(){
		Vector3 underGround = new Vector3 (this.transform.position.x, this.transform.position.y - 50, this.transform.position.z);
		transform.DOLocalMove (underGround, 0.1f);
		Debug.Log("地面の下に行ったよ");
	}

	public void adjustNextGuidePos(){
		Debug.Log("adjustスクリプト出席確認");
//		if (TurnMscript.canMove1P == true) {
//			NGP = Uscript.NextPos;
//		} else if (TurnMscript.canMove2P == true) {
//			NGP = Pscript.NextPos;
//		}
		NGP = CharaMoveMscript.NextPos;
//		Debug.Log("NGP上:"+NGP);
		NGP.x = Mathf.RoundToInt ( ((NGP.x)/3)*3);
		NGP.z = Mathf.RoundToInt ( ((NGP.z)/3)*3);
//		Debug.Log("NGP下:"+NGP);
		NextGuidePos = NGP;
//		transform.position = NGP;
		transform.DOLocalMove (NextGuidePos, 0.2f);
//		transform.position = NextGuidePos;
//		transform.Translate (NextGuidePos);
	}

	public void initializePosition(){
		Vector3 CharaPos;
		if (TurnMscript.canMove1P == true) {
			unitychan = GameObject.Find ("unitychan");
			Uscript = unitychan.GetComponent<UnityChanController>();
			CharaPos = Uscript.Player_pos;
			Debug.Log("見つけろ！unitychan （initializePosition）");
//			Debug.Log("Uscript.Player_pos :"+Uscript.Player_pos);
//			CharaPos = GameObject.Find ("unitychan").transform;
//			CharaPos = unitychan.GetComponent<Transform>();
//			CharaPos = new Vector3 (GameObject.Find ("unitychan").transform);
//			CharaPos = new Vector3( unitychan.GetComponent<Transform>());
			transform.DOLocalMove (CharaPos, 0.1f);
		}
		if (TurnMscript.canMove2P == true) {
			pchan = GameObject.Find ("pchan"); 
			Pscript = pchan.GetComponent<PchanController>(); 
			CharaPos = Pscript.Player_pos;
//			CharaPos = new Vector3( GameObject.Find ("pchan").transform);
			Debug.Log("見つけろ！ｐchan （initializePosition）");
			transform.DOLocalMove (CharaPos, 0.1f);
		}
	}


	//	public void OnCollisionEnter(Collision other){
	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("プレーヤーの誰かが guideMに接触：");
			if (other.gameObject == CharaMoveMscript.activeChara) {
				Debug.Log (CharaMoveMscript.activeChara.name+" guideMに接触：");
				CharaMoveMscript.ArrivedNextPoint = true;
			}
		}
	}


	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("プレーヤーの誰かが guideMから離脱：");
			if (other.gameObject == CharaMoveMscript.activeChara) {
				Debug.Log (CharaMoveMscript.activeChara.name+" guideMから離脱：");
				CharaMoveMscript.ArrivedNextPoint = false;
			}
		}
	}


	public void ShowIconPos_InWMap(){
		Debug.Log ("WMapにプレーヤー位置を反映させます");
		ShowPlayer1_InWMap ();
		ShowPlayer2_InWMap ();
	}

	public void ShowPlayer1_InWMap(){
		this.unitychan = GameObject.Find ("unitychan");
//		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, IconPos.target.position);
		//IconPos = Uscript.Player_pos;
//		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, IconPos);
//		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, target.position);

		//WMapC.IconPos = IconPos;
		//WMapC.ShowIconPos_InWMap ();

		Debug.Log ("プレーヤーIconPos："+IconPos);
		Debug.Log ("プレーヤーIconPos.x："+IconPos.x);
		Debug.Log ("プレーヤーIconPos.y："+IconPos.y);
		Debug.Log ("プレーヤーIconPos.z："+IconPos.z);

		if (Uscript.CurrentArea == 0) {
			Debug.Log ("プレーヤー１：いまバード");
			IconPos = BirdB.transform.position;
			IconPos.x = IconPos.x + Uscript.Player_pos.x/2.5f;
			IconPos.y = IconPos.y + Uscript.Player_pos.z/2.5f + 7;
		} else if (Uscript.CurrentArea == 1) {
			Debug.Log ("プレーヤー1：いま噴水");
			IconPos = FountainB.transform.position;
			IconPos.x = IconPos.x + (Uscript.Player_pos.x - FountainStage.transform.position.x)/2.5f;
			IconPos.y = IconPos.y + (Uscript.Player_pos.z - FountainStage.transform.position.z)/2.5f + 7;
		}

		P1.transform.position = IconPos;
		Debug.Log ("プレーヤーIconPos："+IconPos);
		Debug.Log ("プレーヤーIconPos.x："+IconPos.x);
		Debug.Log ("プレーヤーIconPos.y："+IconPos.y);
		Debug.Log ("プレーヤーIconPos.z："+IconPos.z);
	}


	public void ShowPlayer2_InWMap(){
		pchan = GameObject.Find ("pchan"); 
		Debug.Log ("プレーヤー2IconPos："+IconPos2);
		if (Pscript.CurrentArea == 0) {
			Debug.Log ("プレーヤー2：いまバード");
			IconPos2 = BirdB.transform.position;
			IconPos2.x = IconPos2.x + Pscript.Player_pos.x/2.5f;
			IconPos2.y = IconPos2.y + Pscript.Player_pos.z/2.5f + 7;
		} else if (Pscript.CurrentArea == 1) {
			Debug.Log ("プレーヤー2：いま噴水");
			IconPos2 = FountainB.transform.position;
			IconPos2.x = IconPos2.x + (Pscript.Player_pos.x - FountainStage.transform.position.x)/2.5f;
			IconPos2.y = IconPos2.y + (Pscript.Player_pos.z - FountainStage.transform.position.z)/2.5f + 7;
		}
		Debug.Log ("プレーヤー2IconPos2："+IconPos2);
		P2.transform.position = IconPos2;
	}

	//#################################################################################

}
// End