using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressInfoScript : MonoBehaviour {

	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
	}


	//####################################  Update  ###################################

	void Update () {


	}

	//####################################  other  ####################################

	public void OnTriggerEnter(Collider other){
		Debug.Log ("こちら 噴水S です "); //★

		if (other.gameObject.tag == "Player") {
			charamovemanager = GameObject.Find ("charamovemanager");
			CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

			if (other.gameObject == CharaMoveMscript.activeChara) {
				Debug.Log ("行き先のAddressInfo を渡します ");
				//				other.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1000);
				CharaMoveMscript.AddressInfo = 0010001; //★
			}
		}
	}
	//#################################################################################

}
// End