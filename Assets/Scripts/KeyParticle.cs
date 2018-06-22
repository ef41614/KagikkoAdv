using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyParticle : MonoBehaviour {

	//☆################☆################  Start  ################☆################☆

	void Start () {


	}


	//####################################  Update  ###################################

	void Update () {


	}

	//####################################  other  ####################################

	public void GetKeyParticle(){
		GetComponent<ParticleSystem> ().Play ();
	}

	//#################################################################################

}
// End
