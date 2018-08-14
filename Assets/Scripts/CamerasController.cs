using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour {

	public GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;

	public GameObject turnmanager;
	TurnManager TurnMscript;
	public GameObject timerManager;
	TimerController TimerSC;

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
	bool turningRight = false;
	bool turningLeft = false;

	public GameObject Uchan;
	public GameObject Pchan;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		TurnMscript = turnmanager.GetComponent<TurnManager>(); 

		UchanThirdPersonCamera.SetActive (false);
		UchanMapCamera.SetActive (false);
		PchanThirdPersonCamera.SetActive (false);
		PchanMapCamera.SetActive (false);

		CharaViewActive = false;
		TimerSC = timerManager.GetComponent<TimerController> ();
	}


	//####################################  Update  ###################################

	void Update () {

		if (turningRight == true) {
			turnRigltCamera ();
		}

		if (turningLeft == true) {
			turnLeftCamera ();
		}

		if ((UchanThirdPersonCamera.activeSelf) || (PchanThirdPersonCamera.activeSelf)) {
			CharaViewActive = true;
		}else {
//		if((UchanThirdPersonCamera==null) && (PchanThirdPersonCamera==null))  {
			CharaViewActive = false;
		}

		if (TimerSC.totalTime < 0.1f) {
			if(turningRight){
				pushUpTurnRightButton();
			}
			if(turningLeft){
				pushUpTurnLeftButton();
			}
		}
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
//		UchanThirdPersonCamera.transform.eulerAngles = new Vector3 (0, 0, 0);
//		PchanThirdPersonCamera.transform.Rotate(new Vector3(0, 0, 0));
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

	public void pushDownTurnRightButton(){
		turningRight = true;
	}

	public void pushUpTurnRightButton(){
		turningRight = false;
	}

	public void pushDownTurnLeftButton(){
		turningLeft = true;
	}

	public void pushUpTurnLeftButton(){
		turningLeft = false;
	}

	public void turnRigltCamera(){
		if (UchanThirdPersonCamera.activeSelf)  {
//			UchanThirdPersonCamera.transform.Rotate(new Vector3(0, 5, 0));
			Uchan.transform.Rotate(new Vector3(0, 5, 0));
		}
		if (PchanThirdPersonCamera.activeSelf) {
			Pchan.transform.Rotate(new Vector3(0, 5, 0));
		}
	}

	public void turnLeftCamera(){
		if (UchanThirdPersonCamera.activeSelf)  {
			Uchan.transform.Rotate(new Vector3(0, -5, 0));
		}
		if (PchanThirdPersonCamera.activeSelf) {
			Pchan.transform.Rotate(new Vector3(0, -5, 0));
		}
	}

	//#################################################################################

}
// End