using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightController : MonoBehaviour {

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
	public void OnTriggerEnter(Collider other){
		//		Debug.Log ("BoardTicket (衝突時): " + BoardTicket);

		if (other.gameObject.tag == "Player") {

			if (BoardSC.mode == 0) {
				BoardSC.mode = 1;
			}
//			BoardSC.RotationBoard();
			//			BoardSC.RotationBoardFlg = true;
			Debug.Log ("まっすぐBoardに乗った！");
			//			}
		}
	}
	//#################################################################################

}
// End