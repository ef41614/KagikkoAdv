using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {

	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
//	public bool CharaIsHere = false;
	public GameObject hunsuiPa;
	public FountainParticleSC FountainPaSC;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		FountainPaSC = hunsuiPa.GetComponent<FountainParticleSC> ();
	}


	//####################################  Update  ###################################

	void Update () {

	}

	//####################################  other  ####################################
	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("噴水の近くにキャラがいます: ");
			charamovemanager = GameObject.Find ("charamovemanager");
			CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

			if (other.gameObject == CharaMoveMscript.activeChara) {
				Debug.Log ("アクティブなキャラなので、噴水ONにします ");
				FountainPaSC.CharaIsHere = true;
			}
		}
	}

	public void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("噴水の近くからキャラが去りました: ");
			charamovemanager = GameObject.Find ("charamovemanager");
			CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

			if (other.gameObject == CharaMoveMscript.activeChara) {
				Debug.Log ("アクティブなキャラは居ないので、噴水OFFにします ");
				FountainPaSC.CharaIsHere = false;
			}
		}
	}
	//#################################################################################

}
// End