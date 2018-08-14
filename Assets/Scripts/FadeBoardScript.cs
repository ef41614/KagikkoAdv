using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeBoardScript : MonoBehaviour {

	Renderer rend;
	Color color;
	public float alpha;
	public bool goFadeIn = false;
	public bool goFadeOut = false;
	public GameObject timerManager;
	TimerController TimerSC;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		rend = GetComponent<Renderer> ();
		alpha = 1;
		timerManager = GameObject.Find ("TimerManager");
		TimerSC = timerManager.GetComponent<TimerController> ();
	}


	//####################################  Update  ###################################

	void Update () {
		if ((goFadeOut == true) ||(TimerSC.totalTime < 0.5f) ){
			if (alpha > 0.05f) {
				alpha = alpha - Time.deltaTime * 2f;
				rend.material.color = new Color (255f/255f, 65f/255f, 28f/255f, alpha);
			}
		}
	}

	//####################################  other  ####################################
	//#################################################################################

}
// End