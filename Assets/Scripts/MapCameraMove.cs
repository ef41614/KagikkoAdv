using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class MapCameraMove : MonoBehaviour {

	public GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;

	bool MovingNorth = false;
	bool MovingSouth = false;
	bool MovingEast = false;
	bool MovingWest = false;

	Vector3 pos;  // MapCameraの位置
	float range = 0.4f;
	public float MaxRange = 3;
	float limit = 35;
	float LocalLimit = 5;

	public GameObject Uchan;
	public GameObject Pchan;
	GameObject CharaMapCamera;
	public GameObject UchanMapCamera;
	public GameObject PchanMapCamera;

	public GameObject wall_Left;
	public GameObject wall_Right;
	public GameObject wall_Bottom;
	public GameObject wall_Top;

	Vector3 LeftPos;
	Vector3 RightPos;
	Vector3 BottomPos;
	Vector3 TopPos;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
		ResetPositon ();

		CharaMapCamera = UchanMapCamera;
//		CharaMapCamera.SetActive (false);

//		LeftPos = wall_Left.transform.position;
//		LeftPos.x += 3; 
//		RightPos = wall_Right.transform.position;
//		RightPos.x -= 3;
//		BottomPos = wall_Bottom.transform.position;
//		BottomPos.z += 3;
//		TopPos = wall_Top.transform.position;
//		TopPos.z -= 3.5f;

		LeftPos = CharaMoveMscript.LeftPos;
		RightPos = CharaMoveMscript.RightPos;
		BottomPos = CharaMoveMscript.BottomPos;
		TopPos = CharaMoveMscript.TopPos;
	}
	//####################################  Update  ###################################

	void Update () {

		if (UchanMapCamera.activeSelf)  {
			CharaMapCamera = UchanMapCamera;
		}

		if (PchanMapCamera.activeSelf)  {
			CharaMapCamera = PchanMapCamera;
		}

//		float L = LeftPos.x;
//		float R = RightPos.x;
//		float B = BottomPos.z;
//		float T = TopPos.z;
		if (CharaMapCamera !=null) {
			CharaMapCamera.transform.position = (new Vector3 (
				Mathf.Clamp (CharaMapCamera.transform.position.x, LeftPos.x,RightPos.x),
				Mathf.Clamp (CharaMapCamera.transform.position.y, -1, 10),
				Mathf.Clamp (CharaMapCamera.transform.position.z, BottomPos.z,TopPos.z)
			));

			CharaMapCamera.transform.localPosition = (new Vector3 (
				Mathf.Clamp (CharaMapCamera.transform.localPosition.x, -LocalLimit, LocalLimit),
				Mathf.Clamp (CharaMapCamera.transform.localPosition.y, -30, 30),
				Mathf.Clamp (CharaMapCamera.transform.localPosition.z, -LocalLimit, LocalLimit)
			));
		}

		if(MovingNorth){
			MoveNorthCamera();
		}

		if(MovingSouth){
			MoveSouthCamera();
		}

		if(MovingEast){
			MoveEastCamera();
		}

		if(MovingWest){
			MoveWestCamera();
		}

//		Debug.Log ("pos.x : "+ CharaMapCamera.pos.x);
//		Debug.Log ("pos.y : "+ CharaMapCamera.pos.y);
//		Debug.Log ("pos.z : "+ CharaMapCamera.pos.z);
	}

	//####################################  other  ####################################

	public void ResetPositon () {
		if (CharaMapCamera !=null) {
//		pos = this.gameObject.transform.position;
		pos = CharaMapCamera.transform.position;
//		this.gameObject.transform.position = new Vector3 (0,10,0);
//		CharaMapCamera.transform.position = new Vector3 (0,10,0);
		CharaMapCamera.transform.localPosition = new Vector3 (0,10,0);
		//		this.gameObject.transform.localPosition = new Vector3 (0,10,0);
		}
	}


	public void PushDownMoveNorthButton(){
		MovingNorth = true;
	}
	public void PushUpMoveNorthButton(){
		MovingNorth = false;
	}


	public void PushDownMoveSouthButton(){
		MovingSouth = true;
	}
	public void PushUpMoveSouthButton(){
		MovingSouth = false;
	}


	public void PushDownMoveEastButton(){
		MovingEast = true;
	}
	public void PushUpMoveEastButton(){
		MovingEast = false;
	}


	public void PushDownMoveWestButton(){
		MovingWest = true;
	}
	public void PushUpMoveWestButton(){
		MovingWest = false;
	}


	public void MoveNorthCamera(){
//			CharaMapCamera.transform.position = new Vector3 (pos.x, pos.y, pos.z + range);
			CharaMapCamera.transform.Translate (0, range,0);
//			this.gameObject.transform.position = new Vector3 (pos.x, pos.y, pos.z + range);
//			this.gameObject.transform.localPosition = new Vector3 (pos.x, pos.y, pos.z + range);
	}

	public void MoveSouthCamera(){
//			this.gameObject.transform.position = new Vector3 (pos.x, pos.y, pos.z - range);
//			CharaMapCamera.transform.position = new Vector3 (pos.x, pos.y, pos.z - range);
			CharaMapCamera.transform.Translate (0, -range,0);
	}

	public void MoveEastCamera(){
//			this.gameObject.transform.position = new Vector3 (pos.x + range, pos.y, pos.z);
//			CharaMapCamera.transform.position = new Vector3 (pos.x + range, pos.y, pos.z);
			CharaMapCamera.transform.Translate (range,0,0);
	}

	public void MoveWestCamera(){
//			this.gameObject.transform.position = new Vector3 (pos.x - range, pos.y, pos.z);
//			CharaMapCamera.transform.position = new Vector3 (pos.x - range, pos.y, pos.z);
			CharaMapCamera.transform.Translate (-range,0,0);
	}

	//#################################################################################

}
// End