using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour {

	public GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;

	public GameObject turnmanager;
	TurnManager TurnMscript;

	[SerializeField]
	private GameObject MainCamera;   // インスペクターで主観カメラを紐づける
	[SerializeField]
	private GameObject UchanThirdPersonCamera;   // インスペクターで第三者視点カメラを紐づける
	[SerializeField]
	private GameObject PchanThirdPersonCamera; 

	[SerializeField]
	private GameObject UchanMapCamera;   
	[SerializeField]
	private GameObject PchanMapCamera; 

	public bool CharaViewActive = false;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		TurnMscript = turnmanager.GetComponent<TurnManager>(); 

		UchanThirdPersonCamera.SetActive (false);
		UchanMapCamera.SetActive (false);
		PchanThirdPersonCamera.SetActive (false);
		PchanMapCamera.SetActive (false);
	}


	//####################################  Update  ###################################

	void Update () {
//		Debug.Log ("TurnMscript.canMove1P : "+TurnMscript.canMove1P);
//		Debug.Log ("TurnMscript.canMove2P : "+TurnMscript.canMove2P);
	}

	//####################################  other  ####################################

	public void ChangeCharaCamera(){
		// カメラを切り替える
		// ↓現在のactive状態から反転 
//		MainCamera.SetActive (!MainCamera.activeInHierarchy);
		if(TurnMscript.canMove1P == true){
			UchanThirdPersonCamera.SetActive (!UchanThirdPersonCamera.activeInHierarchy);
			inactiveMapCamera ();
		}
		if(TurnMscript.canMove2P == true){
			PchanThirdPersonCamera.SetActive (!PchanThirdPersonCamera.activeInHierarchy);
			inactiveMapCamera ();
		}
	}

	public void ChangeMapCamera(){
		// カメラを切り替える
//		MainCamera.SetActive (!MainCamera.activeInHierarchy);
		if(TurnMscript.canMove1P == true){
			UchanMapCamera.SetActive (!UchanMapCamera.activeInHierarchy);
			inactiveCharaCamera ();
		}
		if(TurnMscript.canMove2P == true){
			PchanMapCamera.SetActive (!PchanMapCamera.activeInHierarchy);
			inactiveCharaCamera ();
		}
		if ((UchanThirdPersonCamera) || (PchanThirdPersonCamera)) {
			CharaViewActive = true;
		} else {
			CharaViewActive = false;
		}
	}

	public void inactiveCharaCamera(){
		if (UchanThirdPersonCamera) {
			UchanThirdPersonCamera.SetActive (false);
		}
		if (PchanThirdPersonCamera) {
			PchanThirdPersonCamera.SetActive (false);
		}
	}

	public void inactiveMapCamera(){
		if (UchanMapCamera) {
			UchanMapCamera.SetActive (false);
		}
		if (PchanMapCamera) {
			PchanMapCamera.SetActive (false);
		}
	}

	//#################################################################################

}
// End