using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMoving : MonoBehaviour {

	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
	int startPa = 0;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		startPa = 0;
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

	}


	//####################################  Update  ###################################

	void Update () {
		if (CharaMoveMscript.OnBoard) {
			if (startPa == 0) {
				GetComponent<ParticleSystem> ().Play ();
				startPa += 1;
			}
		}
		if (CharaMoveMscript.OnBoard==false) {
			GetComponent<ParticleSystem> ().Stop ();
		}
	}

	//####################################  other  ####################################
	//#################################################################################

}
// End