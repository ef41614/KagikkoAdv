using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureController : MonoBehaviour {

	private GameObject gameManager;
	public GameManager GMScript;
	GameObject Mewindow;
	public Text targetText; 
	public float difference = 10;
	GameObject MainCamera; 

	//☆################☆################  Start  ################☆################☆

	void Start () {
		gameManager = GameObject.Find ("GameManager");
		GMScript = gameManager.GetComponent<GameManager> ();
		GMScript.getPositionInfo();
		transform.position = GMScript.appearPosition;
		MainCamera = GameObject.Find ("MainCamera");

	}

	//####################################  Update  ###################################

	void Update () {

	}

	//####################################  other  ####################################

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Key") {
//			inFrontOfCamera ();
			GMScript.GetTreasure ();
			GMScript.CreateKey ();
			Destroy (this.gameObject);
			GMScript.sentence = "宝箱が開いたよ！";
			GMScript.waitTime = 4.0f;
			GMScript.ActiveMewindow ();
			GMScript.DisplayMessage ();
		}
//	}

//	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			GMScript.messageOrder = true;
			GMScript.sentence = "カギがないと開かないよ！";
			GMScript.waitTime = 2.0f;
			GMScript.ActiveMewindow ();
			GMScript.DisplayMessage ();

//			GMScript.DisplayMessage ("カギがないと開かないよ！");
//			Mewindow = GameObject.Find ("MeWindow");
//			this.targetText = Mewindow.GetComponentInChildren<Text>();
//			this.targetText.text = "カギがないと開かないよ！"; 
//			Invoke("GMScript.InactiveMewindow", 3.5f);
//			StartCoroutine("DelayMethod");
		}
	}

//	public void inFrontOfCamera(){
//		this.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z-difference);
//	}

	private IEnumerator DelayMethod(){
		yield return new WaitForSeconds(3.5f);
		GMScript.InactiveMewindow ();
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			GMScript.InactiveMewindow ();
		}
	}

	//#################################################################################

}
// End