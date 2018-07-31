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

	//☆################☆################  Start  ################☆################☆

	void Start () {
		rend = GetComponent<Renderer> ();
		alpha = 1;

	}


	//####################################  Update  ###################################

	void Update () {
		if (goFadeOut == true) {
			if (alpha > 0.3) {
				alpha = alpha - Time.deltaTime * 5f;
				rend.material.color = new Color (255f/255f, 65f/255f, 28f/255f, alpha);
			}
		}
	}

	//####################################  other  ####################################
	//#################################################################################

}
// End