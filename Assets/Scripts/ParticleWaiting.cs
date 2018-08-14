using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWaiting : MonoBehaviour {

	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

	}


	//####################################  Update  ###################################

	void Update () {
		if (CharaMoveMscript.OnBoard) {
			GetComponent<ParticleSystem> ().Stop ();
		}

	}

	//####################################  other  ####################################
	//#################################################################################

}
// End