using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixController : MonoBehaviour {


	//☆################☆################  Start  ################☆################☆

	void Start () {

	}


	//####################################  Update  ###################################

	void Update () {
		gameObject.transform.rotation = Quaternion.Euler(90,0,0);
	}

	//####################################  other  ####################################

	void LateUpdate () {

	}

	//#################################################################################

}
// End
