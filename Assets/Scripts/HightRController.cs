using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightRController : MonoBehaviour {

	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
	public GameObject Board;
	BoardController BoardSC;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		BoardSC = Board.GetComponent<BoardController> ();
	}

	//####################################  Update  ###################################

	void Update () {
		if (CharaMoveMscript.OnBoard) {
//			transform.position = new Vector3 (transform.position.x, 1000, transform.position.z);
			float Size = 0.2f;
			this.transform.localScale = new Vector3(Size, Size, Size);
		}

		if (CharaMoveMscript.OnBoard==false) {
//			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		}
	}

	//####################################  other  ####################################
//	public void OnCollisionEnter(Collision other){
		public void OnTriggerEnter(Collider other){
//		Debug.Log ("BoardTicket (衝突時): " + BoardTicket);

		if (other.gameObject.tag == "Player") {
//			if (BoardTicket == 1) {
//			gameObject.transform.rotation = Quaternion.Euler (45, 0, 0);
//			gameObject.transform.rotation = Quaternion.Euler (-45, 0, 0);
//			Board.gameObject.transform.rotation = Quaternion.Euler (90, 0, 0);
//			Board.gameObject.transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
			if (BoardSC.mode == 0) {
				BoardSC.mode = 2;
				BoardSC.RotationBoard();
//			BoardSC.RotationBoardFlg = true;
				Debug.Log ("★R接触★Board");
//			}
			}
		}
	}
	//#################################################################################

}
// End