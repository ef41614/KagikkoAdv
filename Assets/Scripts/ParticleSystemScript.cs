using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {

	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
//	public bool CharaIsHere = false;
	public GameObject hunsuiPa;
	public FountainParticleSC FountainPaSC;
	public GameObject HunsuiBody;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		FountainPaSC = hunsuiPa.GetComponent<FountainParticleSC> ();
//		if (HunsuiBody.activeSelf) {
//			HunsuiBody.SetActive (false);
//		}
	}


	//####################################  Update  ###################################

	void Update () {

	}

	//####################################  other  ####################################
	public void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
//			Debug.Log ("噴水の近くにキャラがいます: ");
			charamovemanager = GameObject.Find ("charamovemanager");
			CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

			if (other.gameObject == CharaMoveMscript.activeChara) {
//				Debug.Log ("アクティブなキャラなので、噴水ONにします ");
				FountainPaSC.CharaIsHere = true;
//				if (HunsuiBody.activeSelf == false) {
//					HunsuiBody.SetActive (true);
//				}	
			} else {
				FountainPaSC.CharaIsHere = false;
//				if (HunsuiBody.activeSelf) {
//					HunsuiBody.SetActive (false);
//				}
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
//				if (HunsuiBody.activeSelf) {
//					HunsuiBody.SetActive (false);
//				}
			}
		}
	}
	//#################################################################################

}
// End