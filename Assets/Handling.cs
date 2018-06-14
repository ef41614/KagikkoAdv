using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handling : MonoBehaviour {

	public float MovingDistance = 600;
	public float TopLine = 4061;
	public float bottomLine = 462;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		Debug.Log ("Handlingスクリプト出席確認");

	}


	//####################################  Update  ###################################

	void Update () {
//		Debug.Log ("Handling_transform.position.y : "+transform.position.y);

	}

	//####################################  other  ####################################

	public void UpHandle(){
		if(transform.position.y > bottomLine){
			transform.Translate (0, -1*MovingDistance, 0);
		}
		if(transform.position.y <= bottomLine){
			transform.Translate (0, 0, 0);
		}
	}

	public void DownHandle(){
		if(transform.position.y < TopLine){
			transform.Translate (0, MovingDistance, 0);
		}
		if(transform.position.y >= TopLine){
			transform.Translate (0, 0, 0);
		}
	}

	//#################################################################################

}
// End