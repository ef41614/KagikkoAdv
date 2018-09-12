using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainParticleSC : MonoBehaviour {

	public bool CharaIsHere = false;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		
	}

	//####################################  Update  ###################################

	void Update () {
		if (CharaIsHere) {
			GetComponent<ParticleSystem> ().Play ();
		} else if (CharaIsHere == false) {
			GetComponent<ParticleSystem> ().Stop ();
		}
	}

	//####################################  other  ####################################

	public void GetFountainParticle(){
		GetComponent<ParticleSystem> ().Play ();
	}

	//#################################################################################

}
// End
