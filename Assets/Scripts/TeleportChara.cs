using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportChara : MonoBehaviour {

	private GameObject gameManager;
	public GameManager GMScript;
	public GameObject parentObject = null;
	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		gameManager = GameObject.Find ("GameManager");
		GMScript = gameManager.GetComponent<GameManager> ();
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

	}


	//####################################  Update  ###################################

	void Update () {


	}

	//####################################  other  ####################################

	public void touchWarpPoint(Collider other){

		//	if (other.gameObject.tag == "Player") {

		parentObject = other.gameObject;
		if (parentObject == CharaMoveMscript.activeChara) {

			parentObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1000);
		}
	}


	public void OnTriggerEnter(Collider other){
		//		Debug.Log ("BoardTicket (衝突時): " + BoardTicket);
		Debug.Log ("touchWarpPoint ");
		if (other.gameObject.tag == "Player") {
			charamovemanager = GameObject.Find ("charamovemanager");
			CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

			if (other.gameObject == CharaMoveMscript.activeChara) {
				Debug.Log ("WarpPoint にアクティブキャラが接触");
//				other.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1000);
				CharaMoveMscript.TeleportChara ();
			}

		}
	}
	//#################################################################################

}
// End