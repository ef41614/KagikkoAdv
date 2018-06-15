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

	//☆################☆################  Start  ################☆################☆

	void Start () {
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		TurnMscript = turnmanager.GetComponent<TurnManager>(); 

		UchanThirdPersonCamera.SetActive (false);
		PchanThirdPersonCamera.SetActive (false);
	}


	//####################################  Update  ###################################

	void Update () {
		Debug.Log ("TurnMscript.canMove1P : "+TurnMscript.canMove1P);
		Debug.Log ("TurnMscript.canMove2P : "+TurnMscript.canMove2P);
	}

	//####################################  other  ####################################

	public void ChangeCamera(){
		// カメラを切り替える
		// ↓現在のactive状態から反転 
		MainCamera.SetActive (!MainCamera.activeInHierarchy);
		if(TurnMscript.canMove1P == true){
			UchanThirdPersonCamera.SetActive (!UchanThirdPersonCamera.activeInHierarchy);
//			PchanThirdPersonCamera.SetActive (!PchanThirdPersonCamera.activeInHierarchy);
		}
		if(TurnMscript.canMove2P == true){
//			UchanThirdPersonCamera.SetActive (!UchanThirdPersonCamera.activeInHierarchy);
			PchanThirdPersonCamera.SetActive (!PchanThirdPersonCamera.activeInHierarchy);
		}
	}

	//#################################################################################

}
// End