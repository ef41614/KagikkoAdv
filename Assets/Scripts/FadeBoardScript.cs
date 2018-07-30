using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeBoardScript : MonoBehaviour {

	Renderer rend;
	Color color;
	float alpha;
	public bool goFadeIn = false;
	public bool goFadeOut = false;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		rend = GetComponent<Renderer> ();
		alpha = 0;

	}


	//####################################  Update  ###################################

	void Update () {
		if (goFadeOut == true) {
			alpha = alpha + Time.deltaTime * 0.001f;
			rend.material.color = new Color (255f, 65f, 28f, alpha);
		}
	}

	//####################################  other  ####################################
	//#################################################################################

}
// End