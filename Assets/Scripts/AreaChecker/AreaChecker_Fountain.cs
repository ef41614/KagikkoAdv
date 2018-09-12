using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChecker_Fountain : MonoBehaviour {

	GameObject unitychan;
	UnityChanController Uscript; 
	GameObject pchan; 
	PchanController Pscript; 

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
	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("噴水に居ます ");
			if (other.gameObject == unitychan) {
				Uscript.CurrentArea =1;
			}
			if (other.gameObject == pchan) {
				Pscript.CurrentArea =1;
			}
		}
	}

	//#################################################################################

}
// End