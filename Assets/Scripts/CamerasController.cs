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
		MainCamera.SetActive (!MainCamera.activeInHierarchy);
		if(TurnMscript.canMove1P == true){
			UchanThirdPersonCamera.SetActive (!UchanThirdPersonCamera.activeInHierarchy);
			UchanMapCamera.SetActive (false);
		}
		if(TurnMscript.canMove2P == true){
			PchanThirdPersonCamera.SetActive (!PchanThirdPersonCamera.activeInHierarchy);
			PchanMapCamera.SetActive (false);
		}
	}

	public void ChangeMapCamera(){
		// カメラを切り替える
		MainCamera.SetActive (!MainCamera.activeInHierarchy);
		if(TurnMscript.canMove1P == true){
			UchanMapCamera.SetActive (!UchanMapCamera.activeInHierarchy);
			UchanThirdPersonCamera.SetActive (false);
		}
		if(TurnMscript.canMove2P == true){
			PchanMapCamera.SetActive (!PchanMapCamera.activeInHierarchy);
			PchanThirdPersonCamera.SetActive (false);
		}
	}

	//#################################################################################

}
// End