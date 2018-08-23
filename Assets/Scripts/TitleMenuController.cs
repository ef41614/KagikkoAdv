using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleMenuController : MonoBehaviour {

	int targetCount = 1;

	void Awake(){
		targetCount = GameObject.FindGameObjectsWithTag ("TitleMenu").Length;
		if (targetCount >= 4) {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
