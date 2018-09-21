using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class guideController : MonoBehaviour {

	private GameObject unitychan;
	private UnityChanController Uscript;
	GameObject pchan; 
	PchanController Pscript; 
	GameObject key;
	KeyController keySC;
	GameObject Treasure;
	TreasureController TreasureSC;
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
	public GameObject KeyIcon;
	public GameObject Peke;
	public Vector3 IconPos;
//	public Vector3 IconPos;
	public GameObject WMap;
	WMapController WMapC;
	public GameObject BirdB;
	public GameObject FountainB;

	public GameObject FountainStage;
	public bool chestExist = false;
	public bool KeyIsFree = true;

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
//		WMap.SetActive (false);

		var sequence = DOTween.Sequence();
		sequence.InsertCallback(0.1f, () =>(ShowIconPos_InWMap ()));
//		ShowIconPos_InWMap ();
	}
		
	//####################################  Update  ###################################
	void Update () {

	}

	//####################################  other  ####################################

	public void ToUnderGround(){
		Vector3 underGround = new Vector3 (this.transform.position.x, this.transform.position.y - 50, this.transform.position.z);
		transform.DOLocalMove (underGround, 0.1f);
//		Debug.Log("地面の下に行ったよ");
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
//			Debug.Log("見つけろ！unitychan （initializePosition）");
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
//			Debug.Log("見つけろ！ｐchan （initializePosition）");
			transform.DOLocalMove (CharaPos, 0.1f);
		}
	}


	//	public void OnCollisionEnter(Collision other){
	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
//			Debug.Log ("プレーヤーの誰かが guideMに接触：");
			if (other.gameObject == CharaMoveMscript.activeChara) {
//				Debug.Log (CharaMoveMscript.activeChara.name+" guideMに接触：");
				CharaMoveMscript.ArrivedNextPoint = true;
			}
		}
	}


	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
//			Debug.Log ("プレーヤーの誰かが guideMから離脱：");
			if (other.gameObject == CharaMoveMscript.activeChara) {
//				Debug.Log (CharaMoveMscript.activeChara.name+" guideMから離脱：");
				CharaMoveMscript.ArrivedNextPoint = false;
			}
		}
	}


	public void ShowIconPos_InWMap(){
//		Debug.Log ("WMapにプレーヤー位置を反映させます");
		ShowPlayer1_InWMap ();
		ShowPlayer2_InWMap ();

		if (KeyIsFree) {
			if (KeyIcon.activeSelf == false) {
				KeyIcon.SetActive (true);
			}
			ShowKeyIcon_InWMap ();
		} else {
			if (KeyIcon.activeSelf) {
				KeyIcon.SetActive (false);
			}
		}

		if (chestExist) {
			if (Peke.activeSelf == false) {
				Peke.SetActive (true);
			}
			ShowTreasureIcon_InWMap ();
		} else {
			if (Peke.activeSelf) {
				Peke.SetActive (false);
			}
		}
	}

	public void ShowPlayer1_InWMap(){
		this.unitychan = GameObject.Find ("unitychan");
//		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, IconPos.target.position);
		//IconPos = Uscript.Player_pos;
//		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, IconPos);
//		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, target.position);

		//WMapC.IconPos = IconPos;
		//WMapC.ShowIconPos_InWMap ();



		if (Uscript.CurrentArea == 0) {
//			Debug.Log ("プレーヤー１：いまバード");
			IconPos = BirdB.transform.position;
			IconPos.x = IconPos.x + Uscript.Player_pos.x/2.5f;
			IconPos.y = IconPos.y + Uscript.Player_pos.z/2.5f + 7;
		} else if (Uscript.CurrentArea == 1) {
//			Debug.Log ("プレーヤー1：いま噴水");
			IconPos = FountainB.transform.position;
			IconPos.x = IconPos.x + (Uscript.Player_pos.x - FountainStage.transform.position.x)/2.5f;
			IconPos.y = IconPos.y + (Uscript.Player_pos.z - FountainStage.transform.position.z)/2.5f + 7;
		}

		P1.transform.position = IconPos;
	}


	public void ShowPlayer2_InWMap(){
		pchan = GameObject.Find ("pchan"); 
//		Debug.Log ("プレーヤー2IconPos："+IconPos);
		if (Pscript.CurrentArea == 0) {
//			Debug.Log ("プレーヤー2：いまバード");
			IconPos = BirdB.transform.position;
			IconPos.x = IconPos.x + Pscript.Player_pos.x/2.5f;
			IconPos.y = IconPos.y + Pscript.Player_pos.z/2.5f + 7;
		} else if (Pscript.CurrentArea == 1) {
//			Debug.Log ("プレーヤー2：いま噴水");
			IconPos = FountainB.transform.position;
			IconPos.x = IconPos.x + (Pscript.Player_pos.x - FountainStage.transform.position.x)/2.5f;
			IconPos.y = IconPos.y + (Pscript.Player_pos.z - FountainStage.transform.position.z)/2.5f + 7;
		}
//		Debug.Log ("プレーヤー2IconPos："+IconPos);
		P2.transform.position = IconPos;
	}


	public void ShowKeyIcon_InWMap(){
		key = GameObject.Find("KeyPrefab(Clone)");
		keySC = key.GetComponent<KeyController> ();
//		Debug.Log ("カギIconPos："+IconPos);
//		Debug.Log ("カギIconPos.x："+IconPos.x);
//		Debug.Log ("カギIconPos.y："+IconPos.y);
//		Debug.Log ("カギIconPos.z："+IconPos.z);
		if (keySC.CurrentArea == 0) {
			Debug.Log ("カギ：いまバード");
			IconPos = BirdB.transform.position;
//			IconPos.x = IconPos.x + (keySC.key_pos.x - BirdB.transform.position.x) /2.5f;
            IconPos.x = IconPos.x + keySC.key_pos.x / 2.5f+2;
//            IconPos.y = IconPos.y + (keySC.key_pos.z - BirdB.transform.position.z) / 2.5f + 7;
            IconPos.y = IconPos.y + keySC.key_pos.z / 2.5f + 4;
        } else if (keySC.CurrentArea == 1) {
			Debug.Log ("カギ：いま噴水");
			IconPos = FountainB.transform.position;
			IconPos.x = IconPos.x + (keySC.key_pos.x - FountainStage.transform.position.x)/2.5f+2;
			IconPos.y = IconPos.y + (keySC.key_pos.z - FountainStage.transform.position.z)/2.5f + 4;
		}
		KeyIcon.transform.position = IconPos;
//        Debug.Log("カギkeySC.key_pos.x：" + keySC.key_pos.x);
//        Debug.Log("カギkeySC.key_pos.z：" + keySC.key_pos.z);

//        Debug.Log ("カギIconPos："+IconPos);
//		Debug.Log ("カギIconPos.x："+IconPos.x);
//		Debug.Log ("カギIconPos.y："+IconPos.y);
//		Debug.Log ("カギIconPos.z："+IconPos.z);
	}


	public void ShowTreasureIcon_InWMap(){
		Treasure = GameObject.Find ("TreasurePrefab(Clone)");
		TreasureSC = Treasure.GetComponent<TreasureController>(); 
		if (TreasureSC.CurrentArea == 0) {
//			Debug.Log ("宝箱：いまバード");
			IconPos = BirdB.transform.position;
			IconPos.x = IconPos.x + TreasureSC.Treasure_pos.x/2.5f + 4;
			IconPos.y = IconPos.y + TreasureSC.Treasure_pos.z/2.5f + 2;
		} else if (TreasureSC.CurrentArea == 1) {
//			Debug.Log ("宝箱：いま噴水");
			IconPos = FountainB.transform.position;
			IconPos.x = IconPos.x + (TreasureSC.Treasure_pos.x - FountainStage.transform.position.x)/2.5f + 4;
			IconPos.y = IconPos.y + (TreasureSC.Treasure_pos.z - FountainStage.transform.position.z)/2.5f + 2;
		}
		Peke.transform.position = IconPos;
	}
		
	//#################################################################################

}
// End