using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChecker_Fountain : MonoBehaviour {

	GameObject unitychan;
	UnityChanController Uscript; 
	GameObject pchan; 
	PchanController Pscript; 
	GameObject key;
	KeyController keySC;
	GameObject Treasure;
	TreasureController TreasureSC;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		Debug.Log ("AreaChecker_Fountain 出席確認 ");
		unitychan = GameObject.Find ("unitychan");
		Uscript = unitychan.GetComponent<UnityChanController>();
		pchan = GameObject.Find ("pchan"); 
		Pscript = pchan.GetComponent<PchanController>(); 

	}


	//####################################  Update  ###################################

	void Update () {

	}

	//####################################  other  ####################################
	public void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("噴水に居ます ");
			if (other.gameObject == unitychan) {
				Uscript.CurrentArea = 1;
			}
			if (other.gameObject == pchan) {
				Pscript.CurrentArea = 1;
			}
		}

		if (other.gameObject.tag == "Key") {
				key = GameObject.Find("KeyPrefab(Clone)");
				keySC = key.GetComponent<KeyController>();
				Debug.Log ("カギは噴水にあります ");
				keySC.CurrentArea = 1;
		}

//		if (other.gameObject.tag == "Treasure") {
//			Treasure = GameObject.Find ("TreasurePrefab(Clone)");
//			TreasureSC = Treasure.GetComponent<TreasureController>(); 
//			Debug.Log ("宝箱は噴水にあります ");
//			TreasureSC.CurrentArea = 1;
//		}
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Treasure") {
			Treasure = GameObject.Find ("TreasurePrefab(Clone)");
			if (Treasure != null) {
				TreasureSC = Treasure.GetComponent<TreasureController> (); 
				Debug.Log ("宝箱は噴水にあります ");
				TreasureSC.CurrentArea = 1;
			}
		}
	}

	//#################################################################################

}
// End