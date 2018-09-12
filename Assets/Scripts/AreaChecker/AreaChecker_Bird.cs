using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChecker_Bird : MonoBehaviour {

	GameObject unitychan;
	UnityChanController Uscript; 
	GameObject pchan; 
	PchanController Pscript; 

	//☆################☆################  Start  ################☆################☆

	void Start () {
		Debug.Log ("AreaChecker_Bird 出席確認 ");
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
			Debug.Log ("バードタウンに居ます ");

			if (other.gameObject == unitychan) {
				Uscript.CurrentArea =0;
			}
			if (other.gameObject == pchan) {
				Pscript.CurrentArea =0;
			}

		}
	}

	//#################################################################################

}
// End